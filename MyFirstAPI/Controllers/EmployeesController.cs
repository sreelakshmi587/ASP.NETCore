using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.EmployeeData;
using MyFirstAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Controllers
{
    
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {

            var employee = _employeeData.GetEmployee(id);
            return employee == null ? throw new ArgumentException("User not found.Please check the given id.") : (IActionResult)Ok(employee);

        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
           
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }
        
    }
}
