using System;
using Facebook.CoreKit;
using Foundation;
using Instrugram.iOS.Models;

namespace Instrugram.iOS.Helpers
{
    internal class FacebookLoginEventAgrs : EventArgs {
        public UserProfileModel UserProfile { get; set; }
    }

    internal class FacebookLoginManager {

        public event EventHandler<FacebookLoginEventAgrs> FacebookDidLoginSuccessfully;
        private UserProfileModel _userProfile;


        public FacebookLoginManager () {
            Profile.Notifications.ObserveDidChange( OnProfileDidChange );
        }

        private void OnProfileDidChange ( object sender, ProfileDidChangeEventArgs e ) {
            if ( e.NewProfile == null )
                return;

            var request = new GraphRequest( "/" + e.NewProfile.UserID, new NSDictionary( "fields", "first_name,last_name,email,gender" ), AccessToken.CurrentAccessToken.TokenString, null, "GET" );
            request.Start( ( connection, result, error ) => {
                if (result is NSDictionary userInfo)
                {
                    _userProfile = new UserProfileModel
                    {
                        Email = userInfo["email"] as NSString,
                        FacebookUserId = userInfo["id"] as NSString,
                        FirstName = userInfo["first_name"] as NSString,
                        LastName = userInfo["last_name"] as NSString,
                        Gender = userInfo["gender"] as NSString
                    };
                }
            } );

            if (_userProfile != null)
                OnFacebookDidLoginSuccessfully();
        }

        private void OnFacebookDidLoginSuccessfully () {
            FacebookDidLoginSuccessfully?.Invoke(this, new FacebookLoginEventAgrs {UserProfile = _userProfile});
        }
    }
}
