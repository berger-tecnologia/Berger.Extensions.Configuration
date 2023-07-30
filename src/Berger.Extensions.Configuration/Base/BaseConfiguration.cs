using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public class BaseConfiguration
    {
        #region Properties
        public string _file { get; }
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        public BaseConfiguration()
        {
            _file = "appsettings.json";
        }
        #endregion

        #region Methods
        public IConfigurationBuilder SetBuilder(string path, string environment)
        {
            return new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(_file, false, true)
                .AddJsonFile($"appsettings.{environment}.json", true);
        }

        public IConfigurationBuilder SetBuilder()
        {
            return new ConfigurationBuilder().AddJsonFile(_file, false, true);
        }
        #endregion
    }
}