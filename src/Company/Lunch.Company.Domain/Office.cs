using System;

namespace Lunch.Company.Domain
{
    public class Office
    {
        public Guid OfficeId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
