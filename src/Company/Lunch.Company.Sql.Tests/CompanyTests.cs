using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Lunch.Company.Sql.Tests
{
    public class CompanyTests
    {
        [Fact]
        public async Task GivenACompanyShouldFindCompanyByAddress()
        {
            var options = new DbContextOptionsBuilder<CompanyContext>()
                .UseInMemoryDatabase(databaseName: "ShouldFindCompanyByAddress")
                .Options;
            using (var context = new CompanyContext(options))
            {
                var repository = new CompanyRepository(context);
                var address = new Domain.Address { AddressId = Guid.NewGuid(), StreetNumber = "1112", StreetAddress = "Carissa Dr.", City = "TTown", State = "FL", ZipCode = "32308" };
                var objectUnderTest = MockCompany("FDHSMV", address);
                await repository.Add(objectUnderTest);

                var actualValue = await repository.FindCompanyFromAddress(address);
                Assert.NotNull(actualValue);
                Assert.Equal(objectUnderTest.Name, actualValue.Name);
            }
        }

        private Domain.Company MockCompany(string companyName, Domain.Address address)
        {
            var company = new Domain.Company();
            company.CompanyId = Guid.NewGuid();
            company.CompanySize = new Domain.CompanySize { CompanySizeId = 1 };
            company.Name = "FDHSMV";
            var office = new Domain.Office();
            office.OfficeId = Guid.NewGuid();
            office.Address = address;
            company.Offices = new List<Domain.Office> { office };
            return company;
        }
    }
}
