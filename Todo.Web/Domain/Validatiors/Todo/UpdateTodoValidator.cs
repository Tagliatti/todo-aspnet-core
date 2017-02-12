using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Todo.Web.Domain.Validatiors.Todo
{
    public class UpdateTodoValidator : TodoValidator
    {
        public UpdateTodoValidator(Domain.Entities.Todo todo) : base(todo)
        {
            RuleFor(_todo => _todo.Id).NotEmpty().GreaterThan(0);

            Validate(todo);
        }
    }
}
