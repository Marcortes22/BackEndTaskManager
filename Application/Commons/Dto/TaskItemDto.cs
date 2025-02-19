using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Dto
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Boolean IsCompleted { get; set; }
        public Boolean IsImportant { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateOnly? DueDate { get; set; } = null;
        public DateTime? Completed { get; set; } = null;
        public string Note { get; set; }
        public DateTime? addedToMyDay { get; set; } = null;

        public string? taskListName { get; set; }

    }
}
