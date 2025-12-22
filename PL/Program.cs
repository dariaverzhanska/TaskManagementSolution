using System;
using BLL.Services;
using DAL.Entities;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштовуємо консоль на UTF-8, щоб відображати кирилицю
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створюємо сервіси
            MyTaskService taskService = new MyTaskService();
            EmployeeService employeeService = new EmployeeService();

            // Додаємо співробітників
            Employee emp1 = new Employee { Id = 1, Name = "Дар'я", Position = "Менеджер" };
            Employee emp2 = new Employee { Id = 2, Name = "Іван", Position = "Розробник" };
            Employee emp3 = new Employee { Id = 3, Name = "Олена", Position = "Менеджер" };

            employeeService.AddEmployee(emp1);
            employeeService.AddEmployee(emp2);
            employeeService.AddEmployee(emp3);

            // Додаємо задачі
            MyTask task1 = new MyTask { Id = 1, Title = "Зробити звіт", Description = "Підготувати щомісячний звіт", AssignedTo = 1, Status = "Нова" };
            MyTask task2 = new MyTask { Id = 2, Title = "Код ревью", Description = "Перевірити новий функціонал", AssignedTo = 2, Status = "В процесі" };
            MyTask task3 = new MyTask { Id = 3, Title = "Зробити презентацію", Description = "Підготувати слайди для клієнта", AssignedTo = 1, Status = "Нова" };

            taskService.CreateTask(task1);
            taskService.CreateTask(task2);
            taskService.CreateTask(task3);

            // --------------------------
            // Виводимо всіх співробітників
            Console.WriteLine("Список співробітників:");
            foreach (var e in employeeService.GetAllEmployees())
            {
                Console.WriteLine($"Id: {e.Id}, Name: {e.Name}, Position: {e.Position}");
            }

            Console.WriteLine();

            // --------------------------
            // Використовуємо нові методи MyTaskRepository через сервіс
            Console.WriteLine("Задачі зі статусом 'Нова':");
            foreach (var t in taskService.GetTasksByStatus("Нова"))
            {
                Console.WriteLine($"Id: {t.Id}, Title: {t.Title}, AssignedTo: {t.AssignedTo}, Status: {t.Status}");
            }

            Console.WriteLine();

            Console.WriteLine("Задачі, де в заголовку є слово 'Зробити':");
            foreach (var t in taskService.GetTasksByTitle("Зробити"))
            {
                Console.WriteLine($"Id: {t.Id}, Title: {t.Title}, AssignedTo: {t.AssignedTo}, Status: {t.Status}");
            }

            Console.WriteLine();

            // --------------------------
            // Використовуємо нові методи EmployeeRepository через сервіс
            Console.WriteLine("Шукаємо співробітника на ім'я 'Дар'я':");
            var empSearch = employeeService.GetEmployeeByName("Дар'я");
            if (empSearch != null)
            {
                Console.WriteLine($"Id: {empSearch.Id}, Name: {empSearch.Name}, Position: {empSearch.Position}");
            }

            Console.WriteLine();

            Console.WriteLine("Унікальні посади співробітників:");
            foreach (var pos in employeeService.GetAllPositions())
            {
                Console.WriteLine(pos);
            }

            // Затримка консолі
            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }
    }
}
