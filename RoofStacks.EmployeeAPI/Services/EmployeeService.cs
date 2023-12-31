﻿using RoofStacks.EmployeeAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace RoofStacks.EmployeeAPI.Services
{
    /// <summary>
    /// Provides services related to Employee management.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Static list of employees for demonstration purposes.
        /// </summary>
        public static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Ali", LastName = "Yılmaz", Position = "Mühendis" },
            new Employee { Id = 2, FirstName = "Ayşe", LastName = "Kara", Position = "Yönetici" },
            new Employee { Id = 3, FirstName = "Mehmet", LastName = "Beyaz", Position = "Analist" },
            new Employee { Id = 4, FirstName = "Elif", LastName = "Doğan", Position = "Satış Temsilcisi" }
        };

        /// <summary>
        /// Retrieves all employees.
        /// </summary>
        /// <returns>List of employees.</returns>
        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        /// <summary>
        /// Retrieves an employee by their ID.
        /// </summary>
        /// <param name="id">Employee ID.</param>
        /// <returns>The employee if found; otherwise, null.</returns>
        public Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The new Employee to add.</param>
        /// <returns>The newly added employee.</returns>
        public Employee AddEmployee(Employee employee)
        {
            var maxId = _employees.Any() ? _employees.Max(e => e.Id) : 0;
            employee.Id = maxId + 1;
            _employees.Add(employee);
            return employee;
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="updatedEmployee">The updated Employee details.</param>
        public void UpdateEmployee(Employee updatedEmployee)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = updatedEmployee.FirstName;
                existingEmployee.LastName = updatedEmployee.LastName;
                existingEmployee.Position = updatedEmployee.Position;
            }
        }

        /// <summary>
        /// Deletes an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        public void DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}
