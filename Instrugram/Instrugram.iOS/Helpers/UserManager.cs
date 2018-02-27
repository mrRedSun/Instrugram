using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using Instrugram.iOS.Models;
using UIKit;
using SQLite;

namespace Instrugram.iOS.Helpers {
    class UserManager : IDisposable {
        private bool _disposed = false;

        private readonly NSUserDefaults _plist;
        private readonly SQLiteConnection _dbConnection;

        public UserManager () {
            _plist = NSUserDefaults.StandardUserDefaults;
            
            var documentsDirectoryPath = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
            var dbPath = Path.Combine( documentsDirectoryPath, "Users.db" );

            _dbConnection = new SQLiteConnection( dbPath );
            _dbConnection.CreateTable<UserProfileModel>();
        }

        public bool Login ( string email, string password ) {
            var profile = FindUser( email );

            if ( password != null && profile?.Password == password ) {
                AddProfileToUserDefaults(profile);
                return true;
            }

            return false;
        }

        public void FacebookLogin ( UserProfileModel model ) {
            var user = FindUser( model.Email );

            if ( user == null ) {
                Register( model );
                AddProfileToUserDefaults( model);
            } else {
                Delete( user.Email, user.Password );
                Register( model );
                AddProfileToUserDefaults( model );
            }

        }

        public bool Register ( UserProfileModel profile ) {
            var profileFromDb = FindUser( profile.Email );
            if ( profileFromDb == null ) {
                _dbConnection.Insert( profile );
                return true;
            } else {
                return false;
            }
        }

        public bool Delete ( string email, string password ) {
            var user = FindUser( email );

            if ( user.Password == password ) {
                _dbConnection.Delete<UserProfileModel>( user.ID );
                return true;
            } else {
                return false;
            }
        }

        private UserProfileModel FindUser ( string email ) {
            var person = _dbConnection.Find<UserProfileModel>( ( p ) => p.Email == email );
            return person;
        }

        public void UpdateCurrentUser ( UserProfileModel newProfile ) {
            var currentProfile = _dbConnection
                .Query<UserProfileModel>( "select * from UserProfileModel where ID = " +
                                          _plist.StringForKey( "ID" ) ).FirstOrDefault();

            if ( currentProfile == null ) {
                return;
            }

            var props = currentProfile.GetType().GetProperties();

            foreach ( var currentProperty in props ) {

                var value = currentProperty.GetValue(newProfile)?.ToString();
                if ( !string.IsNullOrEmpty( value ) ) {
                    if ( !(currentProperty.PropertyType == typeof(int)) ) {
                        currentProperty.SetValue( currentProfile, value );
                    }
                }
            }

            _dbConnection.RunInTransaction( () => _dbConnection.Update( currentProfile ) );
            AddProfileToUserDefaults( currentProfile );
        }

        private void AddProfileToUserDefaults ( UserProfileModel model ) {

            var props = model.GetType().GetProperties();

            foreach ( var prop in props ) {
                var value = prop.GetValue( model )?.ToString();

                if ( string.IsNullOrEmpty( value ) ) {
                    continue;
                }

                _plist.SetString( value, prop.Name );
            }
        }

        public void Dispose () {
            _dbConnection.Dispose();
            _disposed = true;
        }

        ~UserManager () {
            if ( _disposed ) {
                return;
            }

            this.Dispose();
        }
    }
}