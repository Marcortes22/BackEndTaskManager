using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Commands.UpdateTaskItemCommand.Validator
{
    public class UpdateTaskItemValidator:AbstractValidator<UpdateTaskItemCommand>
    {
        public UpdateTaskItemValidator() {
            RuleFor(x => x.updateTaskItemDto.Title).MaximumLength(100).WithMessage("Title must not exceed 100 characters");
            RuleFor(x => x.updateTaskItemDto.Note).MaximumLength(150).WithMessage("Note must not exceed 150 characters");
            RuleFor(x => x.TaskItemId).NotEmpty().WithMessage("TaskItemId is required");
        }
    }
}
