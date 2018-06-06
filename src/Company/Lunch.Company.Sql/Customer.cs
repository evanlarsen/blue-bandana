using System;

namespace Lunch.Company.Sql
{
    public class Customer
    {
        public Guid PersonId { get; set; }
        public Guid OfficeId { get; set; }
        public bool IsOfficeManager { get; set; }
    }
}
