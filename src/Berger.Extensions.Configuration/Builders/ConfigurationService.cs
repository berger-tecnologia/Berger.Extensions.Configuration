using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public class ConfigurationService
    {
        #region Properties
        public string _file { get; }
        #endregion

        #region Constructors
        public ConfigurationService()
        {
            _file = "appsettings.json";
        }
        #endregion

        #region Methods
        public IConfigurationRoot Build()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(_file)
                .Build();

            return configuration;
        }
        public IConfigurationRoot Build(string path = "")
        {
            return new ConfigurationBuilder().AddJsonFile(_file, false, true).Build();
        }
        public IConfigurationRoot Build(string path, string environment)
        {
            return new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(_file, false, true)
                .AddJsonFile($"appsettings.{environment}.json", true)
                .Build();
        }
        #endregion
    }
}