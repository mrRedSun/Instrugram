using System;
using Foundation;
using Instrugram.iOS.Helpers;
using UIKit;

namespace Instrugram.iOS.ViewControllers {
    public partial class ProfileTabViewController : UIViewController {

        public ProfileTabViewController ( IntPtr handle ) : base( handle ) {
        }

        public override void ViewWillAppear ( bool animated ) {
            base.ViewWillAppear( animated );
        }

        public override void ViewDidLoad () {
            base.ViewDidLoad();

            using ( var url = new NSUrl( AppSettingsManager.ProfilePictureUrl ) )
                using ( var data = NSData.FromUrl( url ) )
                    ProfilePictureImageView.Image = UIImage.LoadFromData( data );

        }
    }
}