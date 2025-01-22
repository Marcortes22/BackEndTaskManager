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

    }
}
