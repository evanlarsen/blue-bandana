using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunch.Company.Domain
{
    public interface ICompanyRepository
    {
        Task<List<Company>> SearchForCompaniesByAddress(Address dAddr);
        Task<List<Company>> SearchForCompaniesByName(string name);
        Task<Company> Get(Guid id);
        Task Add(Company company);
        Task Update(Company company);
    }
}
