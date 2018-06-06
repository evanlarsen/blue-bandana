using System;

namespace Lunch.Company.Domain
{
    public class CompanyLocation
    {
        public Guid CompanyLocationId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
