using Foundation;
using System;
using UIKit;

namespace Instrugram.iOS
{
    public partial class ProfileTabViewController : UIViewController {
        private UIView cameraView;
        private UIView feedView;
        private UIView profileView;

        public ProfileTabViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad () {
            base.ViewDidLoad();

        }
    }
}