namespace RoofStacks.EmployeeAPI.Model
{
    /// <summary>
    /// Represents an employee in the system.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the position or job title of the employee.
        /// </summary>
        public string Position { get; set; }
    }
}