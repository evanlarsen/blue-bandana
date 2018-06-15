using System;
using System.Collections.Generic;

namespace Lunch.Company.Sql.Tests
{
    internal class MockCompanyData
    {
        public Domain.Company MockCompany(string companyName, Domain.Address address)
        {
            var company = new Domain.Company();
            company.CompanySize = new Domain.CompanySize { CompanySizeId = 1 };
            company.CompanyId = Guid.NewGuid();
            company.Name = "FDHSMV";
            var office = new Domain.Office();
            office.OfficeId = Guid.NewGuid();
            office.Address = address;
            company.Offices = new List<Domain.Office> { office };
            return company;
        }

        public Domain.Company MockCompany(string companyName)
        {
            var company = new Domain.Company();
            company.CompanySize = new Domain.CompanySize { CompanySizeId = 1 };
            company.CompanyId = Guid.NewGuid();
            company.Name = companyName;
            var office = new Domain.Office();
            office.OfficeId = Guid.NewGuid();
            office.Address = new Domain.Address { AddressId = Guid.NewGuid(), StreetNumber = "1112", StreetAddress = "Carissa Dr.", City = "TTown", State = "FL", ZipCode = "32308" };
            company.Offices = new List<Domain.Office> { office };
            return company;
        }
    }
}
