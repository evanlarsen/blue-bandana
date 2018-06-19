using Lunch.Company.Domain;
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
            var builder = new CompanySettingsBuilder();
            CompanySettings config = builder.GetSettings();
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
