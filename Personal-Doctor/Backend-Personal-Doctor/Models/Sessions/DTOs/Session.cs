namespace Backend_Personal_Doctor.Models.Sessions.DTOs
{
    public class Session
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public string SessionKey { get; set; }
        public DateTime Expiry { get; set; }

        internal static Session FromEfSession(EfSession efSession)
        {
            if (efSession == null)
            {
                return null;
            }

            return new Session()
            {
                SessionId = efSession.SessionId,
                UserId = efSession.UserId,
                SessionKey = efSession.SessionKey,
                Expiry = efSession.Expiry,
            };
        }
    }
}
