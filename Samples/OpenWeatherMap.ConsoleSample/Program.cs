using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenWeatherMap.Models;

namespace OpenWeatherMap.ConsoleSample
{
    public class Program
    {
        private static IConfigurationRoot configuration;

        private static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Console.WriteLine($"OpenWeatherMap.ConsoleSample [Version 1.0.0.0]");
            Console.WriteLine($"(c) 2023 superdev gmbh. All rights reserved.");
            Console.WriteLine();

            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
#if DEBUG
                .AddUserSecrets<Program>()
#endif
                .Build();

            var openWeatherMapConfiguration = new OpenWeatherMapConfiguration();
            var openWeatherMapSection = configuration.GetSection("OpenWeatherMap");
            openWeatherMapSection.Bind(openWeatherMapConfiguration);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            //CultureInfo.CurrentCulture = new CultureInfo("en-US");
            CultureInfo.CurrentCulture = new CultureInfo("de");

            // Create weather service instance manually or resolve it from any dependency injection framework:
            var logger = loggerFactory.CreateLogger<OpenWeatherMapService>();
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(logger, openWeatherMapConfiguration);

            // Request weather info:
            var latitude = 47.1823761d;
            var longitude = 8.4611036d;
            var weatherInfo = await openWeatherMapService.GetCurrentWeatherAsync(latitude, longitude);

            Console.WriteLine(
                $"Current Weather Info:{Environment.NewLine}" +
                $"Location: {weatherInfo.CityName}{Environment.NewLine}" +
                $"Temperature: {weatherInfo.Main.Temperature}{Environment.NewLine}" +
                $"Humidity: {weatherInfo.Main.Humidity} ({weatherInfo.Main.Humidity.Range}){Environment.NewLine}" +
                $"Pressure: {weatherInfo.Main.Pressure} ({weatherInfo.Main.Pressure.Range}){Environment.NewLine}" +
                $"Wind: {weatherInfo.Wind.Speed}m/s ({weatherInfo.Wind.Direction}){Environment.NewLine}");

            var airPollutionInfo = await openWeatherMapService.GetAirPollutionAsync(latitude, longitude);
            if (airPollutionInfo.Items.FirstOrDefault() is AirPollutionInfoItem airPollutionInfoItem)
            {
                Console.WriteLine(
                    $"Air Pollution Info:{Environment.NewLine}" +
                    $"AirQuality: {airPollutionInfoItem.Main.AirQuality}{Environment.NewLine}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to close this window...");
            Console.ReadKey();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine($"{e.ExceptionObject}");
        }
    }
}
