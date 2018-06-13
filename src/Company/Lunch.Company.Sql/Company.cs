using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lunch.Company.Sql
{
    public class Company
    {
        [Key]
        public Guid CompanyId { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        public int CompanySizeId { get; set; }
        public CompanySize CompanySize { get; set; }
        public ICollection<Office> Offices { get; set; }
    }

    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(company => company.CompanyId);

            builder.Property(company => company.Name).HasMaxLength(150).IsRequired();
            builder.HasIndex(company => company.Name);

            builder
                .HasMany(company => company.Offices)
                .WithOne(office => office.Company)
                .HasForeignKey(office => office.CompanyId);

            builder
                .HasOne(company => company.CompanySize)
                .WithMany()
                .HasForeignKey(company => company.CompanySizeId);
        }
    }
}
