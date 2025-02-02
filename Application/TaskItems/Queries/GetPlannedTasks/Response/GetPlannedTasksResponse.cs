using Application.Commons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetPlannedTasks.Response
{
    public class GetPlannedTasksResponse
    {
        public List<TaskItemDto> earlierTasks { get; set; }

        public int earlierTasksCount { get; set; }

        public List<TaskItemDto> todayTasks { get; set; }

        public int todayTasksCount { get; set; }

        public List<TaskItemDto> tomorrowTaks { get;set; }

        public int tomorrowTasksCount { get; set; }

        public List<TaskItemDto> thisWeekTasks { get; set; }

        public int thisWeekTasksCount { get; set; }

        public List<TaskItemDto> laterTasks { get; set; }

        public int laterTasksCount { get; set; }

        public int tasksCount { get; set; }
    }
}
