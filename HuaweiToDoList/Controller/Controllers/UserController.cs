
using Data;
using Data.Model;
using System.Linq;
namespace Controller.Controllers
{
    public class UserController : BaseController
    {
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="user">User Object</param>
        public bool Register(User user)
        {
           
                user.password = Encrypt(user.password);
                if (DbContext.users.Where(p => p.username == user.username).Count() == 0)
                {
                    DbContext.users.Add(user);
                    DbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
          
           
        }
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Login(User user)
        {
            user.password = Encrypt(user.password);
            User myUser = DbContext.users.FirstOrDefault(u => u.username == user.username
                    && u.password == user.password);
          
            return myUser;
        }

        private string Encrypt(string data)
        {
            //Buraya Encrpt Gelecek
            return data;
        }
    }
}
