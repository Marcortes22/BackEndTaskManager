using Application.Commons.Dto;
using Application.Commons.Responses;
using Application.TaskLists.Queries.GetTaskListById.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Queries.GetTaskListById
{
    public class GetTaskListByIdQuery:IRequest<BaseResponse<GetTaskListByIdResponse>>
    {
        public string UserSubProvider { get; set; }

        public int TaskListId { get; set; }

        public GetTaskListByIdQuery(string _UserSubProvider, int taskListId)
        {
            UserSubProvider = _UserSubProvider;
            TaskListId = taskListId;
        }
    }
}
