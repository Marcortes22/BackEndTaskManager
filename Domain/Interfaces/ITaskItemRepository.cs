using Domain.Entities;
using Domain.Interfaces.IPatternRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITaskItemRepository : IRepostory<TaskItem,int>
    {
        Task<int> getMyDayTasksNumber(string userId, TimeZoneInfo userTimeZone);

        //Task<IEnumerable<TaskItem>> getMyDayTasks(string userId, string userTimezoneId);

        public Task<IEnumerable<TaskItem>> getMyDayTasks(string userId);

        Task<int> getImportantTasksNumber(string userId);

        Task<IEnumerable<TaskItem>> getImportantTasks(string userId);

        Task<int> getPlannedTasksNumber(string userId);

        Task<IEnumerable<TaskItem>> getPlannedTasks(string userId);

        Task<int> getAllTasksNumber(string userId);

        Task<IEnumerable<TaskItem>> getAllTasks(string userId);
        Task<int> getCompletedTasksNumber(string userId);

        Task<IEnumerable<TaskItem>> getCompletedTasks(string userId);
        Task<TaskItem> getTaskByUserAndTaskId(string userId, int taskId);


    }
}
