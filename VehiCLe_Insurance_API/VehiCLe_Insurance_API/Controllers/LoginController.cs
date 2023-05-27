using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;
using Model.Models.Request;
using Common;

namespace VehiCLe_Insurance_API.Controllers
{
    public class LoginController : BaseController<LoginController>
    {
        public LoginController(VehiCleInsuranceContext context, ILogger<LoginController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromQuery] AuthenticationModel model)
        {
            var data = _context.Users.FirstOrDefault(m => m.UserName == model.UserName);
            if (data == null) return BadRequest("Username/Password incorrect");

            var isValid = model.UserName.ValidPassword(data.Salt, model.Password, data.Password);
            if (!isValid) return BadRequest("Username/password incorrect");

            var accessToken = GenerateToken(model.UserName);
            return Ok(accessToken);
        }
    }
}
