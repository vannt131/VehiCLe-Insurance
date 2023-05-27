using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class UserController : BaseController<UserController>
    {
        public UserController(VehiCleInsuranceContext context, ILogger<UserController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.Users.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.Users.Find(id);
            if (res == null)
            {
                Ok("User is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] User obj)
        {
            _context.Users.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added user successfully!") : BadRequest("Add user failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User obj)
        {
            _context.Users.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated user successfully!") : BadRequest("Update user failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.Users.Find(id);
            if (res == null)
            {
                Ok("User is not exits");
            }
            _context.Users.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted user successfully!") : BadRequest("Deleted user failed!");
        }
    }
}
