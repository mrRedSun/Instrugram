﻿// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;

namespace Instrugram.iOS.ViewControllers
{
    [Register ("FeedTabViewController")]
    partial class FeedTabViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem AddPhotoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView FeedMainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem FeedTabBarItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView NewsTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AddPhotoButton != null) {
                AddPhotoButton.Dispose ();
                AddPhotoButton = null;
            }

            if (FeedMainView != null) {
                FeedMainView.Dispose ();
                FeedMainView = null;
            }

            if (FeedTabBarItem != null) {
                FeedTabBarItem.Dispose ();
                FeedTabBarItem = null;
            }

            if (NewsTableView != null) {
                NewsTableView.Dispose ();
                NewsTableView = null;
            }
        }
    }
}