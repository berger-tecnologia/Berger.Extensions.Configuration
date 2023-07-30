using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public static class ConfigurationHelper
    {
        #region Properties
        public static IConfiguration _configuration;        
        #endregion

        #region Methods
        public static void InitializeAppSettings(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public static IConfigurationBuilder ConfigureAppSettings(this IConfiguration configuration, string path, string environment)
        {
            var service = new BaseConfiguration();

            var builder = service
                .Set(path, environment)
                .AddEnvironmentVariables();

            return builder;
        }
        public static IConfigurationBuilder ConfigureAppSettings(this IConfiguration configuration)
        {
            var service = new BaseConfiguration();

            var builder = service
                .Set()
                .AddEnvironmentVariables();

            return builder;
        }
        public static T Get<T>(this IConfiguration configuration, string key)
        {
            return configuration.GetSection(key).Get<T>();
        }
        #endregion
    }
}