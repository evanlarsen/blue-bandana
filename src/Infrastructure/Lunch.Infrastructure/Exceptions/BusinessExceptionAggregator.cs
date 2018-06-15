using System.Collections.Generic;

namespace Lunch.Infrastructure.Exceptions
{
    public class BusinessExceptionAggregator<T>
    {
        private readonly List<T> errors = new List<T>();

        public void AddError(T error)
        {
            errors.Add(error);
        }

        public void Validate()
        {
            if (errors.Count > 0)
            {
                ThrowBusinessRuleException(errors);
            }
        }

        protected virtual void ThrowBusinessRuleException(List<T> errors)
        {
            throw new BusinessRuleException<T>(errors);
        }
    }

    public class BusinessExceptionAggregator : BusinessExceptionAggregator<ValidationError>
    {
        protected override void ThrowBusinessRuleException(List<ValidationError> errors)
        {
            throw new BusinessRuleException<ValidationError>(errors);
        }
    }
}
