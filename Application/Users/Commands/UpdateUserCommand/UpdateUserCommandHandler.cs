using Application.Commons.Responses;
using Application.TaskLists.Commands.CreateTsksListCommand;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IUnitOfWork;
using Domain.Utils;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommnad, BaseResponse<bool>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateUserCommnad> _validator;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<UpdateUserCommnad> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<BaseResponse<bool>> Handle(UpdateUserCommnad request, CancellationToken cancellationToken)
        {
            try
            {
                await _validator.ValidateAndThrowAsync(request);

                string userId = StringFunctions.GetUserSub(request.UserSubProvider);

                User user = await _unitOfWork.users.GetByIdAsync(userId);

                if (user == null)
                {
                    return new BaseResponse<bool>(false, false, "User not found");
                }

                user.backGroundImage = request.updateUserCommandDto.newBackGroundImage;

                await _unitOfWork.users.UpdateAsync(user);

                await _unitOfWork.SaveChangesAsync();

                return new BaseResponse<bool>(true, true, "User updated successfully");

            }
            catch (Exception e)
            {
                return new BaseResponse<bool>(false, false, $"Error: {e.Message}");
            }
        }
    }
}
