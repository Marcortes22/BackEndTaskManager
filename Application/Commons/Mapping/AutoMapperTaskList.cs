using Application.Commons.Dto;
using Application.TaskLists.Commands.CreateTasksListCommand.Response;
using Application.TaskLists.Commands.CreateTsksListCommand.Dtos;
using Application.TaskLists.Commands.DeleteTaskListCommand.Response;
using Application.TaskLists.Commands.UpdateTaskListCommand.Response;
using Application.TaskLists.Queries.GetTaskListById.Response;
using Application.TaskLists.Queries.GetTaskListInformation.Response;

using AutoMapper;
using Domain.Dtos.TaskLists;
using Domain.Entities;


namespace Application.Commons.Mapping
{
    public class AutoMapperTaskList : Profile
    {

        public AutoMapperTaskList()
        {


            CreateMap<CreateTaskListDto, TaskList>().ReverseMap();

            CreateMap<TaskList, CreateTaskListResponse>().ReverseMap();

            CreateMap<TaskList, UpdateTaskListResponse>().ReverseMap();

            CreateMap<TaskList, DeleteTaskListResponse>().ReverseMap();

            CreateMap<TaskList, TaskListDto>().ReverseMap().ReverseMap();

            CreateMap<TaskList, GetTaskListByIdResponse>().ReverseMap();


            CreateMap<TaskListsWithNumberOfTasks, GetTaskListInformationResponse>()
                .ForMember(dest => dest.amoundOfTasks, opt => opt.MapFrom(src => src.CountOfTasks))
                .ForMember(dest => dest.url, opt => opt.MapFrom(src => $"/taskList/{src.Id}"))
                .ReverseMap();





        }
    }
}
