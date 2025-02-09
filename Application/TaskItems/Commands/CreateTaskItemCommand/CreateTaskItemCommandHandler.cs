using Application.Commons.Responses;
using Application.TaskItems.Commands.CreateTaskItemCommand.Dto;
using Application.TaskItems.Commands.CreateTaskItemCommand.Response;
using Application.TaskLists.Commands.CreateTasksListCommand.Response;
using Application.TaskLists.Commands.CreateTsksListCommand;
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

namespace Application.TaskItems.Commands.CreateTaskItemCommand
{
    public class CreateTaskItemCommandHandler : IRequestHandler<CreateTaskItemCommand, BaseResponse<CreateTaskItemResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateTaskItemCommand> _validator;

        public CreateTaskItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateTaskItemCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<BaseResponse<CreateTaskItemResponse>> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _validator.ValidateAndThrowAsync(request);

                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                var existTaskList = await _unitOfWork.taskLists.GetTaskListById(request.createTaskItemDto.TaskListId, userId);

                if (existTaskList == null)
                {
                    return new BaseResponse<CreateTaskItemResponse>(null, false, "Task List does'nt exist");
                }

        

                TaskItem newTaskItem = _mapper.Map<TaskItem>(request.createTaskItemDto);

                var today = DateTime.UtcNow;
                

                newTaskItem.CreatedDate = today;

                if (newTaskItem.IsCompleted)
                {
                    newTaskItem.Completed = today;
                }
               

                TaskItem createdTaskItem = await _unitOfWork.taskItems.AddAsync(newTaskItem);

               

                await _unitOfWork.SaveChangesAsync();

                CreateTaskItemResponse response = _mapper.Map<CreateTaskItemResponse>(createdTaskItem);

                return new BaseResponse<CreateTaskItemResponse>(response, true, "TaskItem created succesfully!");
            }
            catch (Exception ex) {
                return new BaseResponse<CreateTaskItemResponse>(null, false, ex.Message);
            }
        }
    }
}
