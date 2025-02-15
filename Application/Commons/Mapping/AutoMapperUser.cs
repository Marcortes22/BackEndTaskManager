using Application.Users.Commands.CreateUserCommand.Dtos;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Services.Auth0.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Mapping
{
    public class AutoMapperUser : Profile
    {
        public AutoMapperUser()
        {
            CreateMap<UserInfoDto, User>()
                .ForMember(user => user.Id,
                    userInfo => userInfo.MapFrom(src => src.sub))
                .ForMember(user => user.givenName, userInfo => userInfo.MapFrom(src => src.given_name))
                .ForMember(user => user.familyName, userInfo => userInfo.MapFrom(src => src.family_name))
                .ForMember(user => user.wholeName, userInfo => userInfo.MapFrom(src => src.name))
                .ForMember(user => user.updatedAt, userInfo => userInfo.MapFrom(src => src.updated_at))
                .ForMember(user => user.emailVerified, userInfo => userInfo.MapFrom(src => src.email_verified))
                .ReverseMap();


            CreateMap<User, CreateUserResponse>().ReverseMap();

            CreateMap<CreateUserDto, User>().ReverseMap();

        }
    }
}
