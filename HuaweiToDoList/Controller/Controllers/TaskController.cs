
using Data.Model;
using System;
using System.Collections;
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



            SetAsExpired(task, false);
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
            //try
            //{
                task.isCompleted = true;
                DbContext.SaveChanges();
                return true;
            //}
            //catch {
            //    return false;
            //}
            
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
            
            List<Task> tasklist = DbContext.tasks.Where(t => t.list.id == id).ToList();
            SetAsExpired(tasklist,true);
            return tasklist;
        }

        public void SetAsExpired(Task t,bool saveChanges)
        {

            if (t.deadline.CompareTo(DateTime.Now) < 0)
            {
                t.isExpired = true;
            }
            if (saveChanges)
            {
                DbContext.SaveChanges();
            }
            
        }
        public void SetAsExpired(List<Task> tasklist,bool saveChanges)
        {
            foreach (Task item in tasklist)
            {
                if (item.deadline.CompareTo(DateTime.Now) < 0)
                {
                    item.isExpired = true;
                }
            }

            if (saveChanges)
            {
                DbContext.SaveChanges();
            }
        }

        public List<Task> filter(ToDoList selectedList, bool isExpired, bool isCompleted, string search_name)
        {
            return selectedList.tasks.Where(p=>p.list.id == selectedList.id 
                                     && p.isCompleted ==isCompleted
                                     && p.isExpired == isExpired
                                     && p.name.Contains(search_name)).ToList();
        }
    }
}
