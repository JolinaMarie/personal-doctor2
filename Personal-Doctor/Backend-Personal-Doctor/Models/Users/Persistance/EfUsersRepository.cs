using Backend_Personal_Doctor.Models.Users.DTOs;
using Backend_Personal_Doctor.Models.Users.Persistance.Interface;

namespace Backend_Personal_Doctor.Models.Users.Persistance
{
    public class EfUsersRepository : IUserRepository
    {
        private readonly PersonalDoctorContext _context;

        public EfUsersRepository(PersonalDoctorContext context)
        {
            this._context = context;
        }

        public void AddUser(UserDtoForCreate user)
        {
            var efUser = new EfUser
            {
                Firstname = user.firstname,
                Lastname = user.lastname,
                Email = user.email,
                Passwort = user.password

            };

            _context.Users.Add(efUser);
            _context.SaveChanges();
        }

        public bool DoesEmailAndPasswordExist(string email, string password)
        {
            EfUser efUser = _context.Users
                  .Where(efUser => efUser.Email == email)
                  .Where(efUser => efUser.Passwort == password)
                  .SingleOrDefault();

            return efUser != null;
        }

        public bool IsEmailUnique(string email)
        {
            EfUser efUser = _context.Users
                .Where(efUser => efUser.Email == email)
                .SingleOrDefault();

            return efUser == null;
        }

        public List<User> GetAllUsers()
        {
            List<User> efUser = _context.Users
               .Select(efUser => User.FromEfUser(efUser))
               .ToList();

            return efUser;
        }

        public User GetUser(int id)
        {
            EfUser efUser = _context.Users
                .Single(efUser => efUser.UserId == id);

            return User.FromEfUser(efUser);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            EfUser efUser = _context.Users
                .Where(efUser => efUser.Email == email)
                .Where(efUser => efUser.Passwort == password)
                .SingleOrDefault();

            return User.FromEfUser(efUser);
        }

        public int RemoveUser(int id)
        {
            EfUser efUser = _context.Users
                 .Where(efUser => efUser.UserId == id)
                 .Single();



            _context.Users.Remove(efUser);
            _context.SaveChanges();

            return efUser.UserId;
        }

        public string UpdateUser(int id, string newFirstname, string newLastname, string newEmail, string newPassword)
        {
            EfUser efUser = _context.Users
                 .Where(efUser => efUser.UserId == id)
                 .Single();

            efUser.Firstname = newFirstname;
            efUser.Lastname = newLastname;
            efUser.Email = newEmail;
            efUser.Passwort = newPassword;
            _context.SaveChanges();

            return $"{efUser.Firstname}, {efUser.Lastname}";
        }
    }
}
