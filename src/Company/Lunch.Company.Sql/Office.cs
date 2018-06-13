using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lunch.Company.Sql
{
    public class Office
    {
        [Key]
        public Guid OfficeId { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public List<Customer> Customers { get; set; }
    }

    internal class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(office => office.OfficeId);
            builder.Property(office => office.Name).HasMaxLength(150);
            builder
                .HasOne(office => office.Company)
                .WithMany(company => company.Offices)
                .HasForeignKey(office => office.CompanyId);
            builder
                .HasOne(office => office.Address)
                .WithOne()
                .HasForeignKey<Office>(office => office.AddressId);
        }
    }
}
