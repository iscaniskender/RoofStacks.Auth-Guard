using RoofStacks.EmployeeAPI.Model;

namespace RoofStacks.EmployeeAPI.Services
{
    public interface IEmployeeService
    { 
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
