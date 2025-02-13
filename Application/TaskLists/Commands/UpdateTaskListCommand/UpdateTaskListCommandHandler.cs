using Application.Commons.Responses;
using Application.TaskLists.Commands.UpdateTaskListCommand.Dto;
using Application.TaskLists.Commands.UpdateTaskListCommand.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IUnitOfWork;
using Domain.Utils;
using FluentValidation;
using MediatR;


namespace Application.TaskLists.Commands.UpdateTaskListCommand
{
    public class UpdateTaskListCommandHandler : IRequestHandler<UpdateTaskListCommand, BaseResponse<UpdateTaskListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateTaskListCommand> _validator;

        public UpdateTaskListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateTaskListCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseResponse<UpdateTaskListResponse>> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _validator.ValidateAndThrowAsync(request);

                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                TaskList taskList = await _unitOfWork.taskLists.GetTaskListById(request.taskListId, userId);

                if (taskList == null)
                {
                    return new BaseResponse<UpdateTaskListResponse>(null, false, "TaskList not found");
                }

                taskList.Name = request.UpdateTaskListDto.NewName;

                TaskList taskListSaved = await _unitOfWork.taskLists.UpdateAsync(taskList);

                await _unitOfWork.SaveChangesAsync();

                UpdateTaskListResponse response = _mapper.Map<UpdateTaskListResponse>(taskListSaved);

                return new BaseResponse<UpdateTaskListResponse>(response, true, "TaskList updated successfully");

            }
            catch (Exception e)
            {
                return new BaseResponse<UpdateTaskListResponse>(null, false, $"Error: {e.Message}");
            }
        }
    }
}
