using Microsoft.Extensions.Configuration;

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
            {
                return section.Get<T>();
            }

            return default(T);
        }
        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion
    }
}