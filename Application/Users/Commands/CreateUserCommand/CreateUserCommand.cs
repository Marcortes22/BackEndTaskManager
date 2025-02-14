using Application.Commons.Responses;
using Application.Users.Commands.CreateUserCommand.Dtos;
using MediatR;


namespace Application.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<BaseResponse<CreateUserResponse>>
    {
        public CreateUserDto createUserDto { get; set; }

        public string auth0Token { get; set; }

        public string UserSubProvider { get; set; }

        public CreateUserCommand(CreateUserDto _createUserDto, string auth0Token, string userSubProvider)
        {
            createUserDto = _createUserDto;
            this.auth0Token = auth0Token;
            UserSubProvider = userSubProvider;
        }
    }
}
