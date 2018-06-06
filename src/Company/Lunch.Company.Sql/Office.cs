using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lunch.Company.Sql
{
    public class Office
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid OfficeId { get; set; }
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Address Address { get; set; }
    }
}
