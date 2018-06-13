using Microsoft.EntityFrameworkCore;

namespace Lunch.Person.Sql
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) :
            base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());
        }
    }
}
