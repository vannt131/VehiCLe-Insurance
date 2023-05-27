using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class InsurancePolicyController : BaseController<InsurancePolicyController>
    {
        public InsurancePolicyController(VehiCleInsuranceContext context, ILogger<InsurancePolicyController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.InsurancePolicies.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.InsurancePolicies.Find(id);
            if (res == null)
            {
                Ok("Insurance policy is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] InsurancePolicy obj)
        {
            _context.InsurancePolicies.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added insurance policy successfully!") : BadRequest("Add insurance policy failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] InsurancePolicy obj)
        {
            _context.InsurancePolicies.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated insurance policy successfully!") : BadRequest("Update insurance policy failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.InsurancePolicies.Find(id);
            if (res == null)
            {
                Ok("Insurance policy is not exits");
            }
            _context.InsurancePolicies.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted insurance policy successfully!") : BadRequest("Deleted insurance policy failed!");
        }
    }
}
