using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.PatternRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Repositories
{
    public class TaskItemRepository : Repository<TaskItem,int>, ITaskItemRepository
    {
        public TaskItemRepository(MySqlContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<int> getAllTasksNumber(string userId)
        {
            return await _dbSet.CountAsync(tl => tl.TaskList.User.Id == userId && tl.IsCompleted == false);
        }


        public async Task<int> getCompletedTasksNumber(string userId)
        {
            return await _dbSet.CountAsync(tl => tl.TaskList.User.Id == userId && tl.IsCompleted);
        }

        public async Task<int> getImportantTasksNumber(string userId)
        {
            return await _dbSet.CountAsync(tl => tl.TaskList.User.Id == userId && tl.IsImportant && tl.IsCompleted == false);
        }

        public async Task<int> getMyDayTasksNumber(string userId, TimeZoneInfo userTimeZone )
        {
         
            DateTime userToday = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, userTimeZone).Date;

            var taskItems = await _dbSet
                .Where(tl => tl.TaskList.User.Id == userId
                             && tl.AddedToMyDay.HasValue
                             && tl.IsCompleted == false)
                .ToListAsync();

            var result = taskItems.Count(tl => TimeZoneInfo.ConvertTimeFromUtc(tl.AddedToMyDay.Value, userTimeZone).Date == userToday);
            return result;
        }

        public async Task<int> getPlannedTasksNumber(string userId)
        {        
            return await _dbSet.CountAsync(tl => tl.TaskList.User.Id == userId && tl.DueDate.HasValue && tl.IsCompleted == false);
        }
        public async Task<IEnumerable<TaskItem>> GetCompletedTasks(string sub)
        {
            return await FindAsync(tl=> tl.IsCompleted == true && tl.TaskList.User.Id == sub);
        }




        public async Task<IEnumerable<TaskItem>> getMyDayTasks(string userId)
        {

            return await _dbSet
                .Where(ti => ti.TaskList.User.Id == userId &&
                             ti.AddedToMyDay.HasValue)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskItem>> getImportantTasks(string userId)
        {
            return await _dbSet.Where(ti => ti.TaskList.User.Id == userId && ti.IsImportant && ti.IsCompleted == false).OrderByDescending(ti=>ti.CreatedDate).ToListAsync();
        }

        public async Task<IEnumerable<TaskItem>> getPlannedTasks(string userId)
        {
            var today = DateTime.Today.Date;

            return await _dbSet.Where(ti => ti.TaskList.User.Id == userId && ti.DueDate.HasValue  && ti.IsCompleted == false).OrderByDescending(ti => ti.CreatedDate).ToListAsync();
        }

        public async Task<IEnumerable<TaskItem>> getAllTasks(string userId)
        {
            return await _dbSet.Where(ti => ti.TaskList.User.Id == userId && ti.IsImportant && ti.IsCompleted == false).OrderByDescending(ti => ti.CreatedDate).ToListAsync();
        }

        public async Task<IEnumerable<TaskItem>> getCompletedTasks(string userId)
        {
           return await _dbSet.Where(ti => ti.TaskList.User.Id == userId && ti.IsCompleted).OrderByDescending(ti => ti.CreatedDate).ToListAsync();
        }

        public async Task<TaskItem> getTaskByUserAndTaskId(string userId, int taskId)
        {
            return await _dbSet.Where(ti => ti.TaskList.User.Id == userId && ti.Id == taskId).FirstOrDefaultAsync();
        }
    }
}
