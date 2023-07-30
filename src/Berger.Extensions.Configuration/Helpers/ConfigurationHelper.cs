using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public static class ConfigurationHelper
    {
        #region Properties
        public static IConfiguration Configuration;        
        #endregion

        #region Methods
        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfigurationBuilder ConfigureBuilder(this IConfiguration configuration, string path, string environment)
        {
            var service = new BaseConfiguration();

            return service
                .SetBuilder(path, environment)
                .AddEnvironmentVariables();
        }
        public static IConfigurationBuilder ConfigureBuilder(this IConfigurationBuilder builder, string path, string environment)
        {
            var service = new BaseConfiguration();

            return service.SetBuilder(path, environment);
        }
        public static IConfigurationBuilder ConfigureBuilder(this IConfiguration configuration)
        {
            var service = new BaseConfiguration();

            return service
                .SetBuilder()
                .AddEnvironmentVariables();
        }

        public static IConfigurationBuilder ConfigureBuilder(this IConfigurationBuilder builder)
        {
            var service = new BaseConfiguration();

            return service.SetBuilder();
        }
        public static T Get<T>(this IConfiguration configuration, string key)
        {
            return configuration.GetSection(key).Get<T>();
        }
        #endregion
    }
}