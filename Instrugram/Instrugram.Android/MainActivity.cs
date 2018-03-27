using Android.App;
using Android.Widget;
using Android.OS;
//using Instrugram.Droid.Resources; todo: check this on the internet

namespace Instrugram.Droid
{
    [Activity(Label = "Instrugram", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
        }
    }
}

