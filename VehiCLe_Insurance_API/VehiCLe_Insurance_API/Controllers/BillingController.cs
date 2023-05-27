using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class BillingController : BaseController<BillingController>
    {
        public BillingController(VehiCleInsuranceContext context, ILogger<BillingController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.Billings.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.Billings.Find(id);
            if (res == null)
            {
                Ok("Bill is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Billing obj)
        {
            _context.Billings.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added bill successfully!") : BadRequest("Add bill failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Billing obj)
        {
            _context.Billings.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated bill successfully!") : BadRequest("Update bill failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.Billings.Find(id);
            if (res == null)
            {
                Ok("Bill is not exits");
            }
            _context.Billings.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted bill successfully!") : BadRequest("Deleted bill failed!");
        }
    }
}
