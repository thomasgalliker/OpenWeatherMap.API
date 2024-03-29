using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using OpenWeatherMap.Models;
using OpenWeatherMap.Models.Converters;
using OpenWeatherMap.Utils;

namespace OpenWeatherMap
{
    /// <summary>
    /// The API access service for OpenWeatherMap.
    /// </summary>
    /// <remarks>
    /// OpenWeatherMap API documentation can be found here:
    /// https://openweathermap.org/current
    /// https://openweathermap.org/weather-conditions
    /// </remarks>
    public class OpenWeatherMapService : IOpenWeatherMapService
    {
        internal const double MinLatitude = -90d;
        internal const double MaxLatitude = 90d;
        internal const double MinLongitude = -180d;
        internal const double MaxLongitude = 180d;

        private readonly ILogger<OpenWeatherMapService> logger;
        private readonly HttpClient httpClient;
        private readonly IWeatherIconMapping defaultWeatherIconMapping;
        private readonly IOpenWeatherMapJsonSerializer jsonSerializer;
        private readonly string apiEndpoint;
        private readonly string apiKey;
        private readonly UnitSystem unitSystem;
        private readonly string language;
        private readonly bool verboseLogging;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenWeatherMapService"/> class.
        /// </summary>
        /// <param name="options">The service options.</param>
        public OpenWeatherMapService(
            OpenWeatherMapOptions options)
            : this(new NullLogger<OpenWeatherMapService>(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenWeatherMapService"/> class.
        /// </summary>
        /// <param name="options">The service options.</param>
        public OpenWeatherMapService(
            IOptions<OpenWeatherMapOptions> options)
            : this(new NullLogger<OpenWeatherMapService>(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenWeatherMapService"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="options">The service options.</param>
        public OpenWeatherMapService(
            ILogger<OpenWeatherMapService> logger,
            IOptions<OpenWeatherMapOptions> options)
            : this(logger, options.Value)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenWeatherMapService"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="options">The service options.</param>
        public OpenWeatherMapService(
            ILogger<OpenWeatherMapService> logger,
            OpenWeatherMapOptions options)
            : this(logger, new HttpClient(), options)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenWeatherMapService"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="httpClient">The HttpClient instance.</param>
        /// <param name="options">The service options.</param>
        public OpenWeatherMapService(
            ILogger<OpenWeatherMapService> logger,
            HttpClient httpClient,
            OpenWeatherMapOptions options)
        {
            this.logger = logger;
            this.apiEndpoint = options.ApiEndpoint;
            this.apiKey = options.ApiKey;
            this.unitSystem = options.UnitSystem;
            this.language = options.Language;
            this.verboseLogging = options.VerboseLogging;
            this.httpClient = httpClient;
            this.defaultWeatherIconMapping = new DefaultWeatherIconMapping(this.httpClient);
            this.jsonSerializer = new OpenWeatherMapJsonSerializer(this.unitSystem);
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
            this.logger.LogDebug($"GetCurrentWeatherAsync: GET {StringUtil.ReplaceWithWildcardChars(uri, this.apiKey)}");

            var response = await this.httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            if (this.verboseLogging)
            {
                this.logger.LogDebug($"GetCurrentWeatherAsync returned content:{Environment.NewLine}{responseJson}");
            }

            var weatherInfo = this.jsonSerializer.DeserializeObject<WeatherInfo>(responseJson);
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
            this.logger.LogDebug($"GetWeatherForecastAsync: GET {StringUtil.ReplaceWithWildcardChars(uri, this.apiKey)}");

            var response = await this.httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            if (this.verboseLogging)
            {
                this.logger.LogDebug($"GetWeatherForecastAsync returned content:{Environment.NewLine}{responseJson}");
            }

            var weatherForecast = this.jsonSerializer.DeserializeObject<T>(responseJson);
            return weatherForecast;
        }

        public async Task<OneCallWeatherInfo> GetWeatherOneCallAsync(double latitude, double longitude, OneCallOptions oneCallOptions = null)
        {
            EnsureLatitude(latitude);
            EnsureLongitude(longitude);

            this.logger.LogDebug($"GetWeatherOneCallAsync: latitude={latitude}, longitude={longitude}");

            oneCallOptions ??= OneCallOptions.Default;

            var lat = FormatCoordinate(latitude);
            var lon = FormatCoordinate(longitude);

            var excludeQueryParameter = GetExcludeQueryParameter(oneCallOptions);

            var builder = new UriBuilder(this.apiEndpoint)
            {
                Path = "data/2.5/onecall",
                Query = $"lat={lat}&lon={lon}{excludeQueryParameter}&units={this.unitSystem}&lang={this.language}&appid={this.apiKey}"
            };

            var uri = builder.ToString();
            this.logger.LogDebug($"GetWeatherOneCallAsync: GET {StringUtil.ReplaceWithWildcardChars(uri, this.apiKey)}");

            var response = await this.httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            if (this.verboseLogging)
            {
                this.logger.LogDebug($"GetWeatherOneCallAsync returned content:{Environment.NewLine}{responseJson}");
            }

            var oneCallWeatherInfo = this.jsonSerializer.DeserializeObject<OneCallWeatherInfo>(responseJson);
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
            this.logger.LogDebug($"GetWeatherOneCallHistoricAsync: GET {StringUtil.ReplaceWithWildcardChars(uri, this.apiKey)}");

            var response = await this.httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            if (this.verboseLogging)
            {
                this.logger.LogDebug($"GetWeatherOneCallHistoricAsync returned content:{Environment.NewLine}{responseJson}");
            }

            var oneCallWeatherInfo = this.jsonSerializer.DeserializeObject<OneCallWeatherInfo>(responseJson);
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
            if (longitude is < MinLongitude or > MaxLongitude)
            {
                throw new ArgumentOutOfRangeException(nameof(longitude));
            }
        }

        private static void EnsureLatitude(double latitude)
        {
            if (latitude is < MinLatitude or > MaxLatitude)
            {
                throw new ArgumentOutOfRangeException(nameof(latitude));
            }
        }

        public async Task<Stream> GetWeatherIconAsync(WeatherCondition weatherCondition, IWeatherIconMapping weatherIconMapping = null)
        {
            weatherIconMapping ??= this.defaultWeatherIconMapping;

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
            this.logger.LogDebug($"GetAirPollutionAsync: GET {StringUtil.ReplaceWithWildcardChars(uri, this.apiKey)}");

            var response = await this.httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            if (this.verboseLogging)
            {
                this.logger.LogDebug($"GetAirPollutionAsync returned content:{Environment.NewLine}{responseJson}");
            }

            var pollutionInfo = this.jsonSerializer.DeserializeObject<AirPollutionInfo>(responseJson);
            return pollutionInfo;
        }

        private static string FormatCoordinate(double latitude)
        {
            return latitude.ToString("0.0000", CultureInfo.InvariantCulture);
        }
    }
}