using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Lunch.Company.Sql.Tests
{
    public class CompanyConfiguration
    {
        public string ConnectionString { get; set; }
    }

    internal class CompanyConfigurationBuilder
    {
        public CompanyConfiguration Build()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configuration = configurationBuilder.Build();
            var config = new CompanyConfiguration();
            configuration.Bind(nameof(CompanyConfiguration), config);

            if (string.IsNullOrWhiteSpace(config.ConnectionString))
            {
                throw new ArgumentException("The application settings for CompanyConfiguration is missing a ConnectionString");
            }

            return config;
        }
    }
}
