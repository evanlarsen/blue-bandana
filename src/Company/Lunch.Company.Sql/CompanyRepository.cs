using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Lunch.Company.Sql
{
    public class CompanyRepository : Domain.ICompanyRepository
    {
        private readonly CompanyContext companyContext;
        private readonly CompanyMapper companyMapper;

        public CompanyRepository(CompanyContext companyContext)
        {
            this.companyContext = companyContext;
            companyMapper = new CompanyMapper();
        }

        public Task Add(Domain.Company dComp)
        {
            var company = companyMapper.MapToEntity(dComp);
            companyContext.Companies.Add(company);
            return companyContext.SaveChangesAsync();
        }

        public async Task<Domain.Company> Get(Guid id)
        {
            var company = await companyContext.Companies
                    .Include(c => c.CompanySize)
                    .Include(c => c.Offices).ThenInclude(cl => cl.Address)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(c => c.CompanyId == id);
            return companyMapper.MapFromEntity(company);
        }

        public async Task Update(Domain.Company dComp)
        {
            var company = await companyContext.Companies
                    .Include(c => c.CompanySize)
                    .Include(c => c.Offices).ThenInclude(cl => cl.Address)
                    .SingleOrDefaultAsync(c => c.CompanyId == dComp.CompanyId);

            companyMapper.MapToEntity(ref company, dComp);
            await companyContext.SaveChangesAsync();
        }

        private void GetCompaniesAggregate() => 
            companyContext.Companies
                .Include(c => c.CompanySize)
                .Include(c => c.Offices).ThenInclude(cl => cl.Address);
    }
}
