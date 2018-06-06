using Microsoft.EntityFrameworkCore;

namespace Lunch.Person.Sql
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) :
            base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
