using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class PermissionController : BaseController<PermissionController>
    {
        public PermissionController(VehiCleInsuranceContext context, ILogger<PermissionController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.Permissions.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.Permissions.Find(id);
            if (res == null)
            {
                Ok("Permission is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Permission obj)
        {
            _context.Permissions.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added permission successfully!") : BadRequest("Add permission failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Permission obj)
        {
            _context.Permissions.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated permission successfully!") : BadRequest("Update permission failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.Permissions.Find(id);
            if (res == null)
            {
                Ok("Permission is not exits");
            }
            _context.Permissions.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted permission successfully!") : BadRequest("Deleted permission failed!");
        }
    }
}
