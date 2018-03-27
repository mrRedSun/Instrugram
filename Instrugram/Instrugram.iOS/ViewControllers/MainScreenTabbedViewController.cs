using System;
using UIKit;

namespace Instrugram.iOS.ViewControllers
{
    public partial class MainScreenTabbedViewController : UITabBarController {

        public MainScreenTabbedViewController (IntPtr handle ) : base (handle) {
        }

        public override void ViewDidLoad () {
            base.ViewDidLoad();

            TabBar.Items[0].Image = UIImage.FromBundle("FeedGlyph");
            TabBar.Items[1].Image = UIImage.FromBundle("CameraGlyph");
            TabBar.Items[2].Image = UIImage.FromBundle("ProfileMaleGlyph");

            NavigationController.NavigationBarHidden = true;
        }
    }
}