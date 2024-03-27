using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenWeatherMap;
using OpenWeatherMap.Extensions;

internal class Program
{
    private static async Task Main(string[] _)
    {
        Console.WriteLine($"OpenWeatherMap.ConsoleSampleDI [Version 1.0.0.0]");
        Console.WriteLine($"(c)2023 superdev gmbh. All rights reserved.");
        Console.WriteLine();

        // Create DI container and register services
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging();

        // Use code-based configuration:
        serviceCollection.AddOpenWeatherMap(o =>
        {
            o.ApiEndpoint = "https://api.openweathermap.org";
            o.ApiKey = "<-INSERT-YOUR-API-KEY-HERE->";
            o.UnitSystem = UnitSystem.Metric;
            o.Language = "en";
            o.VerboseLogging = false;
        });

        // Use configuration from appSettings.json:
        //var configuration = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json", true, true)
        //    .Build();

        //var configurationSection = configuration.GetSection("OpenWeatherMap");
        //serviceCollection.AddOpenWeatherMap(configurationSection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Resolve services from DI container

        var latitude = 47.181510d;
        var longitude = 8.460620d;

        // Request weather info using GetCurrentWeatherAsync:
        {
            var openWeatherMapService = serviceProvider.GetRequiredService<IOpenWeatherMapService>();
            var weatherInfo = await openWeatherMapService.GetCurrentWeatherAsync(latitude, longitude);

            Console.WriteLine(
                $"Current Weather Info:{Environment.NewLine}" +
                $"Location: {weatherInfo.CityName}{Environment.NewLine}" +
                $"Temperature: {weatherInfo.Main.Temperature}{Environment.NewLine}" +
                $"Humidity: {weatherInfo.Main.Humidity} ({weatherInfo.Main.Humidity.GetRange()}){Environment.NewLine}" +
                $"Pressure: {weatherInfo.Main.Pressure} ({weatherInfo.Main.Pressure.GetRange()}){Environment.NewLine}" +
                $"Wind: {weatherInfo.Wind.Speed} ({weatherInfo.Wind.Direction.ToSecondaryIntercardinalWindDirection():A}){Environment.NewLine}");
        }
    }
}