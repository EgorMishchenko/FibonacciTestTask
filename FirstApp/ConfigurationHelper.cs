using System.IO;
using Microsoft.Extensions.Configuration;

namespace FirstApp
{
    public static class ConfigurationHelper
    {
        public static string GetValueByKey(string key)
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder().SetBasePath(currentDirectory).AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            return configuration[key];
        }
    }
}
