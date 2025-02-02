using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Commands.UpdateTaskListCommand.Validator
{
    public class UpdateTaskListValidator: AbstractValidator<UpdateTaskListCommand>
    {
        public UpdateTaskListValidator()
        { 
            RuleFor(x => x.UpdateTaskListDto.NewName).NotEmpty().WithMessage("New Name is required");
            RuleFor(x => x.UpdateTaskListDto.NewName).MaximumLength(20).WithMessage("New Name must not exceed 20 characters");
            RuleFor(x => x.UpdateTaskListDto.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.UserSubProvider).NotEmpty().WithMessage("UserId is required");


        }
    }
}
