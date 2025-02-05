using Application.Commons.Dto;
using Application.TaskItems.Commands.CreateTaskItemCommand.Dto;
using Application.TaskItems.Commands.CreateTaskItemCommand.Response;
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

        }
    }
}
