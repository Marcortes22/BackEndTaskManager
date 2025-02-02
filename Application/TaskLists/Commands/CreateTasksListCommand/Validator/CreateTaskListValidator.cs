using Application.TaskLists.Commands.CreateTsksListCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Commands.CreateTasksListCommand.Validator
{
    public class CreateTaskListValidator: AbstractValidator<CreateTaskListCommand>
    {
        public CreateTaskListValidator()
        {
            RuleFor(x => x.createTaskListDto.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.createTaskListDto.Name).MaximumLength(20).WithMessage("Name must not exceed 20 characters");
            RuleFor(x => x.UserSubProvider).NotEmpty().WithMessage("UserId is required");
        }
    }
}
