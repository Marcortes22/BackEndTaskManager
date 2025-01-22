using Application.Commons.Responses;
using Application.TaskLists.Commands.CreateTsksListCommand.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IUnitOfWork;
using Domain.Utils;
using MediatR;


namespace Application.TaskLists.Commands.CreateTsksListCommand
{
    public class CreateTaskListCommandHandler : IRequestHandler<CreateTaskListCommand, BaseResponse<CreateTaskListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CreateTaskListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateTaskListResponse>> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
        {
            try
            {

                string userId = StringFunctions.GetUserSub(request.Token);

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
