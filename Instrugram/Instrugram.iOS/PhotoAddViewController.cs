using Foundation;
using System;
using CoreLocation;
using Instrugram.iOS.Models;
using Instrugram.iOS.ViewControllers;
using MapKit;
using UIKit;

namespace Instrugram.iOS
{
    public partial class PhotoAddViewController : UIViewController
    {
        private MKPointAnnotation _annotation;
        private CLLocationManager _locationManager;
        private PhotoModel _photoToAdd;

        public PhotoAddViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad();
            _photoToAdd = new PhotoModel();

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
            var rand = new Random();
                              
            using (var url = new NSUrl($"https://placebear.com/g/{ rand.Next(400, 1000)}/{rand.Next(400, 1000)}"))
            using (var data = NSData.FromUrl(url))
            {
               _photoToAdd.Image = UIImage.LoadFromData(data);
            }

            _photoToAdd.Location = _annotation.Coordinate;
            _photoToAdd.Date = DateTime.Now;

            PhotoDataSource.Source.AddPhoto(_photoToAdd);

            NavigationController.NavigationBarHidden = true;


        }
    }
}