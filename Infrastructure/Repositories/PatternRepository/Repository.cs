using Domain.Interfaces.IPatternRepository;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.PatternRepository
{
    public class Repository<T, TKey> : IRepostory<T, TKey> where T : class
    {
        protected readonly MyDbContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public Repository(MyDbContext context, ILogger logger)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _logger = logger;
        }

        public async Task<T> AddAsync(T entity)
        {

            try
            {
                await _dbSet.AddAsync(entity);
                //await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error adding entity");
                return null;
            }
        }

        public async Task DeleteAsync(T entity)
        {

            try
            {     
               _dbSet.Remove(entity);
 
            }
            catch (Exception e)
            {
               _logger.LogError(e, "Error deleting entity");
                
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            try
            {

                return await _dbSet.FindAsync(id);

            }
            catch (Exception e)
            {
                string message = $"Error getting entity with id {id}";
                _logger.LogError(e, message, id);
                return null;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {

                _dbSet.Update(entity);

                //await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception e)
            {
                string message = "Error update entity";
                _logger.LogError(e, message);
                return null;
            }
        }
    }
}
