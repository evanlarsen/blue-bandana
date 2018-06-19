using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Lunch.Company.Sql.Tests
{
    public class CompanyTests
    {
        private readonly MockCompanyData mock;
        public CompanyTests()
        {
            mock = new MockCompanyData();
        }

        [Fact]
        public async Task GivenACompanyShouldFindCompanyByAddress()
        {
            var options = new DbContextOptionsBuilder<CompanyContext>()
                .UseInMemoryDatabase(databaseName: "ShouldFindCompanyByAddress")
                .Options;
            using (var context = new CompanyContext(options))
            {
                await context.Database.EnsureCreatedAsync();
                var repository = new CompanyRepository(context);
                var address = new Domain.Address { AddressId = Guid.NewGuid(), StreetNumber = "1112", StreetAddress = "Carissa Dr.", City = "TTown", State = "FL", ZipCode = "32308" };
                var objectUnderTest = mock.MockCompany("FDHSMV", address);
                await repository.Add(objectUnderTest);
                var actualValue = await repository.SearchForCompaniesByAddress(address);
                Assert.NotNull(actualValue);
                Assert.Equal(objectUnderTest.Name, actualValue[0].Name);
            }
        }

        [Fact]
        public async Task GivenTwoCompaniesShouldFindCompanyByName()
        {
            var settingsBuilder = new CompanySettingsBuilder();
            var config = settingsBuilder.GetSettings();
            var options = new DbContextOptionsBuilder<CompanyContext>()
                .UseInMemoryDatabase(databaseName: "ShouldFindCompanyByAddress")
                .Options;
            using (var context = new CompanyContext(options))
            {
                await context.Database.EnsureCreatedAsync();
                var repository = new CompanyRepository(context);
                var company1 = mock.MockCompany("ABC");
                var company2 = mock.MockCompany("XYZ");
                await repository.Add(company1);
                await repository.Add(company2);
                var matchingCompanies = await repository.SearchForCompaniesByName("AB", config.SearchForCompanyByNameRecordCount);
                Assert.NotNull(matchingCompanies);
                Assert.Single(matchingCompanies);
                var company = matchingCompanies.First();
                Assert.Equal("ABC", company.Name);
            }
        }
    }
}
