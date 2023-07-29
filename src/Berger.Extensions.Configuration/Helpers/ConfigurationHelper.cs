using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public static class ConfigurationHelper
    {
        #region Properties
        public static IConfiguration _configuration;
        #endregion

        #region Constructors
        public static void Initialize(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        #endregion

        #region Methods
        public static IConfigurationBuilder ConfigureAppSettings(this IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

            return builder;
        }
        #endregion
    }
}