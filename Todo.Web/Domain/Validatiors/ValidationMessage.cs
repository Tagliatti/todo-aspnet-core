using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Web.Domain.Validatiors
{
    public class ValidationMessage
    {
        public string PropertyName { get; }

        public string ErrorMessage { get; }

        public object AttemptedValue { get; private set; }

        public ValidationMessage(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public ValidationMessage(string propertyName, string errorMessage, object attemptedValue)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            AttemptedValue = attemptedValue;
        }

        public override string ToString()
        {
            return this.ErrorMessage;
        }
    }
}
