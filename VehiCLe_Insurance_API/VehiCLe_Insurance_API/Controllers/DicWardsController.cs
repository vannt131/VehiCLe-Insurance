using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class DicWardsController : BaseController<DicWardsController>
    {
        public DicWardsController(VehiCleInsuranceContext context, ILogger<DicWardsController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.DicWards.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.DicWards.Find(id);
            if (res == null)
            {
                Ok("Ward is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] DicWard obj)
        {
            _context.DicWards.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added ward successfully!") : BadRequest("Add ward failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] DicWard obj)
        {
            _context.DicWards.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated ward successfully!") : BadRequest("Update ward failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.DicWards.Find(id);
            if (res == null)
            {
                Ok("Ward is not exits");
            }
            _context.DicWards.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted ward successfully!") : BadRequest("Deleted ward failed!");
        }
    }
}
