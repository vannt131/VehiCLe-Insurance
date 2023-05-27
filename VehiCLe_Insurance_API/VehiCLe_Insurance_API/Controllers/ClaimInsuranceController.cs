using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class ClaimInsuranceController : BaseController<ClaimInsuranceController>
    {
        public ClaimInsuranceController(VehiCleInsuranceContext context, ILogger<ClaimInsuranceController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.ClaimInsurances.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.ClaimInsurances.Find(id);
            if (res == null)
            {
                Ok("Claim insurance is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ClaimInsurance obj)
        {
            _context.ClaimInsurances.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added claim insurance successfully!") : BadRequest("Add claim insurance failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] ClaimInsurance obj)
        {
            _context.ClaimInsurances.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated claim insurance successfully!") : BadRequest("Update claim insurance failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.ClaimInsurances.Find(id);
            if (res == null)
            {
                Ok("Claim insurance is not exits");
            }
            _context.ClaimInsurances.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted claim insurance successfully!") : BadRequest("Deleted claim insurance failed!");
        }
    }
}
