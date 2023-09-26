using System.ComponentModel.DataAnnotations;

namespace Backend_Personal_Doctor.Models.Users.DTOs
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Passwort { get; set; }

        internal static User FromEfUser(EfUser efUser)
        {
            return new User()
            {
                UserId = efUser.UserId,
                Firstname = efUser.Firstname,
                Lastname = efUser.Lastname,
                Email = efUser.Email,
                Passwort = efUser.Passwort,
            };
        }
    }
}
