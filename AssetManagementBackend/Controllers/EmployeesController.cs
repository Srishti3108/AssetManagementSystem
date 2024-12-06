using AssetManagementSystem.Models;
using AssetManagementSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
   
    [EnableCors("Policy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }
       // [Authorize (Roles ="Admin")]
       // [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllEmployeeDetails()
        {
            List<Employee> employees = _service.GetAllEmployees();
            return Ok(employees);
        }
       // [Authorize(Roles = "Admin")]
        [HttpGet("{id:int}")]
        public IActionResult GetEmployeeById(int id)
        {
            Employee employee = _service.GetEmployeeById(id);
            return Ok(employee);

        }

        [HttpPost]
        public IActionResult AddEmployeeDeatils(Employee employee)
        {
            int Result = _service.AddNewEmployee(employee);
            return Ok(Result);
        }
       // [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateEmployeeDetails(Employee employee)
        {
            string result = _service.UpdateEmployee(employee);
            return Ok(result);
        }
       // [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            string result = _service.DeleteEmployee(id);
            return Ok(result);
        }
    }

}
