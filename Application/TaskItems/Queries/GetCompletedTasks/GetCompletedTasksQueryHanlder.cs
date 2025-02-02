using Application.Commons.Dto;
using Application.Commons.Responses;
using Application.TaskItems.Queries.GetCompletedTasks.Response;
using AutoMapper;
using Domain.Interfaces.IUnitOfWork;
using Domain.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetCompletedTasks
{
    public class GetCompletedTasksQueryHanlder : IRequestHandler<GetCompletedTasksQuery, BaseResponse<GetCompletedTasksResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCompletedTasksQueryHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetCompletedTasksResponse>> Handle(GetCompletedTasksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                var completedTasks = await _unitOfWork.taskItems.getCompletedTasks(userId);

                var completedTasksDto = _mapper.Map<List<TaskItemDto>>(completedTasks);

                GetCompletedTasksResponse response = new();

                response.CompletedTasks = completedTasksDto;

                response.tasksCount = completedTasksDto.Count();

                return new BaseResponse<GetCompletedTasksResponse>(response, true, "Completed tasks retrieved successfully");
            

            }
            catch (Exception ex)
            {
                return new BaseResponse<GetCompletedTasksResponse>(null, false, ex.Message);
            }
        }
    }
}
