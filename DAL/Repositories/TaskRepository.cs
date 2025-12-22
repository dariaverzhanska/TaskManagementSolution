using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class TaskRepository
    {
        private List<Task> tasks = new List<Task>();

        public List<Task> GetAllTasks() => tasks;

        public void AddTask(Task task) => tasks.Add(task);

        public void UpdateTask(Task task)
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
    }
}
