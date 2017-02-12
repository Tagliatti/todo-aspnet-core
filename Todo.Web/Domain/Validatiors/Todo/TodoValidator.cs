using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Todo.Web.Domain.Validatiors.Todo
{
    public class TodoValidator : Validation<Domain.Entities.Todo>
    {
        public TodoValidator(Entities.Todo todo)
        {
            RuleFor(_todo => _todo.Title).NotEmpty();
            RuleFor(_todo => _todo.Title).Length(5, 50);
            RuleFor(_todo => _todo.Description).NotEmpty();
            RuleFor(_todo => _todo.Description).Length(5, 300);

            Validate(todo);
        }
    }
}
