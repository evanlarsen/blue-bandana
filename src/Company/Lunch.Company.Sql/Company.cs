using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lunch.Company.Sql
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public int CompanySizeId { get; set; }
        public CompanySize CompanySize { get; set; }
        public ICollection<CompanyLocation> CompanyLocations { get; set; }
    }
}
