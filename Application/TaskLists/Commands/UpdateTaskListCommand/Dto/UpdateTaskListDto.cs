using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Commands.UpdateTaskListCommand.Dto
{
    public class UpdateTaskListDto
    {
        public string? NewName { get; set; }

        public int Id { get; set; }
    }
}
