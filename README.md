# OpenWeatherMap.API
[![Version](https://img.shields.io/nuget/v/OpenWeatherMap.API.svg)](https://www.nuget.org/packages/OpenWeatherMap.API) [![Downloads](https://img.shields.io/nuget/dt/OpenWeatherMap.API.svg)](https://www.nuget.org/packages/OpenWeatherMap.API) [![Buy Me a Coffee](https://img.shields.io/badge/support-buy%20me%20a%20coffee-FFDD00)](https://buymeacoffee.com/thomasgalliker)

OpenWeatherMap API client for .NET

### Download and Install OpenWeatherMap.API
This library is available on NuGet: https://www.nuget.org/packages/OpenWeatherMap.API
Use the following command to install OpenWeatherMap.API using NuGet package manager console:

    PM> Install-Package OpenWeatherMap.API

You can use this library in any .NET project which is compatible to .NET Standard 2.0 and higher.

### Supported APIs
An API key is required for all API methods. Some API methods require a paid [OpenWeatherMap subscription](https://openweathermap.org/price).

| Method | OpenWeatherMap API | Subscription |
| --- | --- | --- |
| `GetCurrentWeatherAsync` | [Current weather](https://openweathermap.org/current) (`data/2.5/weather`) | Free |
| `GetWeatherForecast5Async` | [5 day / 3 hour forecast](https://openweathermap.org/forecast5) (`data/2.5/forecast`) | Free |
| `GetWeatherForecast4Async` | [Hourly forecast 4 days](https://openweathermap.org/api/hourly-forecast) (`data/2.5/forecast/hourly`) | Pro |
| `GetWeatherForecastDailyAsync` | [Daily forecast 16 days](https://openweathermap.org/forecast16) (`data/2.5/forecast/daily`) | Pro |
| `GetWeatherOneCallCurrentAsync` | [One Call API 4.0](https://openweathermap.org/api/one-call-4) (`data/4.0/onecall/current`) | One Call by Call |
| `GetWeatherOneCallMinutelyAsync` | One Call API 4.0 (`data/4.0/onecall/timeline/1min`) | One Call by Call |
| `GetWeatherOneCall15MinutesAsync` | One Call API 4.0 (`data/4.0/onecall/timeline/15min`) | One Call by Call |
| `GetWeatherOneCallHourlyAsync` | One Call API 4.0 (`data/4.0/onecall/timeline/1h`) | One Call by Call |
| `GetWeatherOneCallDailyAsync` | One Call API 4.0 (`data/4.0/onecall/timeline/1day`) | One Call by Call |
| `GetWeatherOneCallNextPageAsync`, `GetWeatherOneCallPreviousPageAsync` | One Call API 4.0 timeline pagination | One Call by Call |
| `GetWeatherOneCallAlertAsync` | One Call API 4.0 (`data/4.0/onecall/alert/{id}`) | One Call by Call |
| `GetAirPollutionAsync`, `GetAirPollutionForecastAsync`, `GetAirPollutionHistoryAsync` | [Air pollution](https://openweathermap.org/api/air-pollution) (`data/2.5/air_pollution`) | Free |
| `GetLocationsByNameAsync`, `GetLocationByZipCodeAsync`, `GetLocationsByCoordinatesAsync` | [Geocoding API](https://openweathermap.org/api/geocoding-api) (`geo/1.0`) | Free |
| `GetWeatherIconAsync` | [Weather icons](https://openweathermap.org/weather-conditions) | Free |

### API Usage
The following sections document basic use cases of this library. The following code excerpts can also be found in the [sample applications](https://github.com/thomasgalliker/OpenWeatherMap.API/tree/develop/Samples).

#### Create weather service
`OpenWeatherMapService` is the main entry point of this library. Create an instance of `OpenWeatherMapService` or inject `IOpenWeatherMapService` using dependency injection techniques.
```C#
var openWeatherMapOptions = new OpenWeatherMapOptions
{
    ApiKey = "<-INSERT-YOUR-API-KEY-HERE->",
    UnitSystem = UnitSystem.Metric,
    Language = "en",
};

IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(logger, openWeatherMapOptions);
```

If you use Microsoft.Extensions.DependencyInjection, register `IOpenWeatherMapService` with `AddOpenWeatherMap`. The options can be bound to a configuration section (e.g. from appsettings.json) or configured in code:
```C#
serviceCollection.AddOpenWeatherMap(configuration.GetSection("OpenWeatherMap"));
```

```json
{
  "OpenWeatherMap": {
    "ApiKey": "<-INSERT-YOUR-API-KEY-HERE->",
    "UnitSystem": "metric",
    "Language": "en"
  }
}
```

#### Request current weather for GPS position
Call `GetCurrentWeatherAsync` with latitude and longitude to retrieve the current weather information for the given location. `WeatherInfo` is the model that contains all relevant information provided by OpenWeatherMap API.
```C#
var weatherInfo = await openWeatherMapService.GetCurrentWeatherAsync(latitude: 47.1823761d, longitude: 8.4611036d);

Console.WriteLine(
    $"Current Weather Info:{Environment.NewLine}" +
    $"Location: {weatherInfo.CityName}{Environment.NewLine}" +
    $"Temperature: {weatherInfo.Main.Temperature}{Environment.NewLine}" +
    $"Humidity: {weatherInfo.Main.Humidity}{Environment.NewLine}" +
    $"Pressure: {weatherInfo.Main.Pressure}{Environment.NewLine}");
```

#### Request 5 day / 3 hour forecast
```C#
var weatherForecast = await openWeatherMapService.GetWeatherForecast5Async(latitude, longitude, count: 8);

foreach (var forecastItem in weatherForecast.Items)
{
    Console.WriteLine($"{forecastItem.DateTime.ToLocalTime():g}: {forecastItem.Main.Temperature}");
}
```

#### Request weather data using One Call API 4.0
One Call API 4.0 provides current weather, a minute forecast for 1 hour, a 15 minutes forecast for 48 hours, an hourly timeline (history since 1979 and forecast for 48 hours),
a daily timeline (history since 1979 and forecast for 1.5 years) and national weather alerts.
It requires a ["One Call by Call" subscription](https://openweathermap.org/api/one-call-4) for One Call API 4.0; requests without this subscription fail with HTTP 401 (Unauthorized).

All One Call API 4.0 methods return a `OneCallTimeline<T>` with the weather records in property `Data`.
```C#
var currentTimeline = await openWeatherMapService.GetWeatherOneCallCurrentAsync(latitude, longitude);
var currentWeather = currentTimeline.Data.Single();

var dailyTimeline = await openWeatherMapService.GetWeatherOneCallDailyAsync(latitude, longitude);
foreach (var dailyForecast in dailyTimeline.Data)
{
    Console.WriteLine($"{dailyForecast.DateTime:d}: {dailyForecast.Temperature.Min}/{dailyForecast.Temperature.Max}");
}
```

The timelines are paginated. Request the previous or next page of a timeline with `GetWeatherOneCallPreviousPageAsync` and `GetWeatherOneCallNextPageAsync`
(each page is billed as a separate API call). Historical data is requested by passing a `start` date:
```C#
// Hourly weather data of 2020-03-04, starting at 00:00 UTC
var hourlyTimeline = await openWeatherMapService.GetWeatherOneCallHourlyAsync(latitude, longitude, start: new DateTime(2020, 3, 4, 0, 0, 0, DateTimeKind.Utc));
var nextPage = await openWeatherMapService.GetWeatherOneCallNextPageAsync(hourlyTimeline); // null if there is no next page
```

Weather records reference weather alerts by ID. Use `GetWeatherOneCallAlertAsync` to get the details of an alert:
```C#
foreach (var alertId in currentWeather.Alerts)
{
    var alertInfo = await openWeatherMapService.GetWeatherOneCallAlertAsync(alertId);
    Console.WriteLine($"{alertInfo.SenderName}: {alertInfo.EventName}");
}
```

#### Find locations using the Geocoding API
```C#
// Coordinates by location name (city name, state code (US only), country code)
var locations = await openWeatherMapService.GetLocationsByNameAsync("Menznau,CH", limit: 1);

// Coordinates by zip/post code
var zipCodeLocation = await openWeatherMapService.GetLocationByZipCodeAsync("6122", "CH");

// Location names by coordinates (reverse geocoding)
var nearbyLocations = await openWeatherMapService.GetLocationsByCoordinatesAsync(latitude, longitude);
```

#### Request air pollution data
```C#
var airPollutionInfo = await openWeatherMapService.GetAirPollutionAsync(latitude, longitude);
var airPollutionForecast = await openWeatherMapService.GetAirPollutionForecastAsync(latitude, longitude);
var airPollutionHistory = await openWeatherMapService.GetAirPollutionHistoryAsync(latitude, longitude, start: DateTime.UtcNow.AddDays(-1), end: DateTime.UtcNow);
```

### Migrating from 2.x to 4.0
OpenWeatherMap retired One Call API 2.5. Version 4.0 of this library migrates to One Call API 4.0 and contains the following breaking changes:

| 2.x | 4.0 |
| --- | --- |
| `GetWeatherOneCallAsync` (`CurrentWeather`) | `GetWeatherOneCallCurrentAsync` |
| `GetWeatherOneCallAsync` (`MinutelyForecasts`) | `GetWeatherOneCallMinutelyAsync` |
| `GetWeatherOneCallAsync` (`HourlyForecasts`) | `GetWeatherOneCallHourlyAsync` (or `GetWeatherOneCall15MinutesAsync`) |
| `GetWeatherOneCallAsync` (`DailyForecasts`) | `GetWeatherOneCallDailyAsync` |
| `GetWeatherOneCallAsync` (`Alerts`) | Alert IDs in `Alerts` of each weather record + `GetWeatherOneCallAlertAsync` |
| `GetWeatherOneCallHistoricAsync` | `GetWeatherOneCallHourlyAsync` with parameter `start` |
| `OneCallOptions`, `OneCallWeatherInfo` | Removed; each method returns a `OneCallTimeline<T>` |
| `HourlyWeatherForecast` | `TimelineWeatherForecast` |
| `AlertInfo.Description` | `AlertInfo.Descriptions` (one description per language) |

Further breaking changes:
- `UnitSystem.Standard` returns temperatures in Kelvin (as provided by OpenWeatherMap) instead of Celsius.
- `IOpenWeatherMapService` has new members. Custom implementations of this interface need to be extended.
- `CurrentWeatherForecast.Rain` and `CurrentWeatherForecast.Snow` are nullable since they are only provided if available.

### Contribution
Contributors welcome! If you find a bug or you want to propose a new feature, feel free to do so by opening a new issue on github.com.

### License
This project is Copyright &copy; 2026 [Thomas Galliker](https://ch.linkedin.com/in/thomasgalliker). Free for non-commercial use. For commercial use please contact the author.
