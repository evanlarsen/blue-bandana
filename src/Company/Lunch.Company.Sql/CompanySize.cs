using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lunch.Company.Sql
{
    public class CompanySize
    {
        [Key]
        public int CompanySizeId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }

    internal class CompanySizeConfiguration : IEntityTypeConfiguration<CompanySize>
    {
        public void Configure(EntityTypeBuilder<CompanySize> builder)
        {
            builder.HasKey(companySize => companySize.CompanySizeId);
            builder.HasData(new List<CompanySize>
            {
                new CompanySize { CompanySizeId = 1, From = 0, To = 49},
                new CompanySize { CompanySizeId = 2, From = 50, To = 99},
                new CompanySize { CompanySizeId = 3, From = 100, To = 199},
                new CompanySize { CompanySizeId = 4, From = 200, To = 9999},
            });
        }
    }
}
