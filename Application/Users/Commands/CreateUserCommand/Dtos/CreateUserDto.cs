using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUserCommand.Dtos
{
    public class CreateUserDto
    {
        

        public string timeZone { get; set; }

        public CreateUserDto( string timeZone)
        {
  
            this.timeZone = timeZone;
        }
    }
}
