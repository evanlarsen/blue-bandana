using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lunch.Company.Sql
{
    public class Address
    {
        public Guid OfficeId { get; set; }
        public string StreetNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PostalCode { get; set; }
    }
}
