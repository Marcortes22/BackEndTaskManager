using Application.Commons.Dto;
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

        }
    }
}
