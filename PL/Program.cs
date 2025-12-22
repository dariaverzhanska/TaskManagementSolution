using System;
using BLL.Services;
using DAL.Entities;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MyTaskService taskService = new MyTaskService();
            EmployeeService employeeService = new EmployeeService();

            Employee emp = new Employee { Id = 1, Name = "Дар'я", Position = "Менеджер" };
            employeeService.AddEmployee(emp);

            MyTask task = new MyTask
            {
                Id = 1,
                Title = "Зробити звіт",
                Description = "Підготувати щомісячний звіт",
                AssignedTo = 1,
                Status = "Нова"
            };
            taskService.CreateTask(task);

            Console.WriteLine("Задачу успішно додано!");
            Console.ReadLine(); // щоб консоль не закрилася
        }
    }
}
