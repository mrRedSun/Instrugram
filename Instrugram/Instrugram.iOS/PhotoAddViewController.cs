using Foundation;
using System;
using CoreLocation;
using MapKit;
using UIKit;

namespace Instrugram.iOS
{
    public partial class PhotoAddViewController : UIViewController
    {
        private MKPointAnnotation _annotation;
        private CLLocationManager _locationManager;

        public PhotoAddViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad();
            SetupMapView();
        }

        private void SetupMapView()
        {
            _locationManager = new CLLocationManager();
            _locationManager.RequestWhenInUseAuthorization();

            _annotation = new MKPointAnnotation()
            {
                Title = "Photo location",
                Subtitle = "Your photo location will be here"
            };

            NavigationController.NavigationBarHidden = false;
            PhotoLocationMap.ShowsUserLocation = true;

            PhotoLocationMap.SetUserTrackingMode(MKUserTrackingMode.Follow, true);
            PhotoLocationMap.AddGestureRecognizer(new UILongPressGestureRecognizer(PinPhotoCoordinates));
            PhotoLocationMap.AddAnnotation(_annotation);
        }

        public override void ViewWillAppear ( bool animated ) {
            base.ViewWillAppear( animated );
            //PhotoLocationMap
        }

        private void PinPhotoCoordinates ( UILongPressGestureRecognizer gestureRecognizer ) {
            var tapLocation = gestureRecognizer.LocationInView( PhotoLocationMap );
            var pinCoordinates = PhotoLocationMap.ConvertPoint( tapLocation, PhotoLocationMap );
            _annotation.Coordinate = pinCoordinates;
            LongitudeLabel.Text = pinCoordinates.Longitude.ToString( "F5");
            LatitudeLabel.Text = pinCoordinates.Latitude.ToString("F5");
        }

        public override void ViewWillDisappear ( bool animated ) {
            base.ViewWillDisappear( animated );
            NavigationController.NavigationBarHidden = true;
        }
    }
}