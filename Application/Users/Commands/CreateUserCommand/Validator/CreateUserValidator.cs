using Application.Users.Commands.CreateUserCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUserCommand.Validator
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.createUserDto.timeZone).NotEmpty().NotNull()
           .Must(BeAValidTimeZone).WithMessage("Time zone is not valid.");
        }

        private bool BeAValidTimeZone(string timeZoneId)
        {
            return TimeZoneInfo.GetSystemTimeZones()
                               .Any(tz => tz.Id.Equals(timeZoneId, StringComparison.OrdinalIgnoreCase));
        }
    }
}
