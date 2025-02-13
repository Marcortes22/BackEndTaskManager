using Application.Commons.Responses;
using Application.TaskLists.Commands.CreateTasksListCommand.Response;
using Application.TaskLists.Commands.DeleteTaskListCommand.Response;
using Application.TaskLists.Commands.UpdateTaskListCommand.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IUnitOfWork;
using Domain.Utils;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Commands.DeleteTaskListCommand
{
    public class DeleteTaskListCommandHandler : IRequestHandler<DeleteTaskListCommand, BaseResponse<DeleteTaskListResponse>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<DeleteTaskListCommand> _validator;

        public DeleteTaskListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<DeleteTaskListCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<BaseResponse<DeleteTaskListResponse>> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _validator.ValidateAndThrowAsync(request);

                string userId = StringFunctions.GetUserSub(request.userSubProvider);

                TaskList taskList = await _unitOfWork.taskLists.GetTaskListById(request.taskListId, userId);

                if (taskList == null)
                {
                    return new BaseResponse<DeleteTaskListResponse>(null, false, "TaskList not found");
                }

                if (taskList.IsDefault)
                {
                    return new BaseResponse<DeleteTaskListResponse>(null, false, "Default taskList can't be deleted");
                }

                await _unitOfWork.taskLists.DeleteAsync(taskList);

                await _unitOfWork.SaveChangesAsync();

                DeleteTaskListResponse response = _mapper.Map<DeleteTaskListResponse>(taskList);

                return new BaseResponse<DeleteTaskListResponse>(response, true, "TaskList deleted successfully");

            }
            catch (Exception e)
            {
                return new BaseResponse<DeleteTaskListResponse>(null, false, $"Error: {e.Message}");
            }
        }
    }
}
