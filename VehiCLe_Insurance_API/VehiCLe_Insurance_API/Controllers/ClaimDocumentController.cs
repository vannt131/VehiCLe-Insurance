using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class ClaimDocumentController : BaseController<ClaimDocumentController>
    {
        public ClaimDocumentController(VehiCleInsuranceContext context, ILogger<ClaimDocumentController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.ClaimDocuments.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.ClaimDocuments.Find(id);
            if (res == null)
            {
                Ok("Bill is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ClaimDocument obj)
        {
            _context.ClaimDocuments.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added claim documents successfully!") : BadRequest("Add claim documents failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] ClaimDocument obj)
        {
            _context.ClaimDocuments.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated claim documents successfully!") : BadRequest("Update claim documents failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.ClaimDocuments.Find(id);
            if (res == null)
            {
                Ok("Claim documents is not exits");
            }
            _context.ClaimDocuments.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted claim documents successfully!") : BadRequest("Deleted claim documents failed!");
        }
    }
}
