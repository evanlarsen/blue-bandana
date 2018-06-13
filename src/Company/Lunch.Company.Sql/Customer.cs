using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Lunch.Company.Sql
{
    public class Customer
    {
        public Guid PersonId { get; set; }
        public Guid OfficeId { get; set; }
        public Office Office { get; set; }
        public bool IsOfficeManager { get; set; }
    }

    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(customer => new { customer.OfficeId, customer.PersonId });
            builder
                .HasOne(customer => customer.Office)
                .WithMany(office => office.Customers)
                .HasForeignKey(customer => customer.OfficeId);
            builder.HasIndex(customer => customer.PersonId);
        }
    }
}
