using System;
using System.Linq;

namespace Lunch.Company.Sql
{
    internal class CompanyMapper
    {
        public Domain.Company MapFromEntity(Company company)
        {
            var dComp = new Domain.Company();
            dComp.CompanyId = company.CompanyId;
            dComp.Name = company.Name;
            dComp.CompanySize = MapCompanySize(company.CompanySize);
            dComp.Offices = company.Offices.Select(cl => MapOffice(cl)).ToHashSet();
            return dComp;
        }

        public Company MapToEntity(Domain.Company dComp)
        {
            var company = new Company();
            MapToEntity(ref company, dComp);
            return company;
        }

        public void MapToEntity(ref Company company, Domain.Company dComp)
        {
            company.CompanyId = dComp.CompanyId;
            company.Name = dComp.Name;
            company.CompanySize = MapCompanySize(dComp.CompanySize);
            company.CompanySizeId = company.CompanySize.CompanySizeId;
            company.Offices = dComp.Offices.Select(dLoc => MapOffice(dLoc, dComp.CompanyId)).ToHashSet();
        }

        private Domain.CompanySize MapCompanySize(CompanySize companySize)
        {
            var dSize = new Domain.CompanySize();
            dSize.CompanySizeId = companySize.CompanySizeId;
            dSize.From = companySize.From;
            dSize.To = companySize.To;
            return dSize;
        }

        private CompanySize MapCompanySize(Domain.CompanySize dSize)
        {
            var companySize = new CompanySize();
            companySize.CompanySizeId = dSize.CompanySizeId;
            companySize.From = dSize.From;
            companySize.To = dSize.To;
            return companySize;
        }

        private Domain.Office MapOffice(Office office)
        {
            var dLoc = new Domain.Office();
            dLoc.Address = MapAddress(office.Address);
            dLoc.OfficeId = office.OfficeId;
            dLoc.Name = office.Name;
            return dLoc;
        }

        private Office MapOffice(Domain.Office dLoc, Guid companyId)
        {
            var office = new Office();
            office.Address = MapAddress(dLoc.Address);
            office.OfficeId = dLoc.OfficeId;
            office.Name = dLoc.Name;
            office.CompanyId = companyId;
            return office;
        }

        private Domain.Address MapAddress(Address address)
        {
            var dAddr = new Domain.Address();
            dAddr.AddressId = address.AddressId;
            dAddr.City = address.City;
            dAddr.PostalCode = address.PostalCode;
            dAddr.State = address.State;
            dAddr.StreetAddress = address.StreetAddress;
            dAddr.StreetNumber = address.StreetNumber;
            dAddr.ZipCode = address.ZipCode;
            return dAddr;
        }

        private Address MapAddress(Domain.Address dAddr)
        {
            var address = new Address();
            address.AddressId = dAddr.AddressId;
            address.City = dAddr.City;
            address.PostalCode = dAddr.PostalCode;
            address.State = dAddr.State;
            address.StreetAddress = dAddr.StreetAddress;
            address.StreetNumber = dAddr.StreetNumber;
            address.ZipCode = dAddr.ZipCode;
            return address;
        }
    }
}
