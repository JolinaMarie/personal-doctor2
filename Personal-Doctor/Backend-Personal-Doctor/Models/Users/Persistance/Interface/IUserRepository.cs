using Backend_Personal_Doctor.Models.Users.DTOs;

namespace Backend_Personal_Doctor.Models.Users.Persistance.Interface
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUser(int id);
        void AddUser(UserDtoForCreate user);
        string UpdateUser(int id, string newFirstname, string newLastname, string newEmail, string newPassword);
        int RemoveUser(int id);
        User GetUserByEmailAndPassword(string email, string password);
        bool DoesEmailAndPasswordExist(string email, string password);
    }
}
