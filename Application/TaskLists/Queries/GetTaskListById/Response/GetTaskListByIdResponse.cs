using Application.Commons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Queries.GetTaskListById.Response
{
    public class GetTaskListByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TaskItemDto> uncompletedTasks { get; set; }
        public List<TaskItemDto> completedTasks { get; set; } 

        public int completedTaskCount { get; set; }

        public int totalCount { get; set; }
    }
}
