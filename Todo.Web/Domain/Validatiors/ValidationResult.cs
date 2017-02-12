using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Todo.Web.Domain.Validatiors
{
    public class ValidationResult
    {
        private readonly IList<ValidationFailure> errors;

        public ValidationResult()
        {
            errors = new List<ValidationFailure>();
        }

        public ValidationResult(IEnumerable<ValidationFailure> failures)
        {
            errors = failures.Where(failure => failure != null).ToList();
        }

        public IEnumerable<ValidationMessage> Errors => from x in errors
                                                        select new ValidationMessage(x.PropertyName, x.ErrorMessage, x.AttemptedValue);

        public virtual bool IsValid => errors.Count == 0;
    }
}
