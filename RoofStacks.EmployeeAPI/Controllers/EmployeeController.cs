using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoofStacks.EmployeeAPI.Model;
using RoofStacks.EmployeeAPI.Services;

namespace RoofStacks.EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employees
        [HttpGet]
        [Authorize(Policy = "Rad")]
        public IActionResult Get()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }

        // GET: api/employees/1
        [HttpGet("{id}")]
        [Authorize(Policy = "Read")]
        public IActionResult Get(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // POST: api/employees
        [HttpPost]
        [Authorize(Policy = "Write")]
        public IActionResult Post([FromBody] Employee employee)
        {
            var newEmployee = _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(Get), new { id = newEmployee.Id }, newEmployee);
        }

        // PUT: api/employees/1
        [HttpPut("{id}")]
        [Authorize(Policy = "Write")]
        public IActionResult Put(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound();

            _employeeService.UpdateEmployee(updatedEmployee);
            return NoContent();
        }

        // DELETE: api/employees/1
        [HttpDelete("{id}")]
        [Authorize(Policy = "Delete")]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound();

            _employeeService.DeleteEmployee(id);
            return NoContent();
        }
    }

}
