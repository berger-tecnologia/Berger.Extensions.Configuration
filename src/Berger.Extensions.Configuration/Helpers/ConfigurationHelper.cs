using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public static class ConfigurationHelper
    {
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
        #endregion
    }
}