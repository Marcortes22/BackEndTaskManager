using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskLists.Commands.DeleteTaskListCommand.Validator
{
    public class DeleteTaskListValidator:AbstractValidator<DeleteTaskListCommand>
    {
        public DeleteTaskListValidator() { 
        
            RuleFor(x => x.taskListId).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.userSubProvider).NotEmpty().WithMessage("UserSubProvider is required");
        }
    }
}
