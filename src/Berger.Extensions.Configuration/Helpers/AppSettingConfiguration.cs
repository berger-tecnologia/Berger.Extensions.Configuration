using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public static class AppSettingConfiguration
    {
        public static IConfigurationBuilder ConfigureAppSettings(this IConfiguration configuration, string path, string environment)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json", false, true)
                    .AddJsonFile($"appsettings.{environment}.json", true);

            builder.AddEnvironmentVariables();

            return builder;
        }
        public static IConfigurationBuilder ConfigureAppSettings(this IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

            builder.AddEnvironmentVariables();

            return builder;
        }
        public static T Get<T>(this IConfiguration configuration, string key)
        {
            return configuration.GetSection(key).Get<T>();
        }
    }
}