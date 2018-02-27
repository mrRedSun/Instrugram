using Foundation;

namespace Instrugram.iOS.Helpers {
    internal static class AppSettingsManager {
        private static readonly NSUserDefaults PrefList;

        static AppSettingsManager () {
            PrefList = NSUserDefaults.StandardUserDefaults;
        }

        public static string FirstName {
            get => PrefList.StringForKey( "FirstName" );
            set => PrefList.SetString( value, "FirstName" );
        }

        public static string LastName {
            get => PrefList.StringForKey( "LastName" );
            set => PrefList.SetString( value, "LastName" );
        }

        public static string Gender {
            get => PrefList.StringForKey( "Gender" );
            set => PrefList.SetString( value, "Gender" );
        }

        public static string FacebookUserId {
            get => PrefList.StringForKey( "FacebookUserId" );
            set => PrefList.SetString( value, "FacebookUserId" );
        }

        public static string ProfilePictureUrl {
            get => PrefList.StringForKey( "ProfilePictureUrl" );
            set => PrefList.SetString( value, "ProfilePictureUrl" );
        }

        public static string Password {
            get => PrefList.StringForKey( "Password" );
            set => PrefList.SetString( value, "Password" );
        }

        public static string Email {
            get => PrefList.StringForKey( "Email" );
            set => PrefList.SetString( value, "Email" );
        }

        public static bool IsLoggedIn {
            get => PrefList.BoolForKey( "IsLoggedIn" );
            set => PrefList.SetBool( value, "IsLoggedIn" );
        }
    }
}