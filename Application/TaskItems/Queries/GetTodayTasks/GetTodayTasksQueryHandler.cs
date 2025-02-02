using Application.Commons.Dto;
using Application.Commons.Responses;
using Application.TaskItems.Queries.GetTodayTasks.Response;
using Application.TaskLists.Queries.GetTaskListInformation.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IUnitOfWork;
using Domain.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetTodayTasks
{
    public class GetTodayTasksQueryHandler : IRequestHandler<GetTodayTasksQuery, BaseResponse<GetTodayTasksResponse>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTodayTasksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<GetTodayTasksResponse>> Handle(GetTodayTasksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                var allTodayTasks = await _unitOfWork.taskItems.getMyDayTasks(userId);
                Console.WriteLine(allTodayTasks);

                GetTodayTasksResponse response = new();

                List<TaskItem> Completed = allTodayTasks.Where(x => x.IsCompleted == true).ToList();
                List<TaskItem> Uncomplete = allTodayTasks.Where(x => x.IsCompleted == false).ToList();

                response.CompletedTasks = _mapper.Map<List<TaskItemDto>>(Completed);
                response.totalCount = allTodayTasks.Count();
                response.UncompletedTasks = _mapper.Map<List<TaskItemDto>>(Uncomplete);
                response.CompletedCount = Completed.Count;


                return new BaseResponse<GetTodayTasksResponse>(response, true, "Today tasks retrieved successfully");

            }
            catch (Exception e)
            {
                return new BaseResponse<GetTodayTasksResponse>(null, false, $"Error: {e.Message}");
            }
        }
    }
}
