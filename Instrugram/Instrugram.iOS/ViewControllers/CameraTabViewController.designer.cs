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
    [Register ("CameraTabViewController")]
    partial class CameraTabViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView CameraMainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem CameraTabBarItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CameraMainView != null) {
                CameraMainView.Dispose ();
                CameraMainView = null;
            }

            if (CameraTabBarItem != null) {
                CameraTabBarItem.Dispose ();
                CameraTabBarItem = null;
            }
        }
    }
}