using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUserCommand.Validator
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommnad>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.updateUserCommandDto.newBackGroundImage).NotEmpty().NotNull();
        }
    }
}
