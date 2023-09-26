using Backend_Personal_Doctor.Middleware.ResultExceptionMiddleware.Exceptions;
using Backend_Personal_Doctor.Models.Sessions.DTOs;
using Backend_Personal_Doctor.Models.Sessions.Persistance.Interface;

namespace Backend_Personal_Doctor.Contexts
{
    public class SessionContext : ISessionContext
    {
        private readonly ISessionsRepository sessionRepository;
        private IHttpContextAccessor httpContextAccessor;

        private Session session;

        public SessionContext(ISessionsRepository sessionRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.sessionRepository = sessionRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public int GetUserId()
        {
            this.EnsureSessionLoaded();
            return this.session.userId;
        }

        public void Validate()
        {
            this.EnsureSessionLoaded();
        }

        private void EnsureSessionLoaded()
        {
            if (session == null)
            {
                string sessionKey = this.httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                Session session = sessionRepository.GetSession(sessionKey);

                if (session == null)
                {
                    throw new UnauthorizedResultException("Die Session ist abgelaufen oder nicht vorhanden.");
                }

                this.session = session;
            }
        }
    }
}
