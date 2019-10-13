using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime deadline { get; set; }
        public bool isExpired { get; set; }
        public bool isCompleted { get; set; }
        public DateTime createTime { get; set; }
        public virtual  ToDoList list { get; set; }

    }
}
