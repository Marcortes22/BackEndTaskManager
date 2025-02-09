using Application.Commons.Dto;
using Application.Commons.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetTaskListById
{
    public class GetTaskListByIdQuery:IRequest<BaseResponse<TaskItemDto>>
    {
        public int TaskItemId { get; set; }
    

        public GetTaskListByIdQuery(int _TaskItemId)
        {
            TaskItemId = _TaskItemId;
     
        }
    }
}
