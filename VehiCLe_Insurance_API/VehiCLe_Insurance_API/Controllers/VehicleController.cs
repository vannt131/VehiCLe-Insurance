using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class VehicleController : BaseController<VehicleController>
    {
        public VehicleController(VehiCleInsuranceContext context, ILogger<VehicleController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.Vehicles.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.Vehicles.Find(id);
            if (res == null)
            {
                Ok("Vehicle is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Vehicle obj)
        {
            _context.Vehicles.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added vehicle successfully!") : BadRequest("Add vehicle failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Vehicle obj)
        {
            _context.Vehicles.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated vehicle successfully!") : BadRequest("Update vehicle failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.Vehicles.Find(id);
            if (res == null)
            {
                Ok("Vehicle is not exits");
            }
            _context.Vehicles.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted vehicle successfully!") : BadRequest("Deleted vehicle failed!");
        }
    }
}
