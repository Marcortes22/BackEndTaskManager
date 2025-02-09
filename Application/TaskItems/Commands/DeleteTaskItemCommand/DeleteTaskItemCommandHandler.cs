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

namespace Application.TaskItems.Commands.DeleteTaskItemCommand
{
    public class DeleteTaskItemCommandHandler : IRequestHandler<DeleteTaskItemCommand, BaseResponse<int>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTaskItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse<int>> Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                var taskItemToDelete = await _unitOfWork.taskItems.getTaskByUserAndTaskId(userId, request.TaskItemId );

                if (taskItemToDelete == null)
                {
                    return new BaseResponse<int>(0, false, "TaskItem not found");
                }

                await _unitOfWork.taskItems.DeleteAsync(taskItemToDelete);

                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse<int>(taskItemToDelete.Id, true, "TaskItem deleted successfully");
            }
            catch (Exception e)
            {
                return new BaseResponse<int>(0, false, $"Error: {e.Message}");
            }
        }
    }
}
