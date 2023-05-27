using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class InsuranceInfoController : BaseController<InsuranceInfoController>
    {
        public InsuranceInfoController(VehiCleInsuranceContext context, ILogger<InsuranceInfoController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.InsuranceInfos.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.InsuranceInfos.Find(id);
            if (res == null)
            {
                Ok("Insurance information is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] InsuranceInfo obj)
        {
            _context.InsuranceInfos.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added insurance information successfully!") : BadRequest("Add insurance information failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] InsuranceInfo obj)
        {
            _context.InsuranceInfos.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated insurance information successfully!") : BadRequest("Update insurance information failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.InsuranceInfos.Find(id);
            if (res == null)
            {
                Ok("Insurance information is not exits");
            }
            _context.InsuranceInfos.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted insurance information successfully!") : BadRequest("Deleted insurance information failed!");
        }
    }
}
