using Backend_Personal_Doctor.Models.Users.DTOs;
using System;
using System.Collections.Generic;

namespace Backend_Personal_Doctor.Models.Sessions.DTOs;

public partial class EfSession
{
    public int SessionId { get; set; }

    public int UserId { get; set; }

    public string SessionKey { get; set; }

    public DateTime Expiry { get; set; }
    public virtual EfUser User { get; set; }
}
