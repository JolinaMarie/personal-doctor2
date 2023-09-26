using Microsoft.AspNetCore.Mvc;
using Backend_Personal_Doctor.Models.Users.Logic.Interface;
using Backend_Personal_Doctor.Models.Users.DTOs;

namespace Backend_Personal_Doctor.Models.Users.API
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            this._userLogic = userLogic;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<EfUser>> GetAllUsers()
        {
            return Ok(this._userLogic.GetAllUsers());
        }

        [HttpGet]
        public ActionResult<EfUser> GetUser([FromQuery] int id)
        {
            return Ok(this._userLogic.GetUser(id));
        }

        [HttpPost]
        public ActionResult<EfUser> AddUser([FromBody] UserDtoForCreate user)
        {
            this._userLogic.AddUser(user);
            return Ok(user);
        }

        [HttpPut]
        public ActionResult UpdateMyUser([FromQuery] int id, [FromQuery] string newFirstname, [FromQuery] string newLastname, [FromQuery] string newEmail, [FromQuery] string newPassword)
        {
            this._userLogic.UpdateUser(id, newFirstname, newLastname, newEmail, newPassword);
            return Ok();
        }

        [HttpDelete]
        public ActionResult RemoveMyUser([FromQuery] int id)
        {
            this._userLogic.RemoveUser(id);
            return Ok();
        }
    }
}
