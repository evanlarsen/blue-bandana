using Lunch.Company.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lunch.Company.Sql
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyContext store;
        private readonly CompanyMapper mapper;
        private readonly ICompanyFactory companyFactory;

        public CompanyRepository(CompanyContext companyContext, ICompanyFactory companyFactory)
        {
            this.store = companyContext;
            this.companyFactory = companyFactory;
            mapper = new CompanyMapper();
        }

        public async Task<List<Domain.Company>> SearchForCompaniesByAddress(Domain.Address dAddr)
        {
            // Func<string, string, bool> equals = (left, right) => string.Equals(left, right, StringComparison.CurrentCultureIgnoreCase);
            var query = from company in store.Companies
                               from office in company.Offices
                               where string.Equals(office.Address.StreetNumber, dAddr.StreetNumber, StringComparison.CurrentCultureIgnoreCase)
                               && string.Equals(office.Address.StreetAddress, dAddr.StreetAddress, StringComparison.CurrentCultureIgnoreCase)
                               && string.Equals(office.Address.City, dAddr.City, StringComparison.CurrentCultureIgnoreCase)
                               && string.Equals(office.Address.State, dAddr.State, StringComparison.CurrentCultureIgnoreCase)
                               && string.Equals(office.Address.ZipCode, dAddr.ZipCode, StringComparison.CurrentCultureIgnoreCase)
                               select company;
            query = IncludeAll(query);

            var companies = await query.ToListAsync();
            if (companies == null || companies.Count() == 0)
            {
                return null;
            }
            return companies.ConvertAll(c => mapper.MapFromEntity(c));
        }
        
        public async Task<List<Domain.Company>> SearchForCompaniesByName(string name, int take)
        {
            var query = from company in store.Companies
                        where company.Name.ToUpper().Contains(name.ToUpper())
                        select company;
            query = IncludeAll(query);
            var companies = await query.Take(take).ToListAsync();
            if (companies == null || companies.Count() == 0)
            {
                return null;
            }
            return companies.ConvertAll(c => mapper.MapFromEntity(c));
        }

        public Task Add(Domain.Company dComp)
        {
            var company = mapper.MapToEntity(dComp);
            store.Companies.Add(company);
            return store.SaveChangesAsync();
        }

        public async Task<Domain.Company> Get(Guid id)
        {
            var company = await IncludeAll(store.Companies)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(c => c.CompanyId == id);
            return mapper.MapFromEntity(company);
        }

        public async Task Update(Domain.Company dComp)
        {
            var company = await IncludeAll(store.Companies)
                    .SingleOrDefaultAsync(c => c.CompanyId == dComp.CompanyId);

            mapper.MapToEntity(ref company, dComp);
            await store.SaveChangesAsync();
        }

        private IQueryable<Company> IncludeAll(IQueryable<Company> companies) => 
            companies
                .Include(c => c.CompanySize)
                .Include(c => c.Offices).ThenInclude(cl => cl.Address);
    }
}
