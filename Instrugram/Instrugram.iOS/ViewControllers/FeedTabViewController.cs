using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Instrugram.iOS.Models;
using Instrugram.iOS.Resources;
using UIKit;

namespace Instrugram.iOS {
    public partial class FeedTabViewController : UIViewController {
        public FeedTabViewController ( IntPtr handle ) : base( handle ) {
        }

        public override void ViewDidLoad () {
            base.ViewDidLoad();

            //NewsTableView.RegisterClassForCellReuse(typeof(NewsFeedCell), NewsFeedCell.Key);

            NewsTableView.RegisterNibForCellReuse( UINib.FromName( "FeedTableCell", null ), FeedTableCell.Key );
            NewsTableView.Source = new NewsFeedTableSource( PhotoDataSource.Source );
        }
    }

    public class NewsFeedTableSource : UITableViewSource {
        private readonly PhotoDataSource _source;

        public NewsFeedTableSource ( PhotoDataSource source ) {
            _source = source;
        }

        public override UITableViewCell GetCell ( UITableView tableView, NSIndexPath indexPath ) {
            var cell = tableView.DequeueReusableCell( FeedTableCell.Key, indexPath ) as FeedTableCell;

            cell.UpdateCell( _source.GetPhoto( indexPath ), tableView, indexPath );

            return cell;
        }

        public override nfloat GetHeightForRow ( UITableView tableView, NSIndexPath indexPath ) {
            var currentPhoto = _source.GetPhoto( indexPath );
            if ( currentPhoto.ToBeDeleted ) {
                return 0;
            }

            var additionalHeight = FeedTableCell.BarHeight * 2;
            var aspectRatio = currentPhoto.Image.Size.Height / currentPhoto.Image.Size.Width;

            var imageHeight = tableView.Frame.Width * aspectRatio;
            return imageHeight + additionalHeight;
        }

        public override nint RowsInSection ( UITableView tableview, nint section ) {
            return _source.Count();
        }

        public override nint NumberOfSections ( UITableView tableView ) {
            return 1;
        }
    }

    public class PhotoDataSource {
        private readonly List<PhotoModel> photos;

        private PhotoDataSource () {
            //TODO: get photos from folder. I guess
            photos = new List<PhotoModel> {
                new PhotoModel {Image = UIImage.FromFile( "test.jpg" ), Date = DateTime.MinValue},
                new PhotoModel {Image = UIImage.FromFile( "test.jpg" ), Date = DateTime.Now},
                new PhotoModel {Image = UIImage.FromFile( "phtt.jpeg" ), Date = DateTime.Now},
                new PhotoModel {Image = UIImage.FromFile( "test.jpg" ), Date = DateTime.MinValue},
                new PhotoModel {Image = UIImage.FromFile( "download.jpg" ), Date = DateTime.MaxValue},
                new PhotoModel {Image = UIImage.FromFile( "test.jpg" ), Date = DateTime.MaxValue}
            };
        }

        static PhotoDataSource () {
            Source = new PhotoDataSource();
        }

        public static PhotoDataSource Source { get; }

        public PhotoModel GetPhoto ( NSIndexPath path ) {
            return photos[path.Row];
        }

        public int Count () {
            return photos.Count;
        }

        public void AddPhoto ( PhotoModel photo ) {
            photos.Add(photo);
            photos.OrderBy( model => model.Date );
        }
    }
}