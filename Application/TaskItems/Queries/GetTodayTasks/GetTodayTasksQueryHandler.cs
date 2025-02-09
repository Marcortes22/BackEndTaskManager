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
 

                string timeZoneId = await _unitOfWork.users.GetUserTimeZone(userId);

                if (timeZoneId == null) {
                    timeZoneId = "America/Guatemala";
                }

                TimeZoneInfo userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

                DateTime userLocalDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, userTimeZone).Date;

              
                IEnumerable<TaskItem> tasksWithAddedDay = await _unitOfWork.taskItems.getMyDayTasks(userId);

                var todayTasks = from item in tasksWithAddedDay
                                 where (TimeZoneInfo.ConvertTimeFromUtc(item.AddedToMyDay.Value, userTimeZone).Date == userLocalDate)
                                 orderby item.AddedToMyDay descending
                                 select item;

             

                GetTodayTasksResponse response = new();

                List<TaskItem> Completed = todayTasks.Where(x => x.IsCompleted == true).ToList();
                List<TaskItem> Uncomplete = todayTasks.Where(x => x.IsCompleted == false).ToList();

                response.CompletedTasks = _mapper.Map<List<TaskItemDto>>(Completed);
                response.totalCount = todayTasks.Count();
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
