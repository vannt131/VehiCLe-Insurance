using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class HistorySendingController : BaseController<HistorySendingController>
    {
        public HistorySendingController(VehiCleInsuranceContext context, ILogger<HistorySendingController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.HistorySendings.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.HistorySendings.Find(id);
            if (res == null)
            {
                Ok("History sending is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] HistorySending obj)
        {
            _context.HistorySendings.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added history sending successfully!") : BadRequest("Add history sending failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] HistorySending obj)
        {
            _context.HistorySendings.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated history sending successfully!") : BadRequest("Update history sending failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.HistorySendings.Find(id);
            if (res == null)
            {
                Ok("History sending is not exits");
            }
            _context.HistorySendings.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted history sending successfully!") : BadRequest("Deleted history sending failed!");
        }
    }
}
