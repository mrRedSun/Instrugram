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
    [Register ("PhotoAddViewController")]
    partial class PhotoAddViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LatitudeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LongitudeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView PhotoLocationMap { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LatitudeLabel != null) {
                LatitudeLabel.Dispose ();
                LatitudeLabel = null;
            }

            if (LongitudeLabel != null) {
                LongitudeLabel.Dispose ();
                LongitudeLabel = null;
            }

            if (PhotoLocationMap != null) {
                PhotoLocationMap.Dispose ();
                PhotoLocationMap = null;
            }
        }
    }
}