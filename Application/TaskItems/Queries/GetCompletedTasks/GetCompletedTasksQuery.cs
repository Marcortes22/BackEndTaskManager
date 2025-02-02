using Application.Commons.Dto;
using Application.Commons.Responses;
using Application.TaskItems.Queries.GetCompletedTasks.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetCompletedTasks
{
    public class GetCompletedTasksQuery:IRequest<BaseResponse<GetCompletedTasksResponse>>
    {
        public string UserSubProvider { get; set; }

        public GetCompletedTasksQuery(string _userSubProvider)
        {
            UserSubProvider = _userSubProvider;
        }

    }
}
