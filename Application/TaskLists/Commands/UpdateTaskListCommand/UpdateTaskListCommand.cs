using Application.Commons.Responses;
using Application.TaskLists.Commands.UpdateTaskListCommand.Dto;
using Application.TaskLists.Commands.UpdateTaskListCommand.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Commands.UpdateTaskListCommand
{
    public class UpdateTaskListCommand : IRequest<BaseResponse<UpdateTaskListResponse>>
    {

        public UpdateTaskListDto UpdateTaskListDto { get; set; }

        public string UserSubProvider { get; set; }

        public UpdateTaskListCommand(UpdateTaskListDto _updateTaskListDto, string _UserSubProvider)
        {
            UpdateTaskListDto = _updateTaskListDto;
            UserSubProvider = _UserSubProvider;
        }

    }
    
    
}
