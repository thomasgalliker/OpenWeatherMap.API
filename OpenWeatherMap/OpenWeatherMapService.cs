using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OpenWeatherMap.Models;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap
{
    /// <summary>
    ///     OpenWeatherMap API Documentation:
    ///     https://openweathermap.org/current
    ///     https://openweathermap.org/weather-conditions
    /// </summary>
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        public const double MinLatitude = -90d;
        public const double MaxLatitude = 90d;
        public const double MinLongitude = -180d;
        public const double MaxLongitude = 180d;

        private readonly ILogger<OpenWeatherMapService> logger;
        private readonly HttpClient httpClient;
        private readonly IWeatherIconMapping defaultWeatherIconMapping;
        private readonly JsonSerializerSettings serializerSettings;
        private readonly string apiEndpoint;
        private readonly string apiKey;
        private readonly string unitSystem;
        private readonly string language;
        private readonly bool verboseLogging;

        public OpenWeatherMapService(ILogger<OpenWeatherMapService> logger, IOpenWeatherMapConfiguration openWeatherMapConfiguration)
            : this(logger, new HttpClient(), openWeatherMapConfiguration)
        {
        }

        public OpenWeatherMapService(ILogger<OpenWeatherMapService> logger, HttpClient httpClient, IOpenWeatherMapConfiguration openWeatherMapConfiguration)
        {
            this.logger = logger;
            this.apiEndpoint = openWeatherMapConfiguration.ApiEndpoint;
            this.apiKey = openWeatherMapConfiguration.ApiKey;
            this.unitSystem = openWeatherMapConfiguration.UnitSystem;
            this.language = openWeatherMapConfiguration.Language;
            this.verboseLogging = openWeatherMapConfiguration.VerboseLogging;
            this.httpClient = httpClient;
            this.defaultWeatherIconMapping = new DefaultWeatherIconMapping(this.httpClient);
            
            this.serializerSettings = GetJsonSerializerSettings(openWeatherMapConfiguration.UnitSystem);
        }

        public static JsonSerializerSettings GetJsonSerializerSettings(string unitSystem)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            var temperatureConverter = GetTemperatureConverter(unitSystem);
            jsonSerializerSettings.Converters.Add(temperatureConverter);
            return jsonSerializerSettings;
        }

        private static JsonConverter GetTemperatureConverter(string unitSystem)
        {
            switch (unitSystem)
            {
                case "metric":
                    return new CelsiusTemperatureJsonConverter();
                case "imperial":
                    return new FahrenheitTemperatureJsonConverter();
                default:
                    throw new NotSupportedException($"UnitSystem '{unitSystem}' is not supported");
            }
        }

        public async Task<WeatherInfo> GetCurrentWeatherAsync(double latitude, double longitude)
        {
            this.logger.LogDebug($"GetCurrentWeatherAsync: latitude={latitude}, longitude={longitude}");

            var lat = latitude.ToString("0.0000", CultureInfo.InvariantCulture);
            var lon = longitude.ToString("0.0000", CultureInfo.InvariantCulture);

            var builder = new UriBuilder(this.apiEndpoint)
            {
                Path = "data/2.5/weather",
                Query = $"lat={lat}&lon={lon}&units={this.unitSystem}&lang={this.language}&appid={this.apiKey}"
            };

            var uri = builder.ToString();
            this.logger.LogDebug($"GetCurrentWeatherAsync: GET {uri}");

            var response = await this.httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            if (this.verboseLogging)
            {
                this.logger.LogDebug($"GetCurrentWeatherAsync returned content:{Environment.NewLine}{responseJson}");
            }

            var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(responseJson, this.serializerSettings);
            return weatherInfo;
        }

        public Task<WeatherForecast> GetWeatherForecast4Async(double latitude, double longitude, int? count = null)
        {
            return this.GetWeatherForecastInternalAsync<WeatherForecast>("/hourly", latitude, longitude, count);
        }

        public Task<WeatherForecast> GetWeatherForecast5Async(double latitude, double longitude, int? count = null)
        {
            return this.GetWeatherForecastInternalAsync<WeatherForecast>("", latitude, longitude, count);
        }

        public Task<WeatherForecastDaily> GetWeatherForecastDailyAsync(double latitude, double longitude, int? count = null)
        {
            return this.GetWeatherForecastInternalAsync<WeatherForecastDaily>("/daily", latitude, longitude, count);
        }

        private async Task<T> GetWeatherForecastInternalAsync<T>(string url, double latitude, double longitude, int? count = null)
        {
            EnsureLatitude(latitude);
            EnsureLongitude(longitude);

            this.logger.LogDebug($"GetWeatherForecastAsync: latitude={latitude}, longitude={longitude}");

            var lat = FormatCoordinate(latitude);
            var lon = FormatCoordinate(longitude);

            var builder = new UriBuilder(this.apiEndpoint)
            {
                Path = $"data/2.5/forecast{url}",
                Query = $"lat={lat}&lon={lon}&units={this.unitSystem}&lang={this.language}{(count > 0 ? $"&cnt={count}" : "")}&appid={this.apiKey}"
            };

            var uri = builder.ToString();
            this.logger.LogDebug($"GetWeatherForecastAsync: GET {uri}");

            var response = await this.httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            if (this.verboseLogging)
            {
                this.logger.LogDebug($"GetWeatherForecastAsync returned content:{Environment.NewLine}{responseJson}");
            }

            var weatherForecast = JsonConvert.DeserializeObject<T>(responseJson, this.serializerSettings);
            return weatherForecast;
        }

        public async Task<OneCallWeatherInfo> GetWeatherOneCallAsync(double latitude, double longitude, OneCallOptions oneCallOptions = null)
        {
            EnsureLatitude(latitude);
            EnsureLongitude(longitude);

            this.logger.LogDebug($"GetWeatherOneCallAsync: latitude={latitude}, longitude={longitude}");

            if (oneCallOptions == null)
            {
                oneCallOptions = OneCallOptions.Default;
            }

            var lat = FormatCoordinate(latitude);
            var lon = FormatCoordinate(longitude);

            var excludeQueryParameter = GetExcludeQueryParameter(oneCallOptions);

            var builder = new UriBuilder(this.apiEndpoint)
            {
                Path = "data/2.5/onecall",
                Query = $"lat={lat}&lon={lon}{excludeQueryParameter}&units={this.unitSystem}&lang={this.language}&appid={this.apiKey}"
            };

            var uri = builder.ToString();
            this.logger.LogDebug($"GetWeatherOneCallAsync: GET {uri}");

            var response = await this.httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            if (this.verboseLogging)
            {
                this.logger.LogDebug($"GetWeatherOneCallAsync returned content:{Environment.NewLine}{responseJson}");
            }

            var oneCallWeatherInfo = JsonConvert.DeserializeObject<OneCallWeatherInfo>(responseJson, this.serializerSettings);
            return oneCallWeatherInfo;
        }

        public async Task<OneCallWeatherInfo> GetWeatherOneCallHistoricAsync(double latitude, double longitude, DateTime dateTime, bool onlyCurrent = false)
        {
            EnsureLatitude(latitude);
            EnsureLongitude(longitude);

            dateTime = dateTime.ToUniversalTime();

            this.logger.LogDebug($"GetWeatherOneCallHistoricAsync: latitude={latitude}, longitude={longitude}, dateTime={dateTime:O}");

            var lat = FormatCoordinate(latitude);
            var lon = FormatCoordinate(longitude);

            var epochDateTime = EpochDateTimeConverter.Convert(dateTime);

            var builder = new UriBuilder(this.apiEndpoint)
            {
                Path = "data/2.5/onecall/timemachine",
                Query = $"lat={lat}&lon={lon}&dt={epochDateTime}{(onlyCurrent == true ? "&only_current" : "")}&units={this.unitSystem}&lang={this.language}&appid={this.apiKey}"
            };

            var uri = builder.ToString();
            this.logger.LogDebug($"GetWeatherOneCallHistoricAsync: GET {uri}");

            var response = await this.httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            if (this.verboseLogging)
            {
                this.logger.LogDebug($"GetWeatherOneCallHistoricAsync returned content:{Environment.NewLine}{responseJson}");
            }

            var oneCallWeatherInfo = JsonConvert.DeserializeObject<OneCallWeatherInfo>(responseJson, this.serializerSettings);
            return oneCallWeatherInfo;
        }

        private static string GetExcludeQueryParameter(OneCallOptions oneCallOptions)
        {
            var excludes = new HashSet<string>();

            if (!oneCallOptions.IncludeCurrentWeather)
            {
                excludes.Add("current");
            }
            if (!oneCallOptions.IncludeMinutelyForecasts)
            {
                excludes.Add("minutely");
            }
            if (!oneCallOptions.IncludeHourlyForecasts)
            {
                excludes.Add("hourly");
            }
            if (!oneCallOptions.IncludeDailyForecasts)
            {
                excludes.Add("daily");
            }

            string excludeQueryParameter = null;
            if (excludes.Any())
            {
                excludeQueryParameter = $"&exclude={string.Join(",", excludes)}";
            }

            return excludeQueryParameter;
        }

        private static void EnsureLongitude(double longitude)
        {
            if (longitude < MinLongitude || longitude > MaxLongitude)
            {
                throw new ArgumentOutOfRangeException(nameof(longitude));
            }
        }

        private static void EnsureLatitude(double latitude)
        {
            if (latitude < MinLatitude || latitude > MaxLatitude)
            {
                throw new ArgumentOutOfRangeException(nameof(latitude));
            }
        }

        public async Task<Stream> GetWeatherIconAsync(WeatherCondition weatherCondition, IWeatherIconMapping weatherIconMapping = null)
        {
            if (weatherIconMapping == null)
            {
                weatherIconMapping = this.defaultWeatherIconMapping;
            }

            this.logger.LogDebug($"GetWeatherIconAsync: weatherCondition.Id={weatherCondition.Id}, weatherIconMapping={weatherIconMapping.GetType().Name}");

            var imageStream = await weatherIconMapping.GetIconAsync(weatherCondition);
            return imageStream;
        }

        public async Task<AirPollutionInfo> GetAirPollutionAsync(double latitude, double longitude)
        {
            EnsureLatitude(latitude);
            EnsureLongitude(longitude);

            this.logger.LogDebug($"GetAirPollutionAsync: latitude={latitude}, longitude={longitude}");

            var lat = FormatCoordinate(latitude);
            var lon = FormatCoordinate(longitude);

            var builder = new UriBuilder(this.apiEndpoint)
            {
                Path = "data/2.5/air_pollution",
                Query = $"lat={lat}&lon={lon}&appid={this.apiKey}"
            };

            var uri = builder.ToString();
            this.logger.LogDebug($"GetAirPollutionAsync: GET {uri}");

            var response = await this.httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            if (this.verboseLogging)
            {
                this.logger.LogDebug($"GetAirPollutionAsync returned content:{Environment.NewLine}{responseJson}");
            }

            var pollutionInfo = JsonConvert.DeserializeObject<AirPollutionInfo>(responseJson, this.serializerSettings);
            return pollutionInfo;
        }

        private static string FormatCoordinate(double latitude)
        {
            return latitude.ToString("0.0000", CultureInfo.InvariantCulture);
        }
    }
}