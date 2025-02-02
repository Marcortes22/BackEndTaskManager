using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Dto
{
    public class TaskListDto
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<TaskItemDto>? TaskItems { get; set; } = new List<TaskItemDto>();
    }
}
