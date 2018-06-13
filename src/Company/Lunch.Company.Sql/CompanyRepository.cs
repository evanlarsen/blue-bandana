using Lunch.Company.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lunch.Company.Sql
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyContext store;
        private readonly CompanyMapper mapper;

        public CompanyRepository(CompanyContext companyContext)
        {
            this.store = companyContext;
            mapper = new CompanyMapper();
        }

        public async Task<Domain.Company> FindCompanyFromAddress(Domain.Address dAddr)
        {
            // Func<string, string, bool> equals = (left, right) => string.Equals(left, right, StringComparison.CurrentCultureIgnoreCase);
            var companyQuery = from company in store.Companies
                               from office in company.Offices
                               where string.Equals(office.Address.StreetNumber, dAddr.StreetNumber, StringComparison.CurrentCultureIgnoreCase)
                               && string.Equals(office.Address.StreetAddress, dAddr.StreetAddress, StringComparison.CurrentCultureIgnoreCase)
                               && string.Equals(office.Address.City, dAddr.City, StringComparison.CurrentCultureIgnoreCase)
                               && string.Equals(office.Address.State, dAddr.State, StringComparison.CurrentCultureIgnoreCase)
                               && string.Equals(office.Address.ZipCode, dAddr.ZipCode, StringComparison.CurrentCultureIgnoreCase)
                               select company;

            var foundCompany = await companyQuery.FirstOrDefaultAsync();
            if (foundCompany == null)
            {
                return null;
            }
            return mapper.MapFromEntity(foundCompany);
        }

        public Task Add(Domain.Company dComp)
        {
            var company = mapper.MapToEntity(dComp);
            store.Companies.Add(company);
            return store.SaveChangesAsync();
        }

        public async Task<Domain.Company> Get(Guid id)
        {
            var company = await store.Companies
                    .Include(c => c.CompanySize)
                    .Include(c => c.Offices).ThenInclude(cl => cl.Address)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(c => c.CompanyId == id);
            return mapper.MapFromEntity(company);
        }

        public async Task Update(Domain.Company dComp)
        {
            var company = await store.Companies
                    .Include(c => c.CompanySize)
                    .Include(c => c.Offices).ThenInclude(cl => cl.Address)
                    .SingleOrDefaultAsync(c => c.CompanyId == dComp.CompanyId);

            mapper.MapToEntity(ref company, dComp);
            await store.SaveChangesAsync();
        }

        private void GetCompaniesAggregate() => 
            store.Companies
                .Include(c => c.CompanySize)
                .Include(c => c.Offices).ThenInclude(cl => cl.Address);
    }
}
