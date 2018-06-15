using Lunch.Infrastructure.Exceptions;
using System;

namespace Lunch.Company.Domain
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string StreetNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PostalCode { get; set; }

        public void Validate()
        {
            var agg = new BusinessExceptionAggregator();
            if (string.IsNullOrWhiteSpace(StreetNumber))
            {
                agg.AddError(Errors.AddressStreetNumberNotFound());
            }
        }
    }
}
