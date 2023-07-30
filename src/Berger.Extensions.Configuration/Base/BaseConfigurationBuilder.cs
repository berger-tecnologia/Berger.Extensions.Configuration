using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public class BaseConfigurationBuilder
    {
        #region Properties
        public string _file { get; }
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        public BaseConfigurationBuilder()
        {
            _file = "appsettings.json";
        }
        #endregion

        #region Methods
        public IConfigurationBuilder Set(string path, string environment)
        {
            return new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(_file, false, true)
                .AddJsonFile($"appsettings.{environment}.json", true);
        }

        public IConfigurationBuilder Set()
        {
            return new ConfigurationBuilder().AddJsonFile(_file, false, true);
        }
        #endregion
    }
}