namespace Backend_Personal_Doctor.Models.Sessions.DTOs
{
    public class Session
    {
        public int SessionId { get; set; }
        public int userId { get; set; }
        public string sessionKey { get; set; }
        public DateTime expiry { get; set; }

        internal static Session FromEfSession(EfSession efSession)
        {
            if (efSession == null)
            {
                return null;
            }

            return new Session()
            {
                SessionId = efSession.SessionId,
                userId = efSession.UserId,
                sessionKey = efSession.SessionKey,
                expiry = efSession.Expiry,
            };
        }
    }
}
