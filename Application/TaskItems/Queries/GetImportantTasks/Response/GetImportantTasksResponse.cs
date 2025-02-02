using Application.Commons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetImportantTasks.Response
{
    public class GetImportantTasksResponse
    {
        public List<TaskItemDto> tasks { get; set; }

        public int tasksCount { get; set; }
    }
}
