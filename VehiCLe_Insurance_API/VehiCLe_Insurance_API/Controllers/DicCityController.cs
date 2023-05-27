using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class DicCityController : BaseController<DicCityController>
    {
        public DicCityController(VehiCleInsuranceContext context, ILogger<DicCityController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.DicCities.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.DicCities.Find(id);
            if (res == null)
            {
                Ok("City is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] DicCity obj)
        {
            _context.DicCities.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added city successfully!") : BadRequest("Add city failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] DicCity obj)
        {
            _context.DicCities.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated city successfully!") : BadRequest("Update city failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.DicCities.Find(id);
            if (res == null)
            {
                Ok("City is not exits");
            }
            _context.DicCities.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted city successfully!") : BadRequest("Deleted city failed!");
        }
    }
}
