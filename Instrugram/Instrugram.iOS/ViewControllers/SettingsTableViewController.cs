using System;
using System.Text.RegularExpressions;
using CoreGraphics;
using Instrugram.iOS.Helpers;
using Instrugram.iOS.Models;
using UIKit;

namespace Instrugram.iOS {
    public partial class SettingsTableViewController : UITableViewController {
        private UserProfileModel _currentProfileModelChanges;
        private bool _isChanged;

        public SettingsTableViewController ( IntPtr handle ) : base( handle ) {
        }

        public override void ViewDidLoad () {
            base.ViewDidLoad();
            NavigationController.NavigationBar.Items[0].Title = "Profile";

            _currentProfileModelChanges = new UserProfileModel();

            WrongEmailErrorImage.Image = UIImage.FromBundle( "ErrorIcon" );
            WrongPasswordErrorImage.Image = UIImage.FromBundle( "ErrorIcon" );

            EmailTextField.Text = AppSettingsManager.Email;
            PasswordTextField.Text = AppSettingsManager.Password;

            ConstraintToSuperview.Active = false;

            EmailTextField.EditingDidBegin += ( o, e ) => {
                EmailConstraint.Active = false;
                ConstraintToSuperview.Active = true;
                UIView.Animate( 0.25,
                    () => {
                        EmailConstraint.Active = false;
                        ConstraintToSuperview.Active = true;

                        EmailTableCell.LayoutIfNeeded();

                        EmailLabel.Alpha = 0;
                    } );
                EmailLabel.Hidden = true;
            };

            EmailTextField.EditingDidEnd += EmailCheck;

            PasswordTextField.EditingDidEnd += ( o, e ) => {
                if ( PasswordTextField.Text.Length >= 8 ) {
                    _currentProfileModelChanges.Password = PasswordTextField.Text;
                    WrongPasswordErrorImage.Hidden = true;
                    _isChanged = true;
                } else {
                    WrongPasswordErrorImage.Hidden = false;
                }
            };

            View.AddGestureRecognizer( new UITapGestureRecognizer( () => { View.EndEditing( true ); } ) );
        }

        private void EmailCheck ( object o, EventArgs e ) {
            UIView.Animate( 0.25, () => {
                EmailConstraint.Active = true;
                ConstraintToSuperview.Active = false;
                EmailTableCell.LayoutIfNeeded();

                EmailLabel.Alpha = 1;
                EmailLabel.Hidden = false;
            } );

            var pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            var emailCheck = new Regex( pattern );

            if ( emailCheck.IsMatch( EmailTextField.Text ) ) {
                _currentProfileModelChanges.Email = EmailTextField.Text.Trim();
                WrongEmailErrorImage.Hidden = true;
                _isChanged = true;
            } else {
                WrongEmailErrorImage.Hidden = false;
            }
        }

        public override void ViewWillAppear ( bool animated ) {
            base.ViewWillAppear( animated );

            NavigationController.NavigationBarHidden = false;
        }

        public override void ViewWillDisappear ( bool animated ) {
            base.ViewWillDisappear( animated );
            View.EndEditing( true );

            if ( _isChanged ) {
                using ( var userManager = new UserManager() ) {
                    userManager.UpdateCurrentUser( _currentProfileModelChanges );
                }
            }

            NavigationController.NavigationBarHidden = true;
        }
    }
}