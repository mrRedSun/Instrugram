using SQLite;

namespace Instrugram.iOS.Models
{
    class UserProfileModel 
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }

        public string FacebookUserId { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public string ProfilePictureUrl { get; set; }          

        public string Password { get; set; }
        public string Email { get; set; }
    }
}