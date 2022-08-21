using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OpenWeatherMap.ConsoleSample
{
    public class Program
    {
        private static IConfigurationRoot configuration;

        private static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Console.WriteLine($"OpenWeatherMap.ConsoleSample [Version 1.0.0.0]");
            Console.WriteLine($"(c) 2022 superdev gmbh. All rights reserved.");
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

            // Create weather service instance manually or resolve it from any dependency injection framework:
            var logger = loggerFactory.CreateLogger<OpenWeatherMapService>();
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(logger, openWeatherMapConfiguration);

            // Request weather info:
            var weatherInfo = await openWeatherMapService.GetCurrentWeatherAsync(latitude: 47.1823761d, longitude: 8.4611036d);

            Console.WriteLine(
                $"Current Weather Info:{Environment.NewLine}" +
                $"Location: {weatherInfo.CityName}{Environment.NewLine}" +
                $"Temperature: {weatherInfo.Main.Temperature}{Environment.NewLine}" +
                $"Humidity: {weatherInfo.Main.Humidity}{Environment.NewLine}" +
                $"Pressure: {weatherInfo.Main.Pressure}{Environment.NewLine}");

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
