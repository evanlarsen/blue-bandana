using System;
using System.Collections.Generic;
using System.Linq;

namespace Lunch.Infrastructure.Exceptions
{
    public class BusinessRuleException<T> : Exception
    {
        public List<T> ValidationMessages { get; private set; }

        public BusinessRuleException(params T[] validationMessages)
        {
            ValidationMessages = validationMessages.ToList();
        }

        public BusinessRuleException(IEnumerable<T> validationMessages)
        {
            ValidationMessages = validationMessages.ToList();
        }
    }
}
