﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entites;

namespace VehiCLe_Insurance_API.Controllers
{
    public class EmployeeController : BaseController<EmployeeController>
    {
        public EmployeeController(VehiCleInsuranceContext context, ILogger<EmployeeController> logger,
            IConfiguration config) : base(context, logger, config)
        {

        }

        [HttpGet]
        public IActionResult GetList()
        {
            var res = _context.Employees.ToList();
            return Ok(res);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var res = _context.Employees.Find(id);
            if (res == null)
            {
                Ok("Employee is not exits");
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Employee obj)
        {
            _context.Employees.Add(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Added employee successfully!") : BadRequest("Add employee failed!");
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Employee obj)
        {
            _context.Employees.Update(obj);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Updated employee successfully!") : BadRequest("Update employee failed!");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var res = _context.Employees.Find(id);
            if (res == null)
            {
                Ok("Employee is not exits");
            }
            _context.Employees.Remove(res);
            var eff = _context.SaveChanges();
            return eff > 0 ? Ok("Deleted employee successfully!") : BadRequest("Deleted employee failed!");
        }
    }
}
