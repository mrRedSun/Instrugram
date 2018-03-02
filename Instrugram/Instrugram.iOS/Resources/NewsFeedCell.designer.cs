// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Instrugram.iOS.Resources
{
    [Register ("NewsFeedCell")]
    partial class NewsFeedCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ProfilePictureImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView TopBar { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DateLabel != null) {
                DateLabel.Dispose ();
                DateLabel = null;
            }

            if (NameLabel != null) {
                NameLabel.Dispose ();
                NameLabel = null;
            }

            if (ProfilePictureImageView != null) {
                ProfilePictureImageView.Dispose ();
                ProfilePictureImageView = null;
            }

            if (TopBar != null) {
                TopBar.Dispose ();
                TopBar = null;
            }
        }
    }
}