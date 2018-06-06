using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lunch.Company.Sql
{
    public class CompanyLocation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CompanyLocationId { get; set; }
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
