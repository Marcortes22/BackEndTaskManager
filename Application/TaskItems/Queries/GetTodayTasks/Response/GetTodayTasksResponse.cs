using Application.Commons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetTodayTasks.Response
{
    public class GetTodayTasksResponse
    {

       public List<TaskItemDto> UncompletedTasks { get; set; }

        public int totalCount { get; set; }
        public List<TaskItemDto> CompletedTasks { get; set; }

        public int CompletedCount { get; set; }
    }
}
