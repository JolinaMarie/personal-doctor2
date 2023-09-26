using Backend_Personal_Doctor.Models.Sessions.DTOs;

namespace Backend_Personal_Doctor.Models.Sessions.Persistance.Interface
{
    public interface ISessionsRepository
    {
        string CreateSession(Session session);
        Session GetSession(string sessionKey);
        string LogoutFromSession(string sessionKey);
        string ValidateSession(string sessionKey);
    }
}
