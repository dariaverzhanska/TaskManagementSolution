using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class EmployeeService
    {
        private EmployeeRepository repository = new EmployeeRepository();

        public void AddEmployee(Employee employee) => repository.AddEmployee(employee);

        public List<Employee> GetAllEmployees() => repository.GetAllEmployees();

        public Employee? GetEmployeeById(int id)
            => repository.GetAllEmployees().FirstOrDefault(e => e.Id == id);
    }
}
