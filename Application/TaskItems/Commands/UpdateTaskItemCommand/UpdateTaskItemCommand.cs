using Application.Commons.Responses;
using Application.TaskItems.Commands.UpdateTaskItemCommand.Dto;
using Application.TaskItems.Commands.UpdateTaskItemCommand.Response;
using Application.TaskLists.Commands.UpdateTaskListCommand.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Commands.UpdateTaskItemCommand
{
    public class UpdateTaskItemCommand : IRequest<BaseResponse<UpdateTaskItemResponse>>
    {
        public UpdateTaskItemDto updateTaskItemDto { get; set; }

        public string UserSubProvider { get; set; }

        public int TaskItemId { get; set; }

        public UpdateTaskItemCommand(UpdateTaskItemDto _updateTaskItemDto, string userSubProvider, int _TaskItemId)
        {
            updateTaskItemDto = _updateTaskItemDto;
            UserSubProvider = userSubProvider;
            TaskItemId = _TaskItemId;
        }
    }
}
