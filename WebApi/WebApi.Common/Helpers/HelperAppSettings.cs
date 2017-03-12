namespace WebApi.Common.Helpers
{
    using Microsoft.Extensions.Configuration;
    
    public class HelperAppSettings
    {
        private static IConfigurationRoot _configuration;

        public HelperAppSettings(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public static string ConnectionString
        {
            get
            {
                return _configuration.GetConnectionString("NORTHWND");
            }
        }
    }
}
