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

namespace Application.TaskLists.Queries.GetMyTaskLists
{
    public class GetMyTaskListsQueryHandler : IRequestHandler<GetMyTaskListsQuery, BaseResponse<List<TaskListDto>>>
    {

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetMyTaskListsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<TaskListDto>>> Handle(GetMyTaskListsQuery request, CancellationToken cancellationToken)
        {
            try
            {

               string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                var data = await _unitOfWork.taskLists.GetMyTaskLists(userId);

                List<TaskListDto> response = _mapper.Map<List<TaskListDto>>(data);

                return new BaseResponse<List<TaskListDto>>(response, true, "Task Lists retrieved successfully");



            }
            catch (Exception ex)
            {
              return new BaseResponse<List<TaskListDto>>(null, false ,ex.Message);
            }
        }
    }
  
}
