using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskItems.Commands.CreateTaskItemCommand.Validator
{
    public class CreateTaskItemValidator:AbstractValidator<CreateTaskItemCommand>

    {

        public CreateTaskItemValidator()
        {
            RuleFor(x => x.createTaskItemDto.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.createTaskItemDto.Title).MaximumLength(100).WithMessage("Title must not exceed 100 characters");
            RuleFor(x => x.createTaskItemDto.Note).MaximumLength(150).WithMessage("Note must not exceed 150 characters");
            RuleFor(x => x.createTaskItemDto.TaskListId).NotEmpty().WithMessage("TaskListId is required");
            //RuleFor(x => x.createTaskItemDto.DueDate).Must(date => DateTime);
        }
    }
}
