using Application.Commons.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Commands.DeleteTaskItemCommand
{
    public class DeleteTaskItemCommand:IRequest<BaseResponse<int>>
    {
        public int TaskItemId { get; set; }

        public string UserSubProvider { get; set; }

        public DeleteTaskItemCommand(int taskItemId, string userSubProvider)
        {
            TaskItemId = taskItemId;
            UserSubProvider = userSubProvider;
        }
    }
}
