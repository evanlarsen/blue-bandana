namespace Lunch.Company.Sql
{
    internal class CustomerMapper
    {
        public Customer MapToEntity(Domain.Customer dCust)
        {
            var customer = new Customer();
            customer.PersonId = dCust.PersonId;
            customer.OfficeId = dCust.OfficeId;
            customer.IsOfficeManager = dCust.IsOfficeManager;
            return customer;
        }

        public Domain.Customer MapFromEntity(Customer customer)
        {
            var dCust = new Domain.Customer();
            dCust.PersonId = customer.PersonId;
            dCust.OfficeId = customer.OfficeId;
            dCust.IsOfficeManager = customer.IsOfficeManager;
            return dCust;
        }
    }
}
