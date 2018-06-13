using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lunch.Person.Sql
{
    public class Account
    {
        public Guid PersonId { get; set; }
        [MaxLength(150)]
        public string Password { get; set; }
    }

    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(account => account.Password).HasMaxLength(150).IsRequired();
            builder.HasKey(account => account.PersonId);
        }
    }
}
