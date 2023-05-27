using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class ExpenseController : BaseController<ExpenseController>
    {
        public ExpenseController(VehiCleInsuranceContext context, ILogger<ExpenseController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.Expenses.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.Expenses.Find(id);
            if (res == null)
            {
                Ok("Expense is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Expense obj)
        {
            _context.Expenses.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added expense successfully!") : BadRequest("Add expense failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Expense obj)
        {
            _context.Expenses.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated expense successfully!") : BadRequest("Update expense failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.Expenses.Find(id);
            if (res == null)
            {
                Ok("Expense is not exits");
            }
            _context.Expenses.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted expense successfully!") : BadRequest("Deleted expense failed!");
        }
    }
}
