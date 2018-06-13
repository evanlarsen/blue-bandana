using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lunch.Person.Sql
{
    public class Person
    {
        public Guid PersonId { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Account Account { get; set; }
    }

    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(person => person.PersonId);
            builder.Property(person => person.Name).HasMaxLength(150).IsRequired();
            builder.Property(person => person.Email).HasMaxLength(150).IsRequired();
            builder
                .HasOne(person => person.Account)
                .WithOne()
                .HasForeignKey<Account>(account => account.PersonId);
            builder
                .HasOne(person => person.PhoneNumber)
                .WithOne()
                .HasForeignKey<PhoneNumber>(phoneNumber => phoneNumber.PersonId);
        }
    }
}
