using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Commands.UpdateTaskItemCommand.Dto
{
    public class UpdateTaskItemDto
    {

       
        public string? Title { get; set; } 

        public Boolean? IsCompleted { get; set; }

        public Boolean? IsImportant { get; set; }

        public DateOnly? DueDate { get; set; }

        public DateTime? AddedToMyDay { get; set; }

        public string? Note { get; set; }
    }
}
