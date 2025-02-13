using Application.Commons.Responses;
using Application.TaskLists.Commands.DeleteTaskListCommand.Dto;
using Application.TaskLists.Commands.DeleteTaskListCommand.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Commands.DeleteTaskListCommand
{
    public class DeleteTaskListCommand : IRequest<BaseResponse<DeleteTaskListResponse>>
    {
        public int taskListId  { get; set; }

        public string userSubProvider { get; set; }

        public DeleteTaskListCommand(int _taskListId, string _userSubProvider)
        {
            userSubProvider = _userSubProvider;
            taskListId = _taskListId;
        }
    }
}
