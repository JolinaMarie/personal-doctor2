using Backend_Personal_Doctor.Models.Sessions.DTOs;
using Backend_Personal_Doctor.Models.Sessions.Persistance.Interface;

namespace Backend_Personal_Doctor.Models.Sessions.Persistance
{
    public class EfSessionsRepository : ISessionsRepository
    {
        private readonly PersonalDoctorContext _context;
        public EfSessionsRepository(PersonalDoctorContext personalDoctorContext)
        {
            _context = personalDoctorContext;
        }

        public string CreateSession(Session session)
        {

            var efSession = new EfSession
            {
                SessionId= session.SessionId,
                UserId = session.UserId,
                Expiry = session.Expiry,
                SessionKey = session.SessionKey,
            };

            _context.Sessions.Add(efSession);
            _context.SaveChanges();
            return session.SessionKey;
        }

        public Session GetSession(string sessionKey)
        {
            EfSession efSession = _context.Sessions
                .Where(Session => Session.Expiry >= DateTime.Now)
                .SingleOrDefault(Session => Session.SessionKey == sessionKey);

            return Session.FromEfSession(efSession);
        }

        public string LogoutFromSession(string sessionKey)
        {
            EfSession efSession = _context.Sessions
                 .Where(session => session.SessionKey == sessionKey)
                 .SingleOrDefault();

            _context.Sessions.Remove(efSession);
            _context.SaveChanges();

            return efSession.SessionKey;
        }

        public string ValidateSession(string sessionKey)
        {
            EfSession efSession = _context.Sessions
                .Where(session => session.SessionKey == sessionKey)
                .SingleOrDefault();

            return efSession.SessionKey;
        }
    }
}
