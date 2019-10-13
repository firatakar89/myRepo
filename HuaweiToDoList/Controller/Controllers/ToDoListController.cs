
using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace Controller.Controllers
{
    public class ToDoListController :BaseController
    {
        TaskController taskController = new TaskController();

        /// <summary>
        /// Add New To Do List
        /// </summary>
        /// <param name="toDoList"></param>
        public void Add(string ListName, User user)
        {

            ToDoList new_list = new ToDoList { name = ListName,user = user };

            DbContext.lists.Add(new_list);
            DbContext.users.Attach(user);
            DbContext.SaveChanges();
            
        }
        /// <summary>
        /// List all To Do Lists of a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<ToDoList> List(User user)
        {
            DbContext.users.Attach(user);
            List<ToDoList> myLists = DbContext.lists.Where(u => u.user.username == user.username).ToList();
            if (myLists!=null)
            {
                return myLists;
            }
            return new List<ToDoList>();
        }



        public List<Task> ListTasksofToDoList(ToDoList list)
        {
          

                string query = "Select * from dbo.ToDoLists where name = @name and user_id=@user_id";

                SqlParameter[] parameters = new SqlParameter[2] { new SqlParameter("@name", list.name), new SqlParameter("@user_id", list.user.id) };

                ToDoList selectedList = DbContext.lists.SqlQuery(query, parameters).FirstOrDefault();
                selectedList.tasks = taskController.getTasksByListId(selectedList.id);

                
                if (selectedList.tasks ==null)
                {
                    return new List<Task>();
                }
                return selectedList.tasks;

        }


        /// <summary>
        /// Remove To Do List 
        /// </summary>
        /// <param name="toDoList"></param>
        public void Remove(ToDoList toDoList)
        {
            DbContext.lists.Remove(toDoList);
            DbContext.SaveChanges();
        }

        /// <summary>
        /// Filter ToDoList
        /// </summary>
        /// <param name="status"></param>
        /// <param name="isExpired"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Task> Filter(bool status, bool isExpired, string name,ToDoList toDoList)
        {
            List<Task> taskOfList = toDoList.tasks;
            if (isExpired)
            {
                return taskOfList.Where(n => n.name == name && n.isExpired == status && DateTime.Compare(n.deadline, DateTime.Now) < 0).ToList();
            }
            else
            {
                return taskOfList.Where(n => n.name == name && n.isExpired == status && DateTime.Compare(n.deadline, DateTime.Now) >= 0).ToList();
            }
            
        }
    }
}
