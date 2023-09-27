using Backend_Personal_Doctor.Contexts;
using Backend_Personal_Doctor.Middleware.ResultExceptionMiddleware;
using Backend_Personal_Doctor.Models.Sessions.Persistance.Interface;
using Backend_Personal_Doctor.Models.Users.DTOs;
using Backend_Personal_Doctor.Models.Users.Logic.Interface;
using Backend_Personal_Doctor.Models.Users.Persistance.Interface;

namespace Backend_Personal_Doctor.Models.Users.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionContext _sessioncontext;

        public UserLogic(IUserRepository userRepository, ISessionContext sessioncontext)
        {
            this._userRepository = userRepository;
            this._sessioncontext = sessioncontext;
        }

        public void AddUser(UserDtoForCreate user)
        {
            if (!_userRepository.IsEmailUnique(user.email))
            {
                throw new ConflictResultException("Email is already in use.");
            }

            this._userRepository.AddUser(user);
        }

        public List<User> GetAllUsers()
        {
            List<User> user = this._userRepository.GetAllUsers();
            if (user == null)
            {
                throw new NotFoundResultException($"Users konnten nicht gefunden werden.");
            }

            return user;
        }

        public User GetUser(int id)
        {
            User user = this._userRepository.GetUser(id);
            if (user == null)
            {
                throw new NotFoundResultException($"User mit der Id {id} nicht gefunden.");
            }

            return user;
        }

        public int RemoveUser(int id)
        {
            User user = this._userRepository.GetUser(id);
            if (user == null)
            {
                throw new NotFoundResultException($"User mit der Id {id} nicht gefunden.");
            }

            //Alles löschen was zum user gehört

            this._userRepository.RemoveUser(id);
            return id;
        }

        public string UpdateUser(int id, string newFirstname, string newLastname, string newEmail, string newPassword)
        {
            User user = this._userRepository.GetUser(id);

            if (user == null)
            {
                throw new NotFoundResultException($"User mit der Id {id} nicht gefunden.");
            }

           

            this._userRepository.UpdateUser(id, newFirstname, newLastname, newEmail, newPassword);
            return $"Neuer Nutzername: {newFirstname}\n" +
                   $"Neues Password: {newLastname}";
        }
    }
}
