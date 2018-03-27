// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;

namespace Instrugram.iOS.ViewControllers
{
    [Register ("ProfileTabViewController")]
    partial class ProfileTabViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView FrofileMainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem FrofileTabBarItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ProfilePictureImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem SettingsButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FrofileMainView != null) {
                FrofileMainView.Dispose ();
                FrofileMainView = null;
            }

            if (FrofileTabBarItem != null) {
                FrofileTabBarItem.Dispose ();
                FrofileTabBarItem = null;
            }

            if (ProfilePictureImageView != null) {
                ProfilePictureImageView.Dispose ();
                ProfilePictureImageView = null;
            }

            if (SettingsButton != null) {
                SettingsButton.Dispose ();
                SettingsButton = null;
            }
        }
    }
}