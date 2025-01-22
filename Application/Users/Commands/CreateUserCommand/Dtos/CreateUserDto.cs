using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUserCommand.Dtos
{
    public class CreateUserDto
    {
        public string auth0Token { get; set; }

        public CreateUserDto(string _auth0Token)
        {
            auth0Token = _auth0Token;
        }
    }
}
