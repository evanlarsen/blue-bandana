using Lunch.Company.Domain;
using Lunch.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Lunch.Company.Sql.Tests
{
    public class CompanySettingsBuilder : ISettingsBuilder<CompanySettings>
    {
        private CompanySettings settings;

        public CompanySettings GetSettings()
        {
            if (settings == null)
            {
                settings = Build();
            }
            return settings;
        }

        private CompanySettings Build()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configuration = configurationBuilder.Build();
            var companySection = configuration.GetSection(nameof(CompanySettings));
            var config = companySection.Get<CompanySettings>();

            if (config == null)
            {
                throw new ArgumentException($"The application settings for {nameof(CompanySettings)} is missing");
            }
            if (string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                throw new ArgumentException($"The application settings for {nameof(CompanySettings)} is missing {nameof(CompanySettings.ConnectionString)}");
            }
            if (config.SearchForCompanyByNameRecordCount == 0)
            {
                throw new ArgumentException($"The applications settings for {nameof(CompanySettings)} is missing {nameof(CompanySettings.SearchForCompanyByNameRecordCount)}");
            }

            return config;
        }
    }
}
