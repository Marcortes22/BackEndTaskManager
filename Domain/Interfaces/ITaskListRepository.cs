using Domain.Entities;
using Domain.Interfaces.IPatternRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITaskListRepository : IRepostory<TaskList,int>
    {
        Task<TaskList> GetTaskListWithTasks(int Id);
        Task<TaskList> GetDefatultTaskListWithTasks(string userId);
        Task<IEnumerable<TaskList>> GetTMyTaskLists(string userId);
    }
}
