using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class FeatureController : BaseController<FeatureController>
    {
        public FeatureController(VehiCleInsuranceContext context, ILogger<FeatureController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.Features.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.Features.Find(id);
            if (res == null)
            {
                Ok("Feature is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Feature obj)
        {
            _context.Features.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added feature successfully!") : BadRequest("Add feature failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Feature obj)
        {
            _context.Features.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated feature successfully!") : BadRequest("Update feature failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.Features.Find(id);
            if (res == null)
            {
                Ok("Feature is not exits");
            }
            _context.Features.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted feature successfully!") : BadRequest("Deleted feature failed!");
        }
    }
}
