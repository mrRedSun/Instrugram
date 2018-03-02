using Foundation;
using System;
using UIKit;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace Instrugram.iOS
{
    public partial class CameraTabViewController : UIViewController
    {
        public CameraTabViewController (IntPtr handle) : base (handle) {

        }

        public override async void ViewWillAppear ( bool animated ) {
            base.ViewWillAppear( animated );

            Console.WriteLine( CrossMedia.IsSupported );

            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                // Supply media options for saving our photo after it's taken.
                var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Receipts",
                    Name = $"{DateTime.UtcNow}.jpg"
                };

                // Take a photo of the business receipt.
                var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);
                
                if (CrossMedia.Current.IsPickPhotoSupported) {
                    var photo = await CrossMedia.Current.PickPhotoAsync();
                }
            }
        }
    }
}