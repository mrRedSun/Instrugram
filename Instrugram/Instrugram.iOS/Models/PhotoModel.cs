using System;
using CoreLocation;
using UIKit;

namespace Instrugram.iOS.Models {
    public class PhotoModel {
        public DateTime Date { get; set; }
        public UIImage Image { get; set; }
        public string FileAdress { get; set; }
        public bool IsLiked { get; set; }
        public bool ToBeDeleted { get; set; } = false;
        public  CLLocationCoordinate2D? Location { get; set; }


        public void Delete () { 
            // deletion-of-file
        }
    }
}