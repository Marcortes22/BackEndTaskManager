using Domain.Interfaces;
using Domain.Interfaces.IUnitOfWork;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MySqlContext _context;
        private readonly ILogger _logger;
        private IDbContextTransaction  _objTran;
        private bool _disposed;
        public IUserRepository users { get; private set; }

        public ITaskListRepository taskLists { get; private set; }

        public ITaskItemRepository taskItems { get; private set; }

        public UnitOfWork(MySqlContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            users = new UserRepository(_context, _logger);
            taskLists = new TaskListRepository(_context, _logger);
            taskItems = new TaskItemRepository(_context, _logger);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            if (_objTran != null)
            {
                throw new InvalidOperationException("Ya hay una transacción activa.");
            }

            _objTran = await _context.Database.BeginTransactionAsync();

        }

        public async Task CommitAsync()
        {
           await _objTran.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (_objTran == null)
            {
                throw new InvalidOperationException("No hay una transacción activa para revertir.");
            }

                await _objTran.RollbackAsync();
                _objTran.Dispose();

        }

        //
        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {

                    _context?.Dispose();
                }

                _disposed = true;
            }
        }


        //The Dispose() method is used to free unmanaged resources like files, 
        //database connections etc. at any time.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
