using Application.Commons.Dto;
using Application.Commons.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Queries.GetAllTaskLists
{
    public class GetAllTaskListsQuery:IRequest<BaseResponse<List<TaskListDto>>>
    {
        public string UserSubProvider { get; set; }

        public GetAllTaskListsQuery(string userSubProvider)
        {
            UserSubProvider = userSubProvider;
        }
    }
}
