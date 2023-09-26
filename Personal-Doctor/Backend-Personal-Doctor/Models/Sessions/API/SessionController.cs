﻿using Backend_Personal_Doctor.Models.Sessions.DTOs;
using Backend_Personal_Doctor.Models.Sessions.Persistance.Interface;
using Backend_Personal_Doctor.Models.Users.DTOs;
using Backend_Personal_Doctor.Models.Users.Persistance.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Personal_Doctor.Models.Sessions.API
{
    [ApiController]
    [Route("api/sessions")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionsRepository _sessionsRepository;
        private readonly IUserRepository userRepository;

        public SessionController(ISessionsRepository sessionRepository, IUserRepository userRepository)
        {
            _sessionsRepository = sessionRepository;
            this.userRepository = userRepository;
        }


        [HttpPost("login")]
        public ActionResult<string> Login(string username, string password)
        {
            DateTime expiry = DateTime.Now.AddMinutes(20);
            if (!userRepository.DoesEmailAndPasswordExist(username, password))
            {
                return Unauthorized();
            }

            Session session = new Session();
            User user = userRepository.GetUserByEmailAndPassword(username, password);

            Guid uniqueId = Guid.NewGuid();
            string sessionKey = uniqueId.ToString();

            session.userId = user.UserId;
            session.expiry = expiry;
            session.sessionKey = sessionKey;

            _sessionsRepository.CreateSession(session);
            return Ok(sessionKey);
        }

        [HttpPost("logout")]
        public ActionResult<string> LogoutSession(string sessionKey)
        {
            try
            {
                var sessionKeyToRemove = _sessionsRepository.LogoutFromSession(sessionKey);
                return sessionKeyToRemove;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost("validate")]
        public ActionResult<bool> ValidateSession()
        {
            string sessionKey = HttpContext.Request.Headers["Authorization"];
            Session session = _sessionsRepository.GetSession(sessionKey);
            return session != null;
        }
    }
}
