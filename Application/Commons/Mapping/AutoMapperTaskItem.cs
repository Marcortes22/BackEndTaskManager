using Application.Commons.Dto;
using Application.TaskItems.Commands.CreateTaskItemCommand.Dto;
using Application.TaskItems.Commands.CreateTaskItemCommand.Response;
using Application.TaskItems.Commands.UpdateTaskItemCommand.Dto;
using Application.TaskItems.Commands.UpdateTaskItemCommand.Response;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Mapping
{
    public class AutoMapperTaskItem: Profile
    {

        public AutoMapperTaskItem() { 

        CreateMap<TaskItemDto, TaskItem>().ReverseMap();

        CreateMap<TaskItemDto, CreateTaskItemDto>().ReverseMap();

        CreateMap<TaskItemDto, CreateTaskItemResponse>().ReverseMap();

        CreateMap<TaskItem, CreateTaskItemResponse>().ReverseMap();

        CreateMap<TaskItem, CreateTaskItemDto>().ReverseMap();


       CreateMap<TaskItem, UpdateTaskItemDto>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
       CreateMap<UpdateTaskItemDto, TaskItem>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<TaskItem, UpdateTaskItemResponse>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateTaskItemResponse, TaskItem>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
