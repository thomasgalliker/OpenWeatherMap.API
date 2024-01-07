using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenWeatherMap.Extensions;
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

            var openWeatherMapOptions = new OpenWeatherMapOptions();
            var openWeatherMapSection = configuration.GetSection("OpenWeatherMap");
            openWeatherMapSection.Bind(openWeatherMapOptions);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            CultureInfo.CurrentCulture = new CultureInfo("en-US");
            //CultureInfo.CurrentCulture = new CultureInfo("de-CH");

            // Create weather service instance manually or resolve it from any dependency injection framework:
            var logger = loggerFactory.CreateLogger<OpenWeatherMapService>();
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(logger, openWeatherMapOptions);

            var latitude = 47.181510d;
            var longitude = 8.460620d;

            // Request weather info using GetCurrentWeatherAsync:
            {
                var weatherInfo = await openWeatherMapService.GetCurrentWeatherAsync(latitude, longitude);

                Console.WriteLine(
                    $"Current Weather Info:{Environment.NewLine}" +
                    $"Location: {weatherInfo.CityName}{Environment.NewLine}" +
                    $"Weather condition: {weatherInfo.Weather.ElementAtOrDefault(0)?.Id}{Environment.NewLine}" +
                    $"Temperature: {weatherInfo.Main.Temperature}{Environment.NewLine}" +
                    $"Humidity: {weatherInfo.Main.Humidity} ({weatherInfo.Main.Humidity.GetRange()}){Environment.NewLine}" +
                    $"Pressure: {weatherInfo.Main.Pressure} ({weatherInfo.Main.Pressure.GetRange()}){Environment.NewLine}" +
                    $"Wind: {weatherInfo.Wind.Speed} ({weatherInfo.Wind.Direction.ToSecondaryIntercardinalWindDirection():A}){Environment.NewLine}");
            }

            // Request weather info using GetWeatherOneCallAsync:
            {
                var oneCallWeatherInfo = await openWeatherMapService.GetWeatherOneCallAsync(latitude, longitude);

                Console.WriteLine(
                    $"Current Weather Info:{Environment.NewLine}" +
                    $"Temperature: {oneCallWeatherInfo.CurrentWeather.Temperature}{Environment.NewLine}" +
                    $"Humidity: {oneCallWeatherInfo.CurrentWeather.Humidity} ({oneCallWeatherInfo.CurrentWeather.Humidity.GetRange()}){Environment.NewLine}" +
                    $"Pressure: {oneCallWeatherInfo.CurrentWeather.Pressure} ({oneCallWeatherInfo.CurrentWeather.Pressure.GetRange()}){Environment.NewLine}" +
                    $"Wind: {oneCallWeatherInfo.CurrentWeather.WindSpeed} ({oneCallWeatherInfo.CurrentWeather.WindDirection.ToSecondaryIntercardinalWindDirection():A}){Environment.NewLine}");
            }

            // Request air pollution information:
            var airPollutionInfo = await openWeatherMapService.GetAirPollutionAsync(latitude, longitude);
            if (airPollutionInfo.Items.FirstOrDefault() is AirPollutionInfoItem airPollutionInfoItem)
            {
                Console.WriteLine(
                    $"Air Pollution Info:{Environment.NewLine}" +
                    $"AirQuality: {airPollutionInfoItem.Main.AirQuality}{Environment.NewLine}" +
                    $"CO: {airPollutionInfoItem.Components.CarbonMonoxide}{Environment.NewLine}" +
                    $"O₃: {airPollutionInfoItem.Components.Ozone}{Environment.NewLine}" +
                    $"PM: {airPollutionInfoItem.Components.CoarseParticulateMatter}{Environment.NewLine}" +
                    $"PM2.5: {airPollutionInfoItem.Components.FineParticulateMatter}{Environment.NewLine}");
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
