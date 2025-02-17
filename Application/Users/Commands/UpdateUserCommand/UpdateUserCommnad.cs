using Application.Commons.Responses;
using Application.Users.Commands.UpdateUserCommand.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommnad : IRequest<BaseResponse<bool>>
    {
        public UpdateUserCommandDto updateUserCommandDto { get; set; }

        public string UserSubProvider { get; set; }

        public UpdateUserCommnad(UpdateUserCommandDto _updateUserCommandDto, string userSubProvider)
        {
            updateUserCommandDto = _updateUserCommandDto;
            UserSubProvider = userSubProvider;
        }
    }
   
}
