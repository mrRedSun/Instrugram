// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Instrugram.iOS
{
    [Register ("FeedTabViewController")]
    partial class FeedTabViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView FeedMainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem FeedTabBarItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FeedMainView != null) {
                FeedMainView.Dispose ();
                FeedMainView = null;
            }

            if (FeedTabBarItem != null) {
                FeedTabBarItem.Dispose ();
                FeedTabBarItem = null;
            }
        }
    }
}