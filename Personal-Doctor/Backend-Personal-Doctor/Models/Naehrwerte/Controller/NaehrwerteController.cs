using Backend_Personal_Doctor.Models.Naehrwerte.DTOs;
using Backend_Personal_Doctor.Models.Naehrwerte.Logic.Interface;
using Backend_Personal_Doctor.Models.Users.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Personal_Doctor.Models.Naehrwerte.Controller
{
    [Route("api/naehrwerte")]
    [ApiController]
    public class NaehrwerteController : ControllerBase
    {
        private readonly INaehrwertLogic _naehrwertLogic;

        public NaehrwerteController(INaehrwertLogic naehrwertLogic)
        {
            this._naehrwertLogic = naehrwertLogic;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<EfNaehrwert>> GetAllNaehrwerte()
        {
            return Ok(this._naehrwertLogic.GetAllNaehrwerte());
        }

        [HttpGet]
        public ActionResult<EfUser> GetNaehrwerte([FromQuery] int id)
        {
            return Ok(this._naehrwertLogic.GetNaehrwert(id));
        }
    }
}
