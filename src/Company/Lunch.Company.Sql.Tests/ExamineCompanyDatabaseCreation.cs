using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace Lunch.Company.Sql.Tests
{
    public class ExamineCompanyDatabaseCreation
    {
        [Fact]
        public async Task CreateCompanyDatabase()
        {
            CompanyConfigurationBuilder builder = new CompanyConfigurationBuilder();
            CompanyConfiguration config = builder.Build();
            var options = new DbContextOptionsBuilder<CompanyContext>()
                .UseSqlServer(config.ConnectionString)
                .Options;
            using (var context = new CompanyContext(options))
            {
                // await context.Database.EnsureDeletedAsync();                
            }
        }
    }
}
