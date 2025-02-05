using Application.Commons.Responses;
using Application.TaskItems.Commands.CreateTaskItemCommand.Dto;
using Application.TaskItems.Commands.CreateTaskItemCommand.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Commands.CreateTaskItemCommand
{
    public class CreateTaskItemCommand:IRequest<BaseResponse<CreateTaskItemResponse>>
    {
        public CreateTaskItemDto createTaskItemDto { get; set; }

        public string UserSubProvider { get; set; }

        public CreateTaskItemCommand(CreateTaskItemDto _createTaskItemDto, string userSubProvider)
        {
            createTaskItemDto = _createTaskItemDto;
            UserSubProvider = userSubProvider;
        }
    }
   
}
