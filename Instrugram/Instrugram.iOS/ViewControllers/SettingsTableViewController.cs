using Foundation;
using System;
using System.Text.RegularExpressions;
using CoreGraphics;
using Instrugram.iOS.Helpers;
using Instrugram.iOS.Models;
using UIKit;

namespace Instrugram.iOS
{
    public partial class SettingsTableViewController : UITableViewController {
        private UserProfileModel currentProfileModelChanges;
        private CGRect _defaultTextFieldFrame;
        private bool isChanged = false;

        public SettingsTableViewController (IntPtr handle) : base (handle)
        {
        }



        public override void ViewDidLoad () {
            base.ViewDidLoad();
            currentProfileModelChanges = new UserProfileModel();

            _defaultTextFieldFrame = EmailTextField.Frame;

            WrongEmailErrorImage.Image = UIImage.FromBundle("ErrorIcon");
            WrongPasswordErrorImage.Image = UIImage.FromBundle("ErrorIcon");

            EmailTextField.Text = AppSettingsManager.Email;
            PasswordTextField.Text = AppSettingsManager.Password;

            EmailTextField.EditingDidBegin += ( o, e ) => {
                foreach ( var constraint in EmailTableCell.Constraints )
                { 
                    constraint.Active = false;
            }
                UIView.Animate( 0.25,
                    () => {
                        EmailTextField.Frame = new CGRect(new CGPoint(EmailLabel.Frame.X, EmailTextField.Frame.Y),
                            new CGSize(EmailTextField.Frame.Width + EmailLabel.Frame.Width,
                                EmailTextField.Frame.Height));
                        EmailLabel.Alpha = 0;

                        EmailLabel.Frame = new CGRect(0, 0, 0, 0);
                    } );
                EmailLabel.Hidden = true;
            };

            EmailTextField.EditingDidEnd += ( o, e ) => {
                foreach (var constraint in EmailTextField.Constraints)
                {
                    constraint.Active = true;
                }

                UIView.Animate( 0.25,
                    () => {
                        EmailTextField.Frame = _defaultTextFieldFrame;
                        EmailLabel.Alpha = 1;
                        EmailLabel.Hidden = false;
                    } );

                var pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                 @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                var emailCheck = new Regex( pattern );

                if ( emailCheck.IsMatch( EmailTextField.Text ) ) {
                    currentProfileModelChanges.Email = EmailTextField.Text.Trim();
                    WrongEmailErrorImage.Hidden = true;
                    isChanged = true;
                } else {
                    WrongEmailErrorImage.Hidden = false;
                }
            };

            PasswordTextField.EditingDidEnd += ( o, e ) => {
                if ( PasswordTextField.Text.Length >= 8 ) {
                    currentProfileModelChanges.Password = PasswordTextField.Text;
                    WrongPasswordErrorImage.Hidden = true;
                    isChanged = true;
                } else {
                    WrongPasswordErrorImage.Hidden = false;
                }
            };


            View.AddGestureRecognizer(new UITapGestureRecognizer( () => { View.EndEditing( true );}));
        }

        public override void ViewWillAppear ( bool animated ) {
            base.ViewWillAppear( animated );

            NavigationController.NavigationBarHidden = false;

            
        }
        
        public override void ViewWillDisappear ( bool animated ) {
            base.ViewWillDisappear( animated );
            if ( isChanged ) {
                using ( var userManager = new UserManager() ) {
                    userManager.UpdateCurrentUser( currentProfileModelChanges );
                }
            }

            NavigationController.NavigationBarHidden = true;
        }
    }
}