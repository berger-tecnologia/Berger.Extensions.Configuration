using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public class BaseConfiguration
    {
        #region Properties
        public string _file { get; }
        #endregion

        #region Constructors
        public BaseConfiguration()
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
        public IConfigurationBuilder Set(string directory = "")
        {
            //directory ??= Directory.GetCurrentDirectory();

            return new ConfigurationBuilder().AddJsonFile(_file, false, true);
        }
        #endregion
    }
}