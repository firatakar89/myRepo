using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }


        public string username { get; set; }
        public string password { get; set; }
        public List<ToDoList> toDoLists { get; set; }

        public User()
        { 
        }
        public User(string _username,string _password)
        {
            username = _username;
            password = _password;
        }
    }
}
