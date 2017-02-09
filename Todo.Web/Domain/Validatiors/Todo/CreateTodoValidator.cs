using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Todo.Web.Domain.Validatiors.Todo
{
    public class CreateTodoValidator : AbstractValidator<Domain.Entities.Todo>
    {
        public ValidationResult _results;

        public CreateTodoValidator(Domain.Entities.Todo todo)
        {
            RuleFor(_todo => _todo.Title).NotNull().NotEmpty();
            RuleFor(_todo => _todo.Description).NotNull().NotEmpty();

            _results = Validate(todo);
        }

        public bool IsValid => _results.IsValid;

        public IEnumerable<ValidationMessage> Errors {
            get
            {
                return from x in _results.Errors
                       select new ValidationMessage(x.ErrorMessage, x.PropertyName);
            }
        }
    }
}
