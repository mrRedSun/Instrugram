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
    [Register ("FeedTableCell")]
    partial class FeedTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView BottomBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DeleteButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LikeButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView PhotoImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ProfilePictureImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView TopBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BottomBar != null) {
                BottomBar.Dispose ();
                BottomBar = null;
            }

            if (DateLabel != null) {
                DateLabel.Dispose ();
                DateLabel = null;
            }

            if (DeleteButton != null) {
                DeleteButton.Dispose ();
                DeleteButton = null;
            }

            if (LikeButton != null) {
                LikeButton.Dispose ();
                LikeButton = null;
            }

            if (PhotoImageView != null) {
                PhotoImageView.Dispose ();
                PhotoImageView = null;
            }

            if (ProfilePictureImageView != null) {
                ProfilePictureImageView.Dispose ();
                ProfilePictureImageView = null;
            }

            if (TopBar != null) {
                TopBar.Dispose ();
                TopBar = null;
            }

            if (UserName != null) {
                UserName.Dispose ();
                UserName = null;
            }
        }
    }
}