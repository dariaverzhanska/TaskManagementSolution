using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class MyTaskRepository
    {
        private List<MyTask> tasks = new List<MyTask>();

        public List<MyTask> GetAllTasks() => tasks;

        public void AddTask(MyTask task) => tasks.Add(task);

        public void UpdateTask(MyTask task)
        {
            var existing = tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existing != null)
            {
                existing.Title = task.Title;
                existing.Description = task.Description;
                existing.AssignedTo = task.AssignedTo;
                existing.Status = task.Status;
            }
        }

        public void DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null) tasks.Remove(task);
        }

        
        // Нові методи для пошуку/фільтрації

        public List<MyTask> GetTasksByStatus(string status)
        {
            return tasks.Where(t => t.Status == status).ToList();
        }

        public List<MyTask> GetTasksByTitle(string keyword)
        {
            return tasks.Where(t => t.Title.Contains(keyword)).ToList();
        }
    }
}
