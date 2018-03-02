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
    [Register ("SettingsTableViewController")]
    partial class SettingsTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint ConstraintToSuperview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint EmailConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EmailLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell EmailTableCell { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EmailTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView WrongEmailErrorImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView WrongPasswordErrorImage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ConstraintToSuperview != null) {
                ConstraintToSuperview.Dispose ();
                ConstraintToSuperview = null;
            }

            if (EmailConstraint != null) {
                EmailConstraint.Dispose ();
                EmailConstraint = null;
            }

            if (EmailLabel != null) {
                EmailLabel.Dispose ();
                EmailLabel = null;
            }

            if (EmailTableCell != null) {
                EmailTableCell.Dispose ();
                EmailTableCell = null;
            }

            if (EmailTextField != null) {
                EmailTextField.Dispose ();
                EmailTextField = null;
            }

            if (PasswordTextField != null) {
                PasswordTextField.Dispose ();
                PasswordTextField = null;
            }

            if (WrongEmailErrorImage != null) {
                WrongEmailErrorImage.Dispose ();
                WrongEmailErrorImage = null;
            }

            if (WrongPasswordErrorImage != null) {
                WrongPasswordErrorImage.Dispose ();
                WrongPasswordErrorImage = null;
            }
        }
    }
}