using Application.Commons.Dto;
using Application.Commons.Responses;
using AutoMapper;
using Domain.Interfaces.IUnitOfWork;
using Domain.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Queries.GetAllTaskListWithCompletedTasks
{
    public class GetAllTaskListWithCompletedTasksQueryHanlder : IRequestHandler<GetAllTaskListWithCompletedTasksQuery, BaseResponse<List<TaskListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTaskListWithCompletedTasksQueryHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<TaskListDto>>> Handle(GetAllTaskListWithCompletedTasksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                var taskLists = await _unitOfWork.taskLists.GetAllTaskListWithCompletedTasks(userId);
            
                List<TaskListDto> list = _mapper.Map<List<TaskListDto>>(taskLists);

                return new BaseResponse<List<TaskListDto>>(list, true, "TaskLists retrieved successfully");
            }
            catch (Exception ex) { 
            return new BaseResponse<List<TaskListDto>>(null, false, $"Error: {ex.Message}");
            }
        }
    }
}
