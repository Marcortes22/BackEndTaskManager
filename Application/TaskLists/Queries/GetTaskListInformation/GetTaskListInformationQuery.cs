using Application.Commons.Responses;
using Application.TaskLists.Queries.GetTaskListInformation.Dto;
using Application.TaskLists.Queries.GetTaskListInformation.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Queries.GetTaskListInformation
{
    public class GetTaskListInformationQuery : IRequest<BaseResponse<List<GetTaskListInformationResponse>>>
    {

        public GetTaskListsInformationDto getTaskListsInformationDto { get; set; }

        public GetTaskListInformationQuery(GetTaskListsInformationDto _getTaskListsInformationDto)
        {
            getTaskListsInformationDto = _getTaskListsInformationDto;
        }
    }
}
