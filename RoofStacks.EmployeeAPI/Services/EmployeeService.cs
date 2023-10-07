using RoofStacks.EmployeeAPI.Model;

namespace RoofStacks.EmployeeAPI.Services
{

    public class EmployeeService : IEmployeeService
    {
        public static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Ali", LastName = "Yılmaz", Position = "Mühendis" },
            new Employee { Id = 2, FirstName = "Ayşe", LastName = "Kara", Position = "Yönetici" },
            new Employee { Id = 3, FirstName = "Mehmet", LastName = "Beyaz", Position = "Analist" },
            new Employee { Id = 4, FirstName = "Elif", LastName = "Doğan", Position = "Satış Temsilcisi" }
        };

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee AddEmployee(Employee employee)
        {
            var maxId = _employees.Any() ? _employees.Max(e => e.Id) : 0;
            employee.Id = maxId + 1;
            _employees.Add(employee);
            return employee;
        }

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

