using Microsoft.Extensions.Configuration;

namespace SpecificationPatternExample.ConfigSection
{
    public static class AppConfigs
    {
        public class ConfigKeys
        {
            public const string AppUrls = "AspNetCoreUrls";
        }

        private static IConfiguration _configuration;
        public static IConfiguration Configuration => _configuration ??= GetConfig();

        private static IConfiguration GetConfig()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            PrepareConfig(configurationBuilder);
            IConfigurationRoot configurationRoot = configurationBuilder.Build();
            return configurationRoot;
        }

        public static void PrepareConfig(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddJsonFile("appsettings.json");
        }

        public static string[] AppUrls()
        {
            string[] urls = Configuration.GetSection(ConfigKeys.AppUrls).Get<string[]>();
            return urls;
        }

        public static string GetDbConnectionString()
        {
            string connectionString = Configuration.GetConnectionString("SqlServer");
            return connectionString;
        }
    }
}