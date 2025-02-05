using Application.Commons.Dto;
using Application.Commons.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Queries.GetMyTaskLists
{
    public class GetMyTaskListsQuery : IRequest<BaseResponse<List<TaskListDto>>>
    {
        public string UserSubProvider { get; set; }

        public GetMyTaskListsQuery(string userSubProvider)
        {
            UserSubProvider = userSubProvider;
        }
    }
}
