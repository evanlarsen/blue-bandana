using Lunch.Company.Domain.Dtos;
using System;
using System.Collections.Generic;

namespace Lunch.Company.Domain
{
    public interface ICompanyFactory
    {
        Company CreateNew(CreateNewCompanyDto dto);
    }

    public class CompanyFactory : ICompanyFactory
    {
        private readonly Errors errors;
        private readonly ICompanyRepository repository;

        public CompanyFactory(Errors errors, ICompanyRepository repository)
        {
            this.errors = errors;
            this.repository = repository;
        }

        public Company CreateNew(CreateNewCompanyDto dto)
        {
            var company = new Company(errors);
            company.CompanyId = Guid.NewGuid();
            company.Name = dto.Name;
            company.CompanySize = new CompanySize { CompanySizeId = dto.CompanySizeId };
            var office = new Office();
            office.OfficeId = Guid.NewGuid();
            var address = new Address();
            if (dto.Address.AddressId.HasValue)
            {
                address.AddressId = dto.Address.AddressId.Value;
            }
            office.Address = address;
            company.Offices = new List<Office> { office };
            return company;
        }
    }
}
