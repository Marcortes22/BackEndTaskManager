using Application.TaskLists.Commands.CreateTsksListCommand.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Commons.Mapping
{
    public class AutoMapperTaskList : Profile
    {

        public AutoMapperTaskList()
        {


            CreateMap<CreateTaskListDto, TaskList>().ReverseMap();

            CreateMap<TaskList, CreateTaskListResponse>().ReverseMap();
        }
    }
}
