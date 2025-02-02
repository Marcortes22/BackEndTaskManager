using Application.Commons.Responses;
using Application.TaskLists.Commands.CreateTasksListCommand.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IUnitOfWork;
using Domain.Utils;
using FluentValidation;
using MediatR;


namespace Application.TaskLists.Commands.CreateTsksListCommand
{
    public class CreateTaskListCommandHandler : IRequestHandler<CreateTaskListCommand, BaseResponse<CreateTaskListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTaskListCommand> _validator;


        public CreateTaskListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateTaskListCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseResponse<CreateTaskListResponse>> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
        {
            try
            {

                await _validator.ValidateAndThrowAsync(request);

                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                User user = await _unitOfWork.users.GetByIdAsync(userId);

                if (user == null)
                {
                    return new BaseResponse<CreateTaskListResponse>(null, false, "User not found");
                }

                TaskList newTaskList = _mapper.Map<TaskList>(request.createTaskListDto);

                newTaskList.UserId = userId;

                TaskList createdTaskList = await _unitOfWork.taskLists.AddAsync(newTaskList);

                await _unitOfWork.SaveChangesAsync();

                CreateTaskListResponse response = _mapper.Map<CreateTaskListResponse>(createdTaskList);

                return new BaseResponse<CreateTaskListResponse>(response, true, "TaskList created successfully");
            }
         
            catch (Exception e)
            {
                return new BaseResponse<CreateTaskListResponse>(null, false, $"Error: {e.Message}");
            }
        }
    }
}
