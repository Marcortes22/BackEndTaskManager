using Application.Commons.Responses;
using Application.TaskLists.Queries.GetTaskListInformation.Response;
using AutoMapper;
using Domain.Interfaces.IUnitOfWork;
using Domain.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Queries.GetTaskListInformation
{
    public class GetTaskListInformationQueryHandler : IRequestHandler<GetTaskListInformationQuery, BaseResponse<List<GetTaskListInformationResponse>>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskListInformationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse<List<GetTaskListInformationResponse>>> Handle(GetTaskListInformationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<GetTaskListInformationResponse> response = new();

                string userId = StringFunctions.GetUserSub(request.getTaskListsInformationDto.UserSubProvider);

                string timeZoneId = await _unitOfWork.users.GetUserTimeZone(userId);

                Console.WriteLine(timeZoneId);

                if (timeZoneId == null)
                {
                    timeZoneId = "America/Guatemala";
                }

                TimeZoneInfo userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);


                var Tasklists = await _unitOfWork.taskLists.GetTaskListWithNumberOfTasks(userId);



                int totalTasks = await _unitOfWork.taskItems.getAllTasksNumber(userId);
                int totalCompletedTasks = await _unitOfWork.taskItems.getCompletedTasksNumber(userId);
                int totalImportantTasks = await _unitOfWork.taskItems.getImportantTasksNumber(userId);
                int totalMyDayTasks = await _unitOfWork.taskItems.getMyDayTasksNumber(userId, userTimeZone);
                int totalPlannedTasks = await _unitOfWork.taskItems.getPlannedTasksNumber(userId);


                response.AddRange(new List<GetTaskListInformationResponse>
                {
                    new GetTaskListInformationResponse
                    {
                        Name = "My Day",
                        amoundOfTasks = totalMyDayTasks,
                        url = "/"
                    },
                    new GetTaskListInformationResponse
                    {
                        Name = "Important",
                        amoundOfTasks = totalImportantTasks,
                        url = "/important"
                    },
                    new GetTaskListInformationResponse
                    {
                        Name = "Planned",
                        amoundOfTasks = totalPlannedTasks,
                        url = "/planned"
                    },
                    new GetTaskListInformationResponse
                    {
                        Name = "Completed",
                        amoundOfTasks = 0,
                        url = "/completed"
                    },
                    new GetTaskListInformationResponse
                    {
                        Name = "All",
                        amoundOfTasks = totalTasks,
                        url = "/all"
                    },
                });

                response.AddRange(_mapper.Map<List<GetTaskListInformationResponse>>(Tasklists));

                return new BaseResponse<List<GetTaskListInformationResponse>>(response, true, "TaskLists retrieved successfully");


            }
            catch (Exception e)
            {
                return new BaseResponse<List<GetTaskListInformationResponse>>(null, false, $"Error: {e.Message}");
            }
        }
    }
}
