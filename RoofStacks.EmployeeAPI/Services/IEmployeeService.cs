using RoofStacks.EmployeeAPI.Model;
using System.Collections.Generic;

namespace RoofStacks.EmployeeAPI.Services
{
    /// <summary>
    /// Defines the contract for services related to Employee management.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>A list of Employee entities.</returns>
        List<Employee> GetEmployees();

        /// <summary>
        /// Retrieves a specific employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The Employee entity if found; otherwise, null.</returns>
        Employee GetEmployeeById(int id);

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The new Employee entity to add.</param>
        /// <returns>The newly created Employee entity.</returns>
        Employee AddEmployee(Employee employee);

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="employee">The Employee entity with updated details.</param>
        void UpdateEmployee(Employee employee);

        /// <summary>
        /// Deletes a specific employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        void DeleteEmployee(int id);
    }
}