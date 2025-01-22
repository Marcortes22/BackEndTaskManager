using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public Boolean IsDefault { get; set; } = false;
        public IEnumerable<TaskItem>? TaskItems { get; set; } = new List<TaskItem>();


        public static TaskList getDefaultTaskList()
        {
            return new TaskList
            {
                Name = "Tasks",
                IsDefault = true
            };
        }
    }
}
