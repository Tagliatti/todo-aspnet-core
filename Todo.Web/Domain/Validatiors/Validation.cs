using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Todo.Web.Domain.Validatiors
{
    public abstract class Validation<T> : AbstractValidator<T> where T : new()
    {
        public ValidationResult Results { get; private set; }

        public bool IsValid => Results.IsValid;

        public IEnumerable<ValidationMessage> Errors => Results.Errors;

        public new void Validate(T instance)
        {
            if (Equals(instance, default(T)))
            {
                instance = new T();
            }

            Results = new ValidationResult(base.Validate(instance).Errors);
        }
    }
}
