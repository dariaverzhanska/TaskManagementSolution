using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class EmployeeRepository
    {
        private List<Employee> employees = new List<Employee>();

        public List<Employee> GetAllEmployees() => employees;

        public void AddEmployee(Employee employee) => employees.Add(employee);

        public void UpdateEmployee(Employee employee)
        {
            var existing = employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Position = employee.Position;
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null) employees.Remove(employee);
        }
    }
}
