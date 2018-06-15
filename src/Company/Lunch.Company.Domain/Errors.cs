using Lunch.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lunch.Company.Domain
{
    public class Errors
    {
        public static ValidationError AddressStreetNumberNotFound()
        {
            return new ValidationError("address-street-number-is-required", "Street number is a required field.");
        }
    }
}
