using System;
using System.Text.RegularExpressions;
using Facebook.CoreKit;
using Facebook.LoginKit;
using Foundation;
using Instrugram.iOS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UIKit;

namespace Instrugram.iOS.Helpers
{
    internal class FacebookLoginEventAgrs : EventArgs {
        public UserProfileModel UserProfile { get; set; }
    }

    internal class FacebookLoginManager {
        public event EventHandler<FacebookLoginEventAgrs> FacebookDidLoginSuccessfully;
        private UserProfileModel _userProfile;

        public FacebookLoginManager (LoginButton loginButton) {
            loginButton.Completed += LoginButtonOnCompleted;
        }

        private void LoginButtonOnCompleted ( object sender, LoginButtonCompletedEventArgs loginButtonCompletedEventArgs ) {
            if ( loginButtonCompletedEventArgs.Error != null || loginButtonCompletedEventArgs.Result.IsCancelled ) {
                return;
            }

            AccessToken.CurrentAccessToken = loginButtonCompletedEventArgs.Result.Token;
            GraphRequestProfile( loginButtonCompletedEventArgs.Result.Token.UserID );
        }

        private void GraphRequestProfile(string userId)
        {
            var request = new GraphRequest("/" + userId, new NSDictionary("fields", "first_name,last_name,email,gender,picture"),
                AccessToken.CurrentAccessToken.TokenString, null, "GET");

            request.Start( ( connection, result, error ) => {
                if ( result is NSDictionary userInfo ) {
                    _userProfile = new UserProfileModel {
                        Email = userInfo["email"].ToString(),
                        FacebookUserId = userInfo["id"].ToString(),
                        FirstName = userInfo["first_name"].ToString(),
                        LastName = userInfo["last_name"].ToString(),
                        Gender = userInfo["gender"].ToString(),
                        ProfilePictureUrl = "https://graph.facebook.com/" + userInfo["id"] + "/picture?type=large"
                    };
                }
            } ).LoadingFinished += (o, e) => {
                if (_userProfile != null)
                    OnFacebookDidLoginSuccessfully();
            };
        }

        //private string GetPictureUrl ( string json ) {
        //    var regex = new Regex(@"(http|ftp|https)://([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?");

        //    return regex.Match( json ).ToString();
        //}

        private void OnFacebookDidLoginSuccessfully () {
            FacebookDidLoginSuccessfully?.Invoke(this, new FacebookLoginEventAgrs {UserProfile = _userProfile});
        }
    }
}
