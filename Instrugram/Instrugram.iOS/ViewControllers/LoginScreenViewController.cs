using System;
using AVFoundation;
using CoreGraphics;
using CoreMedia;
using Facebook.LoginKit;
using Foundation;
using Instrugram.iOS.Helpers;
using Instrugram.iOS.Models;
using UIKit;

namespace Instrugram.iOS.ViewControllers {
    public partial class LoginScreenViewController : UIViewController {

        private LoginButton _facebookLoginButton;
        private FacebookLoginManager _facebookLoginManager;
        private readonly string[] _facebookReadPermissoions = {
            "email",
            "public_profile",
            "user_friends",
        };

        private AVPlayer _player;
        private AVPlayerLayer _playerLayer;
        private AVAsset _currentVideoAsset;
        private AVPlayerItem _currentVideoPlayerItem;

        private UIVisualEffectView _blurEffectView;

        private NSObject _videoEndedNotificationToken;

        public LoginScreenViewController ( IntPtr handle ) : base( handle ) {
        }

        public override void ViewDidLoad ()
        {
            if (AppSettingsManager.IsLoggedIn)
            {
                PerformSegue("MainScreenSegue", this);
                return;
            }

            base.ViewDidLoad();
    
            SetupFacebook();
            SetupMainViews();
            //SetupVideoPlayer();
            SetupBlurEffect();
            //_player.Play();
        }

        private void SetupFacebook () {
            _facebookLoginButton = new LoginButton
            {
                Frame = new CGRect((View.Frame.Width - LoginButtonView.Frame.Width) / 2,
                    LoginButtonView.Frame.Y - LoginButtonView.Frame.Height - 20,
                    LoginButtonView.Frame.Width / 2 - 20,
                    LoginButtonView.Frame.Height),
                LoginBehavior = LoginBehavior.Native,
                ReadPermissions = _facebookReadPermissoions
            };

            _facebookLoginManager = new FacebookLoginManager(_facebookLoginButton);
            _facebookLoginManager.FacebookDidLoginSuccessfully += ( o, e ) => { Login( e.UserProfile ); };
            

            View.AddSubviews(_facebookLoginButton);
        }

        private void SetupMainViews() {
            NavigationController.NavigationBar.Hidden = true;
            NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
            NavigationController.SetNeedsStatusBarAppearanceUpdate();

            LoginButtonView.TitleLabel.Font = UIFont.SystemFontOfSize(LoginButtonView.Frame.Height - 10, UIFontWeight.Thin);
            RegisterButtonView.TitleLabel.Font = LoginButtonView.Font;

            LogoLabelView.AdjustsFontSizeToFitWidth = true;

            foreach ( var subview in this.View.Subviews ) {
                subview.Alpha = 0;
            }

            UpdateViewConstraints();
        }

        private void SetupBlurEffect () {
            var blurEffect = UIBlurEffect.FromStyle( UIBlurEffectStyle.Dark ); //new UIBlurEffect();
            _blurEffectView = new UIVisualEffectView( blurEffect ) {
                Frame = this.View.Frame,
                AutoresizingMask = UIViewAutoresizing.All,
                Alpha = 0
            };
            
            this.VideoPlayerContainerView.AddSubview(_blurEffectView);

            UIView.Animate( 2, 2, UIViewAnimationOptions.TransitionNone, LoginScreenAnimatios, null );
        }

        private void LoginScreenAnimatios () {
            _blurEffectView.Alpha = 0.9f;

            foreach ( var subview in View.Subviews ) {
                subview.Alpha = 1;
            }
        }

        private void SetupVideoPlayer () {
            VideoPlayerContainerView.Alpha = 1;
            VideoPlayerContainerView.Frame = View.Frame;

            _currentVideoAsset = AVAsset.FromUrl( NSUrl.FromFilename("ElectricGuitarPlay.mp4") );
            _currentVideoPlayerItem = new AVPlayerItem( _currentVideoAsset );

            _player = new AVPlayer( _currentVideoPlayerItem );

            _playerLayer = AVPlayerLayer.FromPlayer( _player );
            _playerLayer.VideoGravity = AVLayerVideoGravity.ResizeAspectFill;
            _playerLayer.Frame = this.View.Frame;
            VideoPlayerContainerView.Layer.AddSublayer( _playerLayer );

            _videoEndedNotificationToken = NSNotificationCenter.DefaultCenter.AddObserver( (NSString) "AVPlayerItemDidPlayToEndTimeNotification", RevindVideo, _currentVideoPlayerItem );
            _player.ActionAtItemEnd = AVPlayerActionAtItemEnd.None;
            _player.Muted = true;
        }

        private void RevindVideo ( NSNotification o ) {
            _currentVideoPlayerItem.Seek( CMTime.Zero );
        }

        private void Login ( UserProfileModel userModel ) {
            using ( var userManager = new UserManager() ) {
                userManager.FacebookLogin( userModel );
            }

            PerformSegue("MainScreenSegue", this);

            _videoEndedNotificationToken?.Dispose();
            AppSettingsManager.IsLoggedIn = true;
        }


    }
}