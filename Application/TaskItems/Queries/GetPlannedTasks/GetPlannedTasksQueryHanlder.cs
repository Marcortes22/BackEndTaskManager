using Application.Commons.Dto;
using Application.Commons.Responses;
using Application.TaskItems.Queries.GetPlannedTasks.Response;
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

namespace Application.TaskItems.Queries.GetPlannedTasks
{
    public class GetPlannedTasksQueryHanlder : IRequestHandler<GetPlannedTasksQuery, BaseResponse<GetPlannedTasksResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPlannedTasksQueryHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<GetPlannedTasksResponse>> Handle(GetPlannedTasksQuery request, CancellationToken cancellationToken)
        {
            try
            {

                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                var todayDate = DateTime.Now;
                var tomorrowDate = todayDate.AddDays(1);
                var thisWeekInitialDay = todayDate.AddDays(2);
                var thisWeekFinallDay = todayDate.AddDays(7);

                List<TaskItem> erlierTasks = new();
                List<TaskItem> todayTasks = new();
                List<TaskItem> tomorrowTasks = new();
                List<TaskItem> thisWeekTasks = new();
                List<TaskItem> laterTasks = new();

                var plannedTasks = await _unitOfWork.taskItems.getPlannedTasks(userId);


                foreach(var task in plannedTasks)
                {
                    if (task.DueDate?.Date == todayDate.Date)
                    {
                        todayTasks.Add(task);
                    }
                    else if (task.DueDate?.Date < todayDate.Date)
                    {
                        erlierTasks.Add(task);
                    }else if (task.DueDate?.Date == tomorrowDate.Date)
                    {
                        tomorrowTasks.Add(task);
                    }
                    else if (task.DueDate?.Date >= thisWeekInitialDay.Date && task.DueDate?.Date <= thisWeekFinallDay.Date)
                    {
                        thisWeekTasks.Add(task);
                    }
                    else
                    {
                        laterTasks.Add(task);
                    }
                }


                GetPlannedTasksResponse response = new();

                response.earlierTasks =  _mapper.Map<List<TaskItemDto>>(erlierTasks);
                response.earlierTasksCount = erlierTasks.Count();
                response.todayTasks =  _mapper.Map<List<TaskItemDto>>(todayTasks);
                response.todayTasksCount = todayTasks.Count();
                response.tomorrowTaks = _mapper.Map<List<TaskItemDto>>(tomorrowTasks);
                response.tomorrowTasksCount = tomorrowTasks.Count();
                response.thisWeekTasks = _mapper.Map<List<TaskItemDto>>(thisWeekTasks);
                response.thisWeekTasksCount = thisWeekTasks.Count();
                response.laterTasks = _mapper.Map<List<TaskItemDto>>(laterTasks);
                response.laterTasksCount = laterTasks.Count();
                response.tasksCount = plannedTasks.Count();

                return new BaseResponse<GetPlannedTasksResponse>(response, true, "Planned tasks retrieved successfully");



            }
            catch (Exception ex)
            {
                return new BaseResponse<GetPlannedTasksResponse>(null, false, ex.Message);
            }
        }
    }
}
