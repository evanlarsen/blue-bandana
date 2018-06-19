using Lunch.Infrastructure;
using Lunch.Infrastructure.Exceptions;
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
        private readonly Errors errors;
        private readonly ISettingsBuilder<CompanySettings> settingsBuilder;

        public CompanyService(
            ICompanyRepository companyRepository, 
            Errors errors,
            ISettingsBuilder<CompanySettings> settingsBuilder)
        {
            this.companyRepository = companyRepository;
            this.errors = errors;
            this.settingsBuilder = settingsBuilder;
        }

        public Task<List<Company>> SearchForCompanyByAddress(Address address)
        {
            if (string.IsNullOrWhiteSpace(address.StreetNumber)
                || string.IsNullOrWhiteSpace(address.StreetAddress)
                || string.IsNullOrWhiteSpace(address.City)
                || string.IsNullOrWhiteSpace(address.State)
                || string.IsNullOrWhiteSpace(address.ZipCode))
            {
                throw new BusinessRuleException<ValidationError>(errors.SearchForCompanyByAddressNotACompleteAddress());
            }

            return companyRepository.SearchForCompaniesByAddress(address);
        }

        public Task<List<Company>> SearchForCompanyByName(string name)
        {
            var settings = settingsBuilder.GetSettings();
            return companyRepository.SearchForCompaniesByName(name, settings.SearchForCompanyByNameRecordCount);
        }
    }
}
