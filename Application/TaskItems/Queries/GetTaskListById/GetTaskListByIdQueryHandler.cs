using Application.Commons.Dto;
using Application.Commons.Responses;
using AutoMapper;
using Domain.Interfaces.IUnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetTaskListById
{
    public class GetTaskListByIdQueryHandler : IRequestHandler<GetTaskListByIdQuery, BaseResponse<TaskItemDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskListByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<TaskItemDto>> Handle(GetTaskListByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {


                var taskItem = await _unitOfWork.taskItems.GetByIdAsync(request.TaskItemId);

                if (taskItem == null)
                {
                    return new BaseResponse<TaskItemDto>(null, false, "Task Item does'nt exist");
                }

                TaskItemDto taskItemDto = _mapper.Map<TaskItemDto>(taskItem);

                return new BaseResponse<TaskItemDto>(taskItemDto, true, "Task Item found");

            }
            catch (Exception ex)
            {
                return new BaseResponse<TaskItemDto>(null, false, ex.Message);
            }
        }
    }
}
