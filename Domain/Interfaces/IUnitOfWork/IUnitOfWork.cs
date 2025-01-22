using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository users { get; }
        ITaskListRepository taskLists { get; }
        ITaskItemRepository taskItems { get; }

        //Task CompleteAsync();

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
