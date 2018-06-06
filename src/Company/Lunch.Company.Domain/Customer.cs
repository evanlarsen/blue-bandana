using System;

namespace Lunch.Company.Domain
{
    public class Customer
    {
        public Guid PersonId { get; set; }
        public Guid OfficeId { get; set; }
        public bool IsOfficeManager { get; set; }
    }
}
