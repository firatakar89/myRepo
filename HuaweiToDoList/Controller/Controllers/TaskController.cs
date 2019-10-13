
using Data.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace Controller.Controllers
{
    public class TaskController :BaseController
    {
        /// <summary>
        /// Add To Do Item
        /// </summary>
        /// <param name="task"></param>
        public void Add(Task task)
        {


            //dbContext.lists.Attach(task.list);
            //dbContext.users.Attach(task.list.user);
            DbContext.tasks.Add(task);
            DbContext.SaveChanges();
        }
        /// <summary>
        /// Mark Task as complete
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public bool MarkAsComplete(Task task)
        {
            try
            {
                Task _task = DbContext.tasks.FirstOrDefault(t => t == task);
                _task.isCompleted = true;
                DbContext.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
            
        }
        /// <summary>
        /// Remove Task
        /// </summary>
        /// <param name="task"></param>
        public void Remove(Task task)
        {
            DbContext.tasks.Remove(task);
            DbContext.SaveChanges();
        }

        public List<Task> getTasksByListId(int id)
        {
            return DbContext.tasks.Where(t => t.list.id == id).ToList();
        }

    }
}
