﻿// WARNING
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
    [Register ("ProfileTabViewController")]
    partial class ProfileTabViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView FrofileMainView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem FrofileTabBarItem { get; set; }

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
        }
    }
}