using Domain.Dtos.TaskLists;
using Domain.Entities;
using Domain.Interfaces.IPatternRepository;



namespace Domain.Interfaces
{
    public interface ITaskListRepository : IRepostory<TaskList,int>
    {
        //Task<TaskList> GetTaskListWithTasks(int Id, string userId);

        Task<List<TaskList>> GetAllTaskListWithRelations(string userId);
        Task<List<TaskList>> GetAllTaskListWithCompletedTasks(string userId);

        Task<TaskList> GetTaskListById(int TaskListId, string userId);

        Task<List<TaskListsWithNumberOfTasks>> GetTaskListWithNumberOfTasks(string userId);


    }
}
