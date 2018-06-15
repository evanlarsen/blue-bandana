using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunch.Company.Domain
{
    public interface ICompanyService
    {
        Task<List<Company>> SearchForCompanyByAddress(Address address);
    }

    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public Task<List<Company>> SearchForCompanyByAddress(Address address)
        {
            return companyRepository.SearchForCompaniesByAddress(address);
        }
    }
}
