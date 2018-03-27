using System;
using Instrugram.iOS.Helpers;
using UIKit;

namespace Instrugram.iOS.ViewControllers
{
    public partial class ProfileInformationTableViewController : UITableViewController
    {
        public ProfileInformationTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad () {
            base.ViewDidLoad(); 

        }

        public override void ViewWillAppear ( bool animated ) {
            base.ViewWillAppear( animated );

            FirstNameProfileLabel.Text = AppSettingsManager.FirstName;
            LastNameTableCell.TextLabel.Text = AppSettingsManager.LastName;
            GenderProfileTableCell.TextLabel.Text = AppSettingsManager.Gender;
            EmailProfileTableCell.TextLabel.Text = AppSettingsManager.Email;
        }
    }
}