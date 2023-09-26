using Backend_Personal_Doctor.Models.Users.DTOs;

namespace Backend_Personal_Doctor.Models.Users.Logic.Interface
{
    public interface IUserLogic
    {
        void AddUser(UserDtoForCreate user);
        List<User> GetAllUsers();
        User GetUser(int id);
        int RemoveUser(int id);
        string UpdateUser(int id, string newFirstname, string newLastname, string newEmail, string newPassword);
    }

}