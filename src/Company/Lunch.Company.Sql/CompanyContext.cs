using Microsoft.EntityFrameworkCore;

namespace Lunch.Company.Sql
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) :
            base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyLocation> CompanyLocations { get; set; }
        public DbSet<CompanySize> CompanySizes { get; set; }
    }
}
