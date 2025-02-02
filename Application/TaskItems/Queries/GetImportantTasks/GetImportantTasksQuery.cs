using Application.Commons.Responses;
using Application.TaskItems.Queries.GetImportantTasks.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Queries.GetImportantTasks
{
    public class GetImportantTasksQuery: IRequest<BaseResponse<GetImportantTasksResponse>>
    {
        public string UserSubProvider { get; set; }

        public GetImportantTasksQuery(string _userSubProvider)
        {
            UserSubProvider = _userSubProvider;
        }
    }
}
