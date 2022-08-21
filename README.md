# OpenWeatherMap
[![Version](https://img.shields.io/nuget/v/OpenWeatherMap.API.svg)](https://www.nuget.org/packages/OpenWeatherMap.API)  [![Downloads](https://img.shields.io/nuget/dt/OpenWeatherMap.API.svg)](https://www.nuget.org/packages/OpenWeatherMap.API)

OpenWeatherMap API client for .NET

### Download and Install OpenWeatherMap
This library is available on NuGet: https://www.nuget.org/packages/OpenWeatherMap.API
Use the following command to install OpenWeatherMap.API using NuGet package manager console:

    PM> Install-Package OpenWeatherMap.API

You can use this library in any .NET project which is compatible to .NET Standard 2.0 and higher.

### API Usage
The following sections document basic use cases of this library. The following code excerpts can also be found in the [sample applications](https://github.com/thomasgalliker/OpenWeatherMap.API/tree/develop/Samples).

#### Request weather info by PLZ
`MeteoSwissWeatherService` is the main entry point of this library. Create an instance of `MeteoSwissWeatherService` or inject `IMeteoSwissWeatherService` using dependency injection techniques.
```C#
IMeteoSwissWeatherService weatherService = new MeteoSwissWeatherService(logger, weatherServiceConfiguration);
```
Request weather information for any Swiss zip code (plz):
```C#
var weatherInfo = await weatherService.GetCurrentWeatherAsync(plz: 6330);
```

### Links
Federal Office of Meteorology and Climatology MeteoSwiss
https://www.meteoschweiz.admin.ch

### Contribution
Contributors welcome! If you find a bug or you want to propose a new feature, feel free to do so by opening a new issue on github.com.

### License
Check the terms and conditions of the Federal Office of Meteorology and Climatology MeteoSwiss before using this client library.