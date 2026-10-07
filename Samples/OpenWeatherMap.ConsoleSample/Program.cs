using System.Globalization;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenWeatherMap.Extensions;
using OpenWeatherMap.Models;

namespace OpenWeatherMap.ConsoleSample
{
    public static class Program
    {
        private static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Console.WriteLine("OpenWeatherMap.ConsoleSample [Version 1.0.0.0]");
            Console.WriteLine("(c) 2026 superdev gmbh. All rights reserved.");
            Console.WriteLine();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
#if DEBUG
                .AddUserSecrets(typeof(Program).Assembly)
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

            // Resolve the coordinates of a location by name using GetLocationsByNameAsync (Geocoding API):
            var location = (await openWeatherMapService.GetLocationsByNameAsync("Menznau,CH", limit: 1)).First();
            var latitude = location.Latitude;
            var longitude = location.Longitude;

            Console.WriteLine(
                $"Location:{Environment.NewLine}" +
                $"{location.Name}, {location.State}, {location.Country} ({latitude}, {longitude}){Environment.NewLine}");

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

            // Request 5 day / 3 hour forecast using GetWeatherForecast5Async:
            {
                var weatherForecast = await openWeatherMapService.GetWeatherForecast5Async(latitude, longitude, count: 8);

                Console.WriteLine("Weather Forecast:");
                foreach (var forecastItem in weatherForecast.Items)
                {
                    Console.WriteLine(
                        $"{forecastItem.DateTime.ToLocalTime():g}: " +
                        $"{forecastItem.Main.Temperature}, " +
                        $"{forecastItem.WeatherConditions.ElementAtOrDefault(0)?.Description}, " +
                        $"Pop: {forecastItem.Pop.Percent}%");
                }

                Console.WriteLine();
            }

            // Request current weather and forecasts using GetWeatherOneCallAsync (One Call API 3.0):
            try
            {
                var oneCallWeatherInfo = await openWeatherMapService.GetWeatherOneCallAsync(latitude, longitude);

                Console.WriteLine("Daily Forecast (One Call API 3.0):");
                foreach (var dailyForecast in oneCallWeatherInfo.DailyForecasts)
                {
                    Console.WriteLine(
                        $"{dailyForecast.DateTime.ToLocalTime():d}: " +
                        $"{dailyForecast.Temperature.Min}/{dailyForecast.Temperature.Max}, " +
                        $"{dailyForecast.Summary}");
                }

                Console.WriteLine();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                Console.WriteLine(
                    $"One Call API 3.0 requires a 'One Call by Call' subscription: https://openweathermap.org/api/one-call-3{Environment.NewLine}");
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
