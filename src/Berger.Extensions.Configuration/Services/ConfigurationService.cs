using Microsoft.Extensions.Configuration;

namespace Berger.Extensions.Configuration
{
    public class ConfigurationService
    {
        #region Properties
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        public ConfigurationService()
        {
            Configuration = Configuration.Build();
        }
        #endregion
    }
}