using System;
using CoreGraphics;
using Foundation;
using Instrugram.iOS.Helpers;
using Instrugram.iOS.Models;
using UIKit;

namespace Instrugram.iOS.Resources
{
    public partial class FeedTableCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("FeedTableCell");
        public static readonly UINib Nib;
        public static readonly nfloat BarHeight = 45f;

        private UITableView _table;
        private NSIndexPath _path;


        public PhotoModel CurrentPhoto { get; set; }

        static FeedTableCell()
        {
            Nib = UINib.FromName("FeedTableCell", NSBundle.MainBundle);
        }

        protected FeedTableCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void AwakeFromNib () {
            base.AwakeFromNib();
            UserName.Text  = AppSettingsManager.FirstName + " " + AppSettingsManager.LastName;

            using (var url = new NSUrl(AppSettingsManager.ProfilePictureUrl))
            using (var data = NSData.FromUrl(url))
            {
                ProfilePictureImageView.Image = UIImage.LoadFromData(data);
            }

            LikeButton.TouchUpInside += ( sender, args ) => {
                CurrentPhoto.IsLiked = !CurrentPhoto.IsLiked;
                LikeButton.SetTitleColor( CurrentPhoto.IsLiked ? UIColor.Red : UIColor.Blue, UIControlState.Normal );
            };

            //DeleteButton.TouchUpInside += ( sender, args ) => {
            //    CurrentPhoto.ToBeDeleted = true;
            //    //ContentView.Hidden = true;

            //    //ContentView.Frame = CGRect.Empty;
            //    //Frame = CGRect.Empty;

                
            //    //_table.ReloadRows(new[] { _path}, UITableViewRowAnimation.Fade );
            //    _table.Delete(null);
            //    PhotoDataSource.Source.RemoveAtIndex(_path);
            //    _table.DeleteRows(new [] {_path}, UITableViewRowAnimation.Automatic );
            //};

        }

        public void UpdateCell(PhotoModel photo, UITableView table, NSIndexPath path) {
            if ( photo.ToBeDeleted ) {
                ContentView.Hidden = true;
                return;
            }

            _table = table;
            _path = path;


            //ContentView.Hidden = false;
            CurrentPhoto = photo;

            PhotoImageView.Image = photo.Image;

            //this.SizeToFit(); //todo: check this
            DateLabel.Text = photo.Date.ToShortTimeString() + " " + photo.Date.ToShortDateString();
        }

    }
}
