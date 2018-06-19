using Lunch.Infrastructure.Exceptions;

namespace Lunch.Company.Domain
{
    public class Errors
    {
        public ValidationError SearchForCompanyByAddressNotACompleteAddress()
        {
            return new ValidationError(
                "search-for-company-by-address-not-a-complete-address",
                "The address selected was not a complete address. You must select an address from the list of suggested addresses.");
        }
    }
}
