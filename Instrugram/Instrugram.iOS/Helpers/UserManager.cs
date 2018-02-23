using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;

using Foundation;
using Instrugram.iOS.Models;
using UIKit;
using SQLite;

namespace Instrugram.iOS.Helpers {
    class UserManager : IDisposable {
        private bool disposed = false;

        private SQLiteConnection _dbConnection;

        public UserManager () {
            var documentsDirectoryPath = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
            var dbPath = Path.Combine( documentsDirectoryPath, "Users.db" );

            _dbConnection = new SQLiteConnection( dbPath );
            _dbConnection.CreateTable<UserProfileModel>();
        }

        public bool Login ( string email, string password ) {
            var profile = FindUser( email );

            if ( profile?.Password == password ) {


            }

            return false;
        }


        public void FacebookLogin ( UserProfileModel model ) {
            var user = FindUser( model.Email );

            if ( user == null ) {
                Register( model );
            }

            AddProfileToUserDefaults( model );
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

        private void AddProfileToUserDefaults ( UserProfileModel model ) {
            var plist = NSUserDefaults.StandardUserDefaults;

            var props = model.GetType().GetProperties();

            foreach ( var prop in props ) {
                var value = prop.GetValue( model ).ToString();
                plist.SetString( value, prop.Name );
            }
        }


        public void Dispose () {
            _dbConnection.Dispose();
            disposed = true;
        }

        ~UserManager () {
            if ( disposed ) {
                return;
            }

            this.Dispose();
        }
    }
}