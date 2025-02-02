using Application.Commons.Responses;
using Application.TaskItems.Queries.GetTodayTasks.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetTodayTasks
{
    public class GetTodayTasksQuery : IRequest<BaseResponse<GetTodayTasksResponse>>
    {
        public string UserSubProvider { get; set; }

        public GetTodayTasksQuery(string _userSubProvider)
        {
            UserSubProvider = _userSubProvider;
        }
    }
}
