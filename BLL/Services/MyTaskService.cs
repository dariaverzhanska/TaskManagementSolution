using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class MyTaskService
    {
        private MyTaskRepository repository = new MyTaskRepository();

        public void CreateTask(MyTask task) => repository.AddTask(task);

        public void CompleteTask(int id)
        {
            var task = repository.GetAllTasks().FirstOrDefault(t => t.Id == id);
            if (task != null) task.Status = "Completed";
        }

        public List<MyTask> GetTasksByEmployee(int employeeId)
            => repository.GetAllTasks().Where(t => t.AssignedTo == employeeId).ToList();
    }
}
