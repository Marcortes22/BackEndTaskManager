using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Boolean IsCompleted { get; set; }
        public Boolean IsImportant { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Completed { get; set; } = null;

        public int TaskListId { get; set; }
        public TaskList? TaskList { get; set; }

        public string Note { get; set; }

    }
}
