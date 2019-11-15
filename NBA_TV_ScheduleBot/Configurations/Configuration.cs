using Microsoft.Extensions.Configuration;
using System.IO;

namespace NBA_TV_ScheduleBot.Configurations
{
    public static class Configuration
    {
        private static readonly IConfigurationRoot configuration;

        static Configuration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", optional: true, reloadOnChange: true);

             configuration = builder.Build();
        }

        public static string GetViasatChannelId()
        {
            return configuration.GetSection("Viasat.CannelId").Value;
        }

        public static string GetSetantaChannelId()
        {
            return configuration.GetSection("Setanta.CannelId").Value;
        }

        public static string GetTelegramAPIKey()
        {
            return configuration.GetSection("Telegram.APIKey").Value;
        }
    }
}
