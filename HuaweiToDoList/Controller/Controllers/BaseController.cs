using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Controllers
{
   public class BaseController
    {
        private static ToDoListDbContext dbContext = new ToDoListDbContext();
        public BaseController()
        {

        }
        public static ToDoListDbContext DbContext
        {
            get {
                return dbContext;
            }
            
        }
    }
}
