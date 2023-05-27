using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class DicDistrictController : BaseController<DicDistrictController>
    {
        public DicDistrictController(VehiCleInsuranceContext context, ILogger<DicDistrictController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.DicDistricts.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.DicDistricts.Find(id);
            if (res == null)
            {
                Ok("District is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] DicDistrict obj)
        {
            _context.DicDistricts.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added district successfully!") : BadRequest("Add district failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] DicDistrict obj)
        {
            _context.DicDistricts.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated district successfully!") : BadRequest("Update district failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.DicDistricts.Find(id);
            if (res == null)
            {
                Ok("District is not exits");
            }
            _context.DicDistricts.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted district successfully!") : BadRequest("Deleted district failed!");
        }
    }
}
