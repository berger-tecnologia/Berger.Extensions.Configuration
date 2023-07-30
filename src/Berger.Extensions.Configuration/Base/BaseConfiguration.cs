using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public static class BaseConfiguration
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
            var builder = new BaseConfigurationBuilder();

            return builder
                .Set(path, environment)
                .AddEnvironmentVariables();
        }
        public static IConfigurationBuilder ConfigureBuilder(this IConfigurationBuilder configuration, string path, string environment)
        {
            var builder = new BaseConfigurationBuilder();

            return builder.Set(path, environment);
        }
        public static IConfigurationBuilder ConfigureBuilder(this IConfiguration configuration)
        {
            var builder = new BaseConfigurationBuilder();

            return builder
                .Set()
                .AddEnvironmentVariables();
        }

        public static IConfigurationBuilder ConfigureBuilder(this IConfigurationBuilder configuration)
        {
            var builder = new BaseConfigurationBuilder();

            return builder.Set();
        }
        public static T Get<T>(this IConfiguration configuration, string key)
        {
            return configuration.GetSection(key).Get<T>();
        }
        #endregion
    }
}