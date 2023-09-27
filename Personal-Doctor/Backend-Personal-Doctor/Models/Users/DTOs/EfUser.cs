using Backend_Personal_Doctor.Models.Sessions.DTOs;
using System;
using System.Collections.Generic;

namespace Backend_Personal_Doctor.Models.Users.DTOs;

public partial class EfUser
{
    public int UserId { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Email { get; set; }

    public string Passwort { get; set; }

    public virtual ICollection<EfSession> Session { get; set; } = new List<EfSession>();
}
