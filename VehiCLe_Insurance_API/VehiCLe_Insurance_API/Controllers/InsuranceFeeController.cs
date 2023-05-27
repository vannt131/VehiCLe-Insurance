using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class InsuranceFeeController : BaseController<InsuranceFeeController>
    {
            public InsuranceFeeController(VehiCleInsuranceContext context, ILogger<InsuranceFeeController> logger,
                IConfiguration config) : base(context, logger, config)
            {

            }

            [HttpGet]
            public IActionResult GetList()
            {
                var res = _context.InsuranceFees.ToList();
                return Ok(res);
            }

            [HttpGet("{id:int}")]
            public IActionResult GetDetail(int id)
            {
                var res = _context.InsuranceFees.Find(id);
                if (res == null)
                {
                    Ok("Insurance fess is not exits");
                }
                return Ok(res);
            }

            [HttpPost]
            public IActionResult Add([FromBody] InsuranceFee obj)
            {
                _context.InsuranceFees.Add(obj);
                var eff = _context.SaveChanges();
                return eff > 0 ? Ok("Added insurance fee successfully!") : BadRequest("Add insurance fee failed!");
            }

            [HttpPut]
            public IActionResult Edit([FromBody] InsuranceFee obj)
            {
                _context.InsuranceFees.Update(obj);
                var eff = _context.SaveChanges();
                return eff > 0 ? Ok("Updated insurance fee successfully!") : BadRequest("Update insurance fee failed!");
            }

            [HttpDelete("{id:int}")]
            public IActionResult Delete(int id)
            {
                var res = _context.InsuranceFees.Find(id);
                if (res == null)
                {
                    Ok("Insurance fee is not exits");
                }
                _context.InsuranceFees.Remove(res);
                var eff = _context.SaveChanges();
                return eff > 0 ? Ok("Deleted insurance fee successfully!") : BadRequest("Deleted insurance fee failed!");
            }
    }
}
