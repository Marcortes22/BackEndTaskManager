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
    public class TaskItemRepository : Repository<TaskItem,int>, ITaskItemRepository
    {
        public TaskItemRepository(MySqlContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<TaskItem>> GetCompletedTasks(string sub)
        {
            return await FindAsync(tl=> tl.IsCompleted == true && tl.TaskList.User.Id == sub);
        }

    }
}
