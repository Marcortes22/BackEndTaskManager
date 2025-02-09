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
    public class UserRepository : Repository<User, string>, IUserRepository
    {
        
        public UserRepository(MyDbContext context, ILogger logger) : base(context, logger)
        {
         
        }

        public async Task<string> GetUserTimeZone(string sub)
        {
            return await _dbSet.Where(u => u.Id == sub)
                .Select(u => u.timeZone)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserWithTaskListsAsync(string Id)
        {
          
            return await _dbSet.Include(u => u.TaskLists)
                .FirstOrDefaultAsync(u => u.Id == Id);
        }

   
    }
}
