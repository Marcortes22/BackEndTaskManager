﻿using Application.Commons.Responses;
using Application.Users.Commands.CreateUserCommand.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IUnitOfWork;
using Infrastructure.Services.Auth0;
using Infrastructure.Services.Auth0.Dto;
using MediatR;


namespace Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseResponse<CreateUserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuth0Service _auth0Service;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuth0Service auth0Service)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _auth0Service = auth0Service;
        }
        public async Task<BaseResponse<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                UserInfoDto userInfo = await _auth0Service.getUserInformation(request.createUserDto.auth0Token);

                User existsUser = await _unitOfWork.users.GetByIdAsync(userInfo.sub);

                if (existsUser != null)
                {

                    CreateUserResponse responseExists = _mapper.Map<CreateUserResponse>(existsUser);

                    return new BaseResponse<CreateUserResponse>(responseExists, true, "User already exists in app");
                }

                User user = _mapper.Map<User>(userInfo);

                user.TaskLists.Add(TaskList.getDefaultTaskList());

                User createdUser = await _unitOfWork.users.AddAsync(user);

                await _unitOfWork.SaveChangesAsync();

                CreateUserResponse responseNotExists = _mapper.Map<CreateUserResponse>(createdUser);


                return new BaseResponse<CreateUserResponse>(responseNotExists, true, "User created successfully");

            }
            catch (Exception e)
            {
                return new BaseResponse<CreateUserResponse>(null, false, $"Error: {e.Message}");
            }

        }
    }
}
