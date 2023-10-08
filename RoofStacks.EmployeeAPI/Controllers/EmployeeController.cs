using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoofStacks.EmployeeAPI.Enums;
using RoofStacks.EmployeeAPI.Model;
using RoofStacks.EmployeeAPI.Services;

namespace RoofStacks.EmployeeAPI.Controllers
{
    /// <summary>
    /// Controller responsible for managing Employee data.
    /// Provides endpoints for CRUD operations on Employee entities.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// Initializes a new instance of the EmployeesController class.
        ///
        /// Requires the user to have 'Read' permission.
        /// </summary>
        /// <param name="employeeService">The service to handle Employee data.</param>
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Retrieves all employees.
        /// Requires the user to have 'Read' permission.
        /// </summary>
        /// <returns>A list of Employee entities.</returns>
        [HttpGet]
        [Authorize(Policy = AuthorizePolicys.Read)]
        public IActionResult Get()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }

        /// <summary>
        /// Retrieves a specific employee by their ID.
        /// Requires the user to have 'Read' permission.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The Employee entity.</returns>
        [HttpGet("{id}")]
        [Authorize(Policy = AuthorizePolicys.Read)]
        public IActionResult Get(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        /// <summary>
        /// Adds a new employee.
        /// Requires the user to have 'Write' permission.
        /// </summary>
        /// <param name="employee">The new Employee entity to add.</param>
        /// <returns>The newly created Employee entity.</returns>
        [HttpPost]
        [Authorize(Policy = AuthorizePolicys.Write)]
        public IActionResult Post([FromBody] Employee employee)
        {
            var newEmployee = _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(Get), new { id = newEmployee.Id }, newEmployee);
        }

        /// <summary>
        /// Updates an existing employee.
        /// Requires the user to have 'Write' permission.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="updatedEmployee">The updated Employee entity.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        [Authorize(Policy = AuthorizePolicys.Write)]
        public IActionResult Put(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
                return NotFound();

            _employeeService.UpdateEmployee(updatedEmployee);
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific employee by their ID.
        /// Requires the user to have 'Delete' permission.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = AuthorizePolicys.Delete)]
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
