using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lunch.Company.Sql
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }
        [MaxLength(20)]
        public string StreetNumber { get; set; }
        [MaxLength(100)]
        public string StreetAddress { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(25)]
        public string State { get; set; }
        [MaxLength(10)]
        public string ZipCode { get; set; }
        [MaxLength(10)]
        public string PostalCode { get; set; }
    }

    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(address => address.AddressId);
            builder.Property(address => address.StreetNumber).HasMaxLength(20);
            builder.Property(address => address.StreetAddress).HasMaxLength(100);
            builder.Property(address => address.City).HasMaxLength(50);
            builder.Property(address => address.State).HasMaxLength(25);
            builder.Property(address => address.ZipCode).HasMaxLength(10);
            builder.Property(address => address.PostalCode).HasMaxLength(10);
            builder.HasIndex(address => address.StreetAddress);
            builder.HasIndex(address => new { address.StreetNumber, address.StreetAddress, address.City, address.State, address.ZipCode });
        }
    }
}
