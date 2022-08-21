# OpenWeatherMap.API
[![Version](https://img.shields.io/nuget/v/OpenWeatherMap.API.svg)](https://www.nuget.org/packages/OpenWeatherMap.API)  [![Downloads](https://img.shields.io/nuget/dt/OpenWeatherMap.API.svg)](https://www.nuget.org/packages/OpenWeatherMap.API)

OpenWeatherMap API client for .NET

### Download and Install OpenWeatherMap.API
This library is available on NuGet: https://www.nuget.org/packages/OpenWeatherMap.API
Use the following command to install OpenWeatherMap.API using NuGet package manager console:

    PM> Install-Package OpenWeatherMap.API

You can use this library in any .NET project which is compatible to .NET Standard 2.0 and higher.

### API Usage
The following sections document basic use cases of this library. The following code excerpts can also be found in the [sample applications](https://github.com/thomasgalliker/OpenWeatherMap.API/tree/develop/Samples).

#### Create weather service
`OpenWeatherMapService` is the main entry point of this library. Create an instance of `OpenWeatherMapService` or inject `IOpenWeatherMapService` using dependency injection techniques.
```C#
IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(logger, openWeatherMapConfiguration);
```

#### Request current weather for GPS position
Call GetCurrentWeatherAsync with latitude and longitude to retrieve the current weather information for the given location. WeatherInfo is the model that contains all relevant information provided by OpenWeatherMap API.
```C#
var weatherInfo = await openWeatherMapService.GetCurrentWeatherAsync(latitude: 47.1823761d, longitude: 8.4611036d);

Console.WriteLine(
    $"Current Weather Info:{Environment.NewLine}" +
    $"Location: {weatherInfo.CityName}{Environment.NewLine}" +
    $"Temperature: {weatherInfo.Main.Temperature}{Environment.NewLine}" +
    $"Humidity: {weatherInfo.Main.Humidity}{Environment.NewLine}" +
    $"Pressure: {weatherInfo.Main.Pressure}{Environment.NewLine}");
```

### Contribution
Contributors welcome! If you find a bug or you want to propose a new feature, feel free to do so by opening a new issue on github.com.

### License
This project is Copyright &copy; 2022 [Thomas Galliker](https://ch.linkedin.com/in/thomasgalliker). Free for non-commercial use. For commercial use please contact the author.
