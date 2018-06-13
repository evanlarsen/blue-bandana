using Lunch.Company.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lunch.Company.Sql
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CompanyContext context;
        private readonly CustomerMapper mapper;

        public CustomerRepository(CompanyContext context)
        {
            this.context = context;
            mapper = new CustomerMapper();
        }

        public Task AddCustomer(Domain.Customer dCust)
        {
            var customer = mapper.MapToEntity(dCust);
            context.Customers.Add(customer);
            return context.SaveChangesAsync();
        }

        public async Task<Domain.Customer> GetCustomer(Guid personId)
        {
            var customer = await context.Customers.SingleOrDefaultAsync(c => c.PersonId == personId);
            return mapper.MapFromEntity(customer);
        }

        public async Task<IEnumerable<Domain.Customer>> GetCustomersByOffice(Guid officeId)
        {
            var customers = await context.Customers.Where(c => c.OfficeId == officeId).ToArrayAsync();
            return customers.Select(c => mapper.MapFromEntity(c));
        }

        public async Task UpdateCustomer(Domain.Customer dCust)
        {
            var customer = await context.Customers
                .SingleOrDefaultAsync(c => c.OfficeId == dCust.OfficeId && c.PersonId == dCust.PersonId);

            customer.IsOfficeManager = dCust.IsOfficeManager;
            await context.SaveChangesAsync();
        }
    }
}
