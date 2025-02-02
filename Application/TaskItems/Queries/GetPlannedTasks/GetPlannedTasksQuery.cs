using Application.Commons.Responses;
using Application.TaskItems.Queries.GetPlannedTasks.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetPlannedTasks
{
    public class GetPlannedTasksQuery:IRequest<BaseResponse<GetPlannedTasksResponse>>
    {
        public string UserSubProvider { get; set; }

        public GetPlannedTasksQuery(string _userSubProvider)
        {
            UserSubProvider = _userSubProvider;
        }
    }
    
}
