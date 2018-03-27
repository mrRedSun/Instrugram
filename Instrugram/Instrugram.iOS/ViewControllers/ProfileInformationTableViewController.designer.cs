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
    [Register ("ProfileInformationTableViewController")]
    partial class ProfileInformationTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell EmailProfileTableCell { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FirstNameProfileLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell FirstNameTableCell { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell GenderProfileTableCell { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LastNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableViewCell LastNameTableCell { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EmailProfileTableCell != null) {
                EmailProfileTableCell.Dispose ();
                EmailProfileTableCell = null;
            }

            if (FirstNameProfileLabel != null) {
                FirstNameProfileLabel.Dispose ();
                FirstNameProfileLabel = null;
            }

            if (FirstNameTableCell != null) {
                FirstNameTableCell.Dispose ();
                FirstNameTableCell = null;
            }

            if (GenderProfileTableCell != null) {
                GenderProfileTableCell.Dispose ();
                GenderProfileTableCell = null;
            }

            if (LastNameLabel != null) {
                LastNameLabel.Dispose ();
                LastNameLabel = null;
            }

            if (LastNameTableCell != null) {
                LastNameTableCell.Dispose ();
                LastNameTableCell = null;
            }
        }
    }
}