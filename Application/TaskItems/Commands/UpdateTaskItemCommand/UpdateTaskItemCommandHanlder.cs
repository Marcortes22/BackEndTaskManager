using Application.Commons.Responses;
using Application.TaskItems.Commands.UpdateTaskItemCommand.Response;
using AutoMapper;
using Domain.Interfaces.IUnitOfWork;
using Domain.Utils;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Commands.UpdateTaskItemCommand
{
    public class UpdateTaskItemCommandHanlder : IRequestHandler<UpdateTaskItemCommand, BaseResponse<UpdateTaskItemResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateTaskItemCommand> _validator;

        public UpdateTaskItemCommandHanlder(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateTaskItemCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<BaseResponse<UpdateTaskItemResponse>> Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
        {
            try
            {

                await _validator.ValidateAndThrowAsync(request);

                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                var existTaskItem = await _unitOfWork.taskItems.getTaskByUserAndTaskId( userId, request.TaskItemId);

                if (existTaskItem == null)
                {
                    return new BaseResponse<UpdateTaskItemResponse>(null, false, "Task Item does'nt exist");
                }

            //    var newTaskItemInformation = _mapper.Map<Domain.Entities.TaskItem>(request.updateTaskItemDto);


                var updatedTaskItem = _mapper.Map(request.updateTaskItemDto, existTaskItem);

                Console.WriteLine(updatedTaskItem);

                var taskItemSaved = await _unitOfWork.taskItems.UpdateAsync(updatedTaskItem);

                await _unitOfWork.SaveChangesAsync();

                UpdateTaskItemResponse response = _mapper.Map<UpdateTaskItemResponse>(taskItemSaved);

                return new BaseResponse<UpdateTaskItemResponse>(response, true, "Task Item updated successfully");



            }
            catch (Exception ex)
            {
                return new BaseResponse<UpdateTaskItemResponse>(null, false,ex.Message);
            }
        }
    }
}
