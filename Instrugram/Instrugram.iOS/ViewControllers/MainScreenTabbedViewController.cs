using Foundation;
using System;
using UIKit;
using System.Data;
using Mono.Data.Sqlite;

namespace Instrugram.iOS
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