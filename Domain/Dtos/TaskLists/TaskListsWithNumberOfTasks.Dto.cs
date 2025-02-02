using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.TaskLists
{
    public class TaskListsWithNumberOfTasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountOfTasks { get; set; }

        public bool isDefault { get; set; }
    }
}
