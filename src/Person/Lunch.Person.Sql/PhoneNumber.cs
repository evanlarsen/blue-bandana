using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lunch.Person.Sql
{
    public class PhoneNumber
    {
        public Guid PersonId { get; set; }
        [MaxLength(15)]
        public string Number { get; set; }
        public bool IsVerified { get; set; }
        public int? VerificationCode { get; set; }
        public DateTime? VerificationCodeCreatedDate { get; set; }
    }

    internal class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.HasKey(phoneNumber => phoneNumber.PersonId);
            builder.Property(phoneNumber => phoneNumber.Number).HasMaxLength(15).IsRequired();
            builder.HasAlternateKey(phoneNumber => phoneNumber.Number);
            builder.Property(phoneNumber => phoneNumber.IsVerified).HasDefaultValue(false);
            builder.HasIndex(phoneNumber => phoneNumber.Number);
        }
    }
}
