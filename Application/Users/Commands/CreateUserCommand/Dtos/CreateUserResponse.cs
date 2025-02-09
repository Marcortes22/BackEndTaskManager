using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUserCommand.Dtos
{
    public class CreateUserResponse
    {
        public string Id { get; set; }

        public bool isNewUser { get; set; }

    }
}
