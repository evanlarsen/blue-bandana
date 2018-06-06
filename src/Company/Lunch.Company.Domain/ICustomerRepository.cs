using System;
using System.Threading.Tasks;

namespace Lunch.Company.Domain
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(Guid id);
        Task Add(Customer customer);
        Task Update(Customer customer);
    }
}
