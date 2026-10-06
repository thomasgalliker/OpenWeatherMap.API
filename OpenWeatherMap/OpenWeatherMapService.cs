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

        /// <summary>
        /// The earliest timestamp for which One Call API 3.0 (timemachine) provides weather data.
        /// </summary>
        internal static readonly DateTime MinOneCallTimeMachineDate = new DateTime(1979, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// The earliest date for which One Call API 3.0 (day_summary) provides aggregated weather data.
        /// </summary>
        internal static readonly DateTime MinOneCallDaySummaryDate = new DateTime(1979, 1, 2);

        /// <summary>
        /// The maximum absolute timezone offset (UTC-14:00 to UTC+14:00).
        /// </summary>
        internal static readonly TimeSpan MaxTimezoneOffset = TimeSpan.FromHours(14);

        private readonly ILogger<OpenWeatherMapService> logger;
        private readonly HttpClient httpClient;
        private readonly IWeatherIconMapping defaultWeatherIconMapping;
        private readonly IOpenWeatherMapJsonSerializer jsonSerializer;
        private readonly string apiEndpoint;
        private readonly string? apiKey;
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

        public Task<WeatherInfo> GetCurrentWeatherAsync(double latitude, double longitude)
        {
            this.logger.LogDebug($"GetCurrentWeatherAsync: latitude={latitude}, longitude={longitude}");

            var query = $"{GetCoordinatesQuery(latitude, longitude)}&{this.GetUnitsAndLanguageQuery()}";
            return this.GetAsync<WeatherInfo>(nameof(this.GetCurrentWeatherAsync), ApiPaths.CurrentWeather, query);
        }

        public Task<WeatherForecast> GetWeatherForecast4Async(double latitude, double longitude, int? count = null)
        {
            return this.GetWeatherForecastInternalAsync<WeatherForecast>(ApiPaths.ForecastHourly, latitude, longitude, count);
        }

        public Task<WeatherForecast> GetWeatherForecast5Async(double latitude, double longitude, int? count = null)
        {
            return this.GetWeatherForecastInternalAsync<WeatherForecast>(ApiPaths.Forecast, latitude, longitude, count);
        }

        public Task<WeatherForecastDaily> GetWeatherForecastDailyAsync(double latitude, double longitude, int? count = null)
        {
            return this.GetWeatherForecastInternalAsync<WeatherForecastDaily>(ApiPaths.ForecastDaily, latitude, longitude, count);
        }

        private Task<T> GetWeatherForecastInternalAsync<T>(string path, double latitude, double longitude, int? count)
        {
            this.logger.LogDebug($"GetWeatherForecastAsync: latitude={latitude}, longitude={longitude}");

            var countQuery = count > 0 ? $"&cnt={count}" : "";
            var query = $"{GetCoordinatesQuery(latitude, longitude)}&{this.GetUnitsAndLanguageQuery()}{countQuery}";
            return this.GetAsync<T>("GetWeatherForecastAsync", path, query);
        }

        public Task<OneCallWeatherInfo> GetWeatherOneCallAsync(double latitude, double longitude, OneCallOptions? oneCallOptions = null)
        {
            this.logger.LogDebug($"GetWeatherOneCallAsync: latitude={latitude}, longitude={longitude}");

            oneCallOptions ??= OneCallOptions.Default;

            var excludeQueryParameter = GetExcludeQueryParameter(oneCallOptions);
            var query = $"{GetCoordinatesQuery(latitude, longitude)}{excludeQueryParameter}&{this.GetUnitsAndLanguageQuery()}";
            return this.GetAsync<OneCallWeatherInfo>(nameof(this.GetWeatherOneCallAsync), ApiPaths.OneCall, query);
        }

        public Task<OneCallTimeMachineInfo> GetWeatherOneCallTimeMachineAsync(double latitude, double longitude, DateTime dateTime)
        {
            dateTime = dateTime.ToUniversalTime();
            if (dateTime < MinOneCallTimeMachineDate)
            {
                throw new ArgumentOutOfRangeException(nameof(dateTime), $"Weather data is available from {MinOneCallTimeMachineDate:yyyy-MM-dd}");
            }

            this.logger.LogDebug($"GetWeatherOneCallTimeMachineAsync: latitude={latitude}, longitude={longitude}, dateTime={dateTime:O}");

            var epochDateTime = EpochDateTimeConverter.Convert(dateTime);
            var query = $"{GetCoordinatesQuery(latitude, longitude)}&dt={epochDateTime}&{this.GetUnitsAndLanguageQuery()}";
            return this.GetAsync<OneCallTimeMachineInfo>(nameof(this.GetWeatherOneCallTimeMachineAsync), ApiPaths.OneCallTimeMachine, query);
        }

        public Task<OneCallDaySummary> GetWeatherOneCallDaySummaryAsync(double latitude, double longitude, DateTime date)
        {
            return this.GetWeatherOneCallDaySummaryInternalAsync(latitude, longitude, date, timezoneQuery: "");
        }

        public Task<OneCallDaySummary> GetWeatherOneCallDaySummaryAsync(double latitude, double longitude, DateTime date, TimeSpan timezoneOffset)
        {
            if (timezoneOffset.Duration() > MaxTimezoneOffset)
            {
                throw new ArgumentOutOfRangeException(nameof(timezoneOffset));
            }

            var sign = timezoneOffset < TimeSpan.Zero ? "-" : "+";
            var timezone = $"{sign}{timezoneOffset.Duration().ToString(@"hh\:mm", CultureInfo.InvariantCulture)}";
            return this.GetWeatherOneCallDaySummaryInternalAsync(latitude, longitude, date, $"&tz={Uri.EscapeDataString(timezone)}");
        }

        private Task<OneCallDaySummary> GetWeatherOneCallDaySummaryInternalAsync(double latitude, double longitude, DateTime date, string timezoneQuery)
        {
            if (date.Date < MinOneCallDaySummaryDate)
            {
                throw new ArgumentOutOfRangeException(nameof(date), $"Weather data is available from {MinOneCallDaySummaryDate:yyyy-MM-dd}");
            }

            this.logger.LogDebug($"GetWeatherOneCallDaySummaryAsync: latitude={latitude}, longitude={longitude}, date={FormatDate(date)}");

            var query = $"{GetCoordinatesQuery(latitude, longitude)}&date={FormatDate(date)}{timezoneQuery}&{this.GetUnitsAndLanguageQuery()}";
            return this.GetAsync<OneCallDaySummary>("GetWeatherOneCallDaySummaryAsync", ApiPaths.OneCallDaySummary, query);
        }

        public Task<OneCallWeatherOverview> GetWeatherOneCallOverviewAsync(double latitude, double longitude)
        {
            return this.GetWeatherOneCallOverviewInternalAsync(latitude, longitude, dateQuery: "");
        }

        public Task<OneCallWeatherOverview> GetWeatherOneCallOverviewAsync(double latitude, double longitude, DateTime date)
        {
            return this.GetWeatherOneCallOverviewInternalAsync(latitude, longitude, $"&date={FormatDate(date)}");
        }

        private Task<OneCallWeatherOverview> GetWeatherOneCallOverviewInternalAsync(double latitude, double longitude, string dateQuery)
        {
            this.logger.LogDebug($"GetWeatherOneCallOverviewAsync: latitude={latitude}, longitude={longitude}");

            // The overview endpoint does not support parameter lang.
            var query = $"{GetCoordinatesQuery(latitude, longitude)}{dateQuery}&units={this.unitSystem}";
            return this.GetAsync<OneCallWeatherOverview>("GetWeatherOneCallOverviewAsync", ApiPaths.OneCallOverview, query);
        }

        private static string? GetExcludeQueryParameter(OneCallOptions oneCallOptions)
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
            if (!oneCallOptions.IncludeAlerts)
            {
                excludes.Add("alerts");
            }

            string? excludeQueryParameter = null;
            if (excludes.Any())
            {
                excludeQueryParameter = $"&exclude={string.Join(",", excludes)}";
            }

            return excludeQueryParameter;
        }

        public async Task<Stream> GetWeatherIconAsync(WeatherCondition weatherCondition, IWeatherIconMapping? weatherIconMapping = null)
        {
            weatherIconMapping ??= this.defaultWeatherIconMapping;

            this.logger.LogDebug($"GetWeatherIconAsync: weatherCondition.Id={weatherCondition.Id}, weatherIconMapping={weatherIconMapping.GetType().Name}");

            var imageStream = await weatherIconMapping.GetIconAsync(weatherCondition);
            return imageStream;
        }

        public Task<AirPollutionInfo> GetAirPollutionAsync(double latitude, double longitude)
        {
            this.logger.LogDebug($"GetAirPollutionAsync: latitude={latitude}, longitude={longitude}");

            var query = GetCoordinatesQuery(latitude, longitude);
            return this.GetAsync<AirPollutionInfo>(nameof(this.GetAirPollutionAsync), ApiPaths.AirPollution, query);
        }

        /// <summary>
        /// Sends a GET request to the given API <paramref name="path"/> and deserializes the response.
        /// </summary>
        /// <param name="methodName">The name of the calling method (used for logging).</param>
        /// <param name="path">The relative API path, see <see cref="ApiPaths"/>.</param>
        /// <param name="query">The query string without the API key.</param>
        private async Task<T> GetAsync<T>(string methodName, string path, string query)
        {
            var builder = new UriBuilder(this.apiEndpoint)
            {
                Path = path,
                Query = $"{query}&appid={this.apiKey}"
            };

            var uri = builder.ToString();
            this.logger.LogDebug($"{methodName}: GET {StringUtil.ReplaceWithWildcardChars(uri, this.apiKey)}");

            var response = await this.httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();

            if (this.verboseLogging)
            {
                this.logger.LogDebug($"{methodName} returned content:{Environment.NewLine}{responseJson}");
            }

            return this.jsonSerializer.DeserializeObject<T>(responseJson);
        }

        private string GetUnitsAndLanguageQuery()
        {
            return $"units={this.unitSystem}&lang={this.language}";
        }

        private static string GetCoordinatesQuery(double latitude, double longitude)
        {
            EnsureLatitude(latitude);
            EnsureLongitude(longitude);

            return $"lat={FormatCoordinate(latitude)}&lon={FormatCoordinate(longitude)}";
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

        private static string FormatDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        private static string FormatCoordinate(double coordinate)
        {
            return coordinate.ToString("0.0000", CultureInfo.InvariantCulture);
        }
    }
}
