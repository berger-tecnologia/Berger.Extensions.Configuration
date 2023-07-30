using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public static class ConfigurationHelper
    {
        #region Methods
        public static IConfigurationBuilder ConfigureBuilder(this IConfiguration configuration, string path, string environment)
        {
            var builder = new BaseConfiguration();

            return builder
                .Set(path, environment)
                .AddEnvironmentVariables();
        }
        public static IConfigurationBuilder ConfigureBuilder(this IConfigurationBuilder configuration, string path, string environment)
        {
            var builder = new BaseConfiguration();

            return builder.Set(path, environment);
        }
        public static IConfigurationBuilder ConfigureBuilder(this IConfiguration configuration)
        {
            var builder = new BaseConfiguration();

            return builder
                .Set()
                .AddEnvironmentVariables();
        }

        public static IConfigurationBuilder ConfigureBuilder(this IConfigurationBuilder configuration)
        {
            var builder = new BaseConfiguration();

            return builder.Set();
        }
        public static IConfigurationRoot Build(this IConfiguration configuration, string path, string environment)
        {
            var builder = new BaseConfiguration();

            return builder.Set(path, environment).Build();
        }
        public static IConfigurationRoot Build(this IConfiguration configuration, string directory = "")
        {
            var builder = new BaseConfiguration();

            return builder.Set(directory).Build();
        }
        public static T Get<T>(this IConfiguration configuration, string key)
        {
            return configuration.GetSection(key).Get<T>();
        }
        #endregion
    }
}