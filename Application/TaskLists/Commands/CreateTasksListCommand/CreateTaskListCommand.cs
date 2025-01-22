using Application.Commons.Responses;
using Application.TaskLists.Commands.CreateTsksListCommand.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Commands.CreateTsksListCommand
{
    public class CreateTaskListCommand : IRequest<BaseResponse<CreateTaskListResponse>>
    {
        public CreateTaskListDto createTaskListDto { get; set; }
        public string Token { get; set; }

        public CreateTaskListCommand(CreateTaskListDto _createTaskListDto, string userId)
        {
            createTaskListDto = _createTaskListDto;

            Token = userId;
        }
    }
}
