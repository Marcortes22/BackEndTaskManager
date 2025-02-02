using Application.Commons.Dto;
using Application.Commons.Responses;
using Application.TaskItems.Queries.GetImportantTasks.Response;
using AutoMapper;
using Domain.Interfaces.IUnitOfWork;
using Domain.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetImportantTasks
{
    public class GetImportantTasksQueryHandler : IRequestHandler<GetImportantTasksQuery, BaseResponse<GetImportantTasksResponse>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetImportantTasksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<GetImportantTasksResponse>> Handle(GetImportantTasksQuery request, CancellationToken cancellationToken)
        {
            try
            {

                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                var allImportantTasks = await _unitOfWork.taskItems.getImportantTasks(userId);

                GetImportantTasksResponse response = new();

                response.tasks = _mapper.Map<List<TaskItemDto>>(allImportantTasks);

                response.tasksCount = allImportantTasks.Count();

                return new BaseResponse<GetImportantTasksResponse>(response, true, "Important tasks retrieved successfully");


            }
            catch(Exception ex)
            {
                return new BaseResponse<GetImportantTasksResponse>(null, false, ex.Message);
            }
        }
    }
    
    
}
