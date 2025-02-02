using Application.Commons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetCompletedTasks.Response
{
    public class GetCompletedTasksResponse
    {
        public List<TaskItemDto> CompletedTasks { get; set; }

        public int tasksCount { get; set; }
    }
}
