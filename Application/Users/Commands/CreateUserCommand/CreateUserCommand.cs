using Application.Commons.Responses;
using Application.Users.Commands.CreateUserCommand.Dtos;
using MediatR;


namespace Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<BaseResponse<CreateUserResponse>>
    {
        public CreateUserDto createUserDto { get; set; }

        public CreateUserCommand(CreateUserDto _createUserDto)
        {
            createUserDto = _createUserDto;

        }
    }
}
