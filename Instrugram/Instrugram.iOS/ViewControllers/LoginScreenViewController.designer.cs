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
    [Register ("LoginScreenViewController")]
    partial class LoginScreenViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LoginButtonView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LogoLabelView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RegisterButtonView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView VideoPlayerContainerView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LoginButtonView != null) {
                LoginButtonView.Dispose ();
                LoginButtonView = null;
            }

            if (LogoLabelView != null) {
                LogoLabelView.Dispose ();
                LogoLabelView = null;
            }

            if (RegisterButtonView != null) {
                RegisterButtonView.Dispose ();
                RegisterButtonView = null;
            }

            if (VideoPlayerContainerView != null) {
                VideoPlayerContainerView.Dispose ();
                VideoPlayerContainerView = null;
            }
        }
    }
}