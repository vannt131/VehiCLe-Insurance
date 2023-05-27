using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class CustomerController : BaseController<CustomerController>
    {
        public CustomerController(VehiCleInsuranceContext context, ILogger<CustomerController> logger,
            IConfiguration config) : base( context ,logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.Customers.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.Customers.Find(id);
            if (res == null)
            {
                Ok("Customer is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Customer obj)
        {
            _context.Customers.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added customer successfully!") : BadRequest("Add customer failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Customer obj)
        {
            _context.Customers.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated customer successfully!") : BadRequest("Update customer failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.Customers.Find(id);
            if (res == null)
            {
                Ok("Customer is not exits");
            }
            _context.Customers.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted customer successfully!") : BadRequest("Deleted customer failed!");
        }
    }
}
