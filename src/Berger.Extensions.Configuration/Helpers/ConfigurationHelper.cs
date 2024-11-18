using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Berger.Extensions.Configuration
{
    public static class ConfigurationHelper
    {
        #region Properties
        public static IConfiguration Configuration;
        #endregion

        #region Methods
        public static T GetParse<T>(this IConfiguration configuration, string key)
        {
            var section = configuration.GetSection(key);

            if (section.Exists())
                return section.Get<T>();

            return default(T);
        }
        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static IConfigurationBuilder ConfigureAppSettings(this IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

            return builder;
        }
        public static T Get<T>(this IConfiguration configuration, string key)
        {
            return configuration.GetSection(key).Get<T>();
        }
        public static IServiceCollection SetConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            // Configurations
            services.AddSingleton<IConfiguration>(Configuration);

            return services;
        }
        public static string GetConnection(this IConfiguration configuration, string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentException("The connection pattern cannot be null or empty.", nameof(pattern));

            var connection = configuration.GetSection(pattern).Value;

            if (string.IsNullOrEmpty(connection))
                throw new FileNotFoundException($"Connection string not found for pattern: {pattern}");

            return connection;
        }
        #endregion
    }
}