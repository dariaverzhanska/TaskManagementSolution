using System;
using BLL.Services;
using DAL.Entities;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштовуємо кодування консолі для відображення кирилиці
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створюємо сервіси для роботи з задачами та співробітниками
            MyTaskService taskService = new MyTaskService();
            EmployeeService employeeService = new EmployeeService();

            // Додаємо співробітника
            Employee emp = new Employee { Id = 1, Name = "Дар'я", Position = "Менеджер" };
            employeeService.AddEmployee(emp);

            // Додаємо задачу
            MyTask task = new MyTask
            {
                Id = 1,
                Title = "Зробити звіт",
                Description = "Підготувати щомісячний звіт",
                AssignedTo = 1, // Призначена співробітнику з Id = 1
                Status = "Нова"
            };
            taskService.CreateTask(task);

            // Виводимо список співробітників
            Console.WriteLine("Список співробітників:");
            foreach (var e in employeeService.GetAllEmployees())
            {
                Console.WriteLine($"Id: {e.Id}, Name: {e.Name}, Position: {e.Position}");
            }

            Console.WriteLine();

            // Виводимо список задач для співробітника з Id = 1
            Console.WriteLine("Список задач:");
            foreach (var t in taskService.GetTasksByEmployee(1))
            {
                Console.WriteLine($"Id: {t.Id}, Title: {t.Title}, Description: {t.Description}, AssignedTo: {t.AssignedTo}, Status: {t.Status}");
            }

            // Затримка, щоб консоль залишалась відчиненою
            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}
