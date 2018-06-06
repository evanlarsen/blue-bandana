using System;
using System.Threading.Tasks;

namespace Lunch.Company.Domain
{
    public interface ICompanyRepository
    {
        Task<Company> Get(Guid id);
        Task Add(Company company);
        Task Update(Company company);
    }
}
