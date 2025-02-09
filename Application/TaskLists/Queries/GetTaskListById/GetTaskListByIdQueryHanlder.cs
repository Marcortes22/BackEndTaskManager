using Application.Commons.Dto;
using Application.Commons.Responses;
using Application.TaskLists.Queries.GetTaskListById.Response;
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

namespace Application.TaskLists.Queries.GetTaskListById
{
    public class GetTaskListByIdQueryHanlder : IRequestHandler<GetTaskListByIdQuery, BaseResponse<GetTaskListByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskListByIdQueryHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<GetTaskListByIdResponse>> Handle(GetTaskListByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                var tasks = await _unitOfWork.taskLists.GetTaskListById(request.TaskListId, userId);
                List<TaskItem> completed = new();
                List<TaskItem> unCompleted = new();

                if (tasks == null) {
                    return new BaseResponse<GetTaskListByIdResponse>(null, false, "Error:");
                }

                foreach (var task in tasks.TaskItems)
                {
                    if (task.IsCompleted == false)
                    {
                        unCompleted.Add(task);
                    }
                    else
                    {
                        completed.Add(task);
                    }
                }
                GetTaskListByIdResponse response = new();

                response.Id = tasks.Id;
                response.Name = tasks.Name;
                response.totalCount = tasks.TaskItems.Count();
                response.completedTasks = _mapper.Map<List<TaskItemDto>>(completed);
                response.uncompletedTasks = _mapper.Map<List<TaskItemDto>>(unCompleted);
                response.completedTaskCount = completed.Count();



                return new BaseResponse<GetTaskListByIdResponse>(response, true, "Task list retrieved successfully");

            }

            catch (Exception ex) {

                return new BaseResponse<GetTaskListByIdResponse>(null, false, $"Error: {ex.Message}");
            }
        }

    }
}
