using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lunch.Company.Domain
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(Guid personId);
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetCustomersByOffice(Guid officeId);
    }
}
