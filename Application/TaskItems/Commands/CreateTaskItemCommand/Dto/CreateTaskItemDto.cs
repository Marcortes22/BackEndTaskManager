using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Commands.CreateTaskItemCommand.Dto
{
    public class CreateTaskItemDto
    {
        public string Title { get; set; }

        public Boolean? IsCompleted { get; set; }

        public Boolean? IsImportant { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? AddedToMyDay { get; set; }

        public int TaskListId { get; set; }

        public string? Note { get; set; }
    }
}


//public DateTime CreatedDate { get; set; }

