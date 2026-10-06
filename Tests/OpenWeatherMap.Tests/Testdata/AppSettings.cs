using System.IO;
using Microsoft.Extensions.Configuration;

namespace OpenWeatherMap.Tests.Testdata
{
    internal static class AppSettings
    {
        public static OpenWeatherMapOptions GetApiConfiguration(string sectionName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets(typeof(AppSettings).Assembly)
                .Build();

            var openWeatherMapOptions = new OpenWeatherMapOptions();
            var openWeatherMapSection = configuration.GetSection(sectionName);
            openWeatherMapSection.Bind(openWeatherMapOptions);

            return openWeatherMapOptions;
        }
    }
}
