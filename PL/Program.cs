using System;
using BLL.Services;
using DAL.Entities;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskService taskService = new TaskService();
            EmployeeService employeeService = new EmployeeService();

            Employee emp = new Employee { Id = 1, Name = "Дар'я", Position = "Менеджер" };
            employeeService.AddEmployee(emp);

            Task task = new Task { Id = 1, Title = "Зробити звіт", AssignedTo = 1, Status = "Нова" };
            taskService.CreateTask(task);

            Console.WriteLine("Задачу успішно додано!");
        }
    }
}
