using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.Repositories.PatternRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TaskListRepository : Repository<TaskList, int>, ITaskListRepository
    {
        public TaskListRepository(MySqlContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<TaskList> GetDefatultTaskListWithTasks(string userId)
        {
            return await _dbSet.Include(tl => tl.TaskItems).FirstOrDefaultAsync(tl => tl.UserId == userId && tl.IsDefault ==true);
            //return await FindOneAsync(tl => tl.UserId == userId && tl.IsDefault == true);
        }

        public async Task<TaskList> GetTaskListWithTasks(int Id)
        {
            return await _dbSet.Include(tl => tl.TaskItems).FirstOrDefaultAsync(tl => tl.Id == Id);
        }

        public async Task<IEnumerable<TaskList>> GetTMyTaskLists(string userId)
        {
            return await FindAsync(tl => tl.UserId == userId);
        }
    }
}
