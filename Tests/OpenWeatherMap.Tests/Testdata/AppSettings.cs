using System.IO;
using Microsoft.Extensions.Configuration;

namespace OpenWeatherMap.Tests.Testdata
{
    internal class AppSettings
    {
        public static OpenWeatherMapOptions GetApiConfiguration(string sectionName = "OpenWeatherMap")
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets<AppSettings>()
                .Build();

            var openWeatherMapOptions = new OpenWeatherMapOptions();
            var openWeatherMapSection = configuration.GetSection(sectionName);
            openWeatherMapSection.Bind(openWeatherMapOptions);

            return openWeatherMapOptions;
        }
    }
}
