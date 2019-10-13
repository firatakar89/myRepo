
using Data.Model;
using System.Data.Entity;

namespace Data
{
    public class ToDoListDbContext : DbContext
    {

        public ToDoListDbContext() : base()
        {
          

        }


        public DbSet<User> users { get; set; }
        public DbSet<Task> tasks { get; set; }

        public DbSet<ToDoList> lists { get; set; }
    }
}
