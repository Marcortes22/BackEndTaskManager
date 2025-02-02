using Domain.Dtos.TaskLists;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.PatternRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Infrastructure.Repositories
{
    public class TaskListRepository : Repository<TaskList, int>, ITaskListRepository
    {
        public TaskListRepository(MySqlContext context, ILogger logger) : base(context, logger)
        {
        }

     

        //public async Task<TaskList> GetTaskListWithTasks(int Id, string userId)
        //{
        //    return await _dbSet.Include(tl => tl.TaskItems).FirstOrDefaultAsync(tl => tl.Id == Id && tl.UserId == userId);
        //}


        public async Task<TaskList> GetTaskListById(int TaskListId, string userId)
        {
            return await _dbSet.Include(tl => tl.TaskItems).FirstOrDefaultAsync(tl => tl.Id == TaskListId && tl.UserId == userId);
        }

        public async Task<List<TaskListsWithNumberOfTasks>> GetTaskListWithNumberOfTasks(string userId)
        {
            var taskLists = await _dbSet
                .Include(tl => tl.TaskItems)
                .Where(tl => tl.UserId == userId)
                .Select(tl => new TaskListsWithNumberOfTasks
                 {
                     Id = tl.Id,
                     Name = tl.Name,
                     CountOfTasks = tl.TaskItems.Count(ti=> ti.IsCompleted == false),
                    isDefault = tl.IsDefault
                })
                .OrderByDescending(tl => tl.isDefault)
                .ToListAsync();

            return taskLists;
        }

        public Task<List<TaskList>> GetAllTaskListWithRelations(string userId)
        {
            return _dbSet.Where(tl=> tl.UserId == userId).Include(tl => tl.TaskItems.Where(ti => ti.IsCompleted == false)).ToListAsync();
        }

        public Task<List<TaskList>> GetAllTaskListWithCompletedTasks(string userId)
        {
            return _dbSet.Where(tl => tl.UserId == userId).Include(tl => tl.TaskItems.Where(ti => ti.IsCompleted == true)).ToListAsync();
        }
    }
}
