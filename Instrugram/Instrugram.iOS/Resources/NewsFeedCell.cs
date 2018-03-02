using System;
using CoreGraphics;
using Facebook.CoreKit;
using Foundation;
using Instrugram.iOS.Helpers;
using Instrugram.iOS.Models;
using UIKit;

namespace Instrugram.iOS.Resources
{
    public partial class NewsFeedCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("NewsFeedCell");
        public static readonly UINib Nib;
        public PhotoModel CurrentPhoto { get; set; }

        static NewsFeedCell()
        {
            Nib = UINib.FromName("NewsFeedCell", NSBundle.MainBundle);
        }

        protected NewsFeedCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public NewsFeedCell () {
            using (var url = new NSUrl(AppSettingsManager.ProfilePictureUrl))
            using (var data = NSData.FromUrl(url))
            {
                ProfilePictureImageView.Image = UIImage.LoadFromData(data);
            }

            NameLabel.Text = AppSettingsManager.FirstName + " " + AppSettingsManager.LastName;
        }

        public void UpdateCell(PhotoModel photo) {
            CurrentPhoto = photo;

            //var aspectRatio = photo.Image.Size.Height / photo.Image.Size.Width;
            ////PhotoImageView.Image = photo.Image;


            //this.Frame = new CGRect
            //(
            //    location: this.Frame.Location,
            //    size: new CGSize(this.Frame.Width, this.TopBar.Frame.Height * 2 + this.Frame.Width * aspectRatio)
            //);
            this.SizeToFit();
            DateLabel.Text = photo.Date.ToShortTimeString() + " " + photo.Date.ToShortDateString();
        }
    }
}
