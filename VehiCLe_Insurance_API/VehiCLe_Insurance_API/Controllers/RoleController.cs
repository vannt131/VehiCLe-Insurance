using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class RoleController : BaseController<RoleController>
    {
        public RoleController(VehiCleInsuranceContext context, ILogger<RoleController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.Roles.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.Roles.Find(id);
            if (res == null)
            {
                Ok("Role is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Role obj)
        {
            _context.Roles.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added role successfully!") : BadRequest("Add role failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Role obj)
        {
            _context.Roles.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated role successfully!") : BadRequest("Update role failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.Roles.Find(id);
            if (res == null)
            {
                Ok("Role is not exits");
            }
            _context.Roles.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted role successfully!") : BadRequest("Deleted role failed!");
        }
    }
}
