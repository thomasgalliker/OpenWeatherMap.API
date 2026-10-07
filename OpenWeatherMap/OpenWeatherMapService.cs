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
        /// The earliest timestamp for which the One Call API 4.0 timelines provide weather data.
        /// </summary>
        internal static readonly DateTime MinOneCallTimelineDate = new DateTime(1979, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// The maximum number of locations returned by the Geocoding API.
        /// </summary>
        internal const int MaxGeocodingLimit = 5;

        /// <summary>
        /// The earliest timestamp for which historical air pollution data is available.
        /// </summary>
        internal static readonly DateTime MinAirPollutionHistoryDate = new DateTime(2020, 11, 27, 0, 0, 0, DateTimeKind.Utc);

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

        public Task<OneCallTimeline<CurrentWeatherForecast>> GetWeatherOneCallCurrentAsync(double latitude, double longitude)
        {
            this.logger.LogDebug($"GetWeatherOneCallCurrentAsync: latitude={latitude}, longitude={longitude}");

            var query = $"{GetCoordinatesQuery(latitude, longitude)}&{this.GetUnitsAndLanguageQuery()}";
            return this.GetAsync<OneCallTimeline<CurrentWeatherForecast>>(nameof(this.GetWeatherOneCallCurrentAsync), ApiPaths.OneCallCurrent, query);
        }

        public Task<OneCallTimeline<MinutelyWeatherForecast>> GetWeatherOneCallMinutelyAsync(double latitude, double longitude)
        {
            return this.GetWeatherOneCallTimelineAsync<MinutelyWeatherForecast>(ApiPaths.OneCallTimeline1Minute, latitude, longitude, start: null);
        }

        public Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCall15MinutesAsync(double latitude, double longitude)
        {
            return this.GetWeatherOneCallTimelineAsync<TimelineWeatherForecast>(ApiPaths.OneCallTimeline15Minutes, latitude, longitude, start: null);
        }

        public Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCall15MinutesAsync(double latitude, double longitude, DateTime start)
        {
            return this.GetWeatherOneCallTimelineAsync<TimelineWeatherForecast>(ApiPaths.OneCallTimeline15Minutes, latitude, longitude, start);
        }

        public Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCallHourlyAsync(double latitude, double longitude)
        {
            return this.GetWeatherOneCallTimelineAsync<TimelineWeatherForecast>(ApiPaths.OneCallTimeline1Hour, latitude, longitude, start: null);
        }

        public Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCallHourlyAsync(double latitude, double longitude, DateTime start)
        {
            return this.GetWeatherOneCallTimelineAsync<TimelineWeatherForecast>(ApiPaths.OneCallTimeline1Hour, latitude, longitude, start);
        }

        public Task<OneCallTimeline<DailyWeatherForecast>> GetWeatherOneCallDailyAsync(double latitude, double longitude)
        {
            return this.GetWeatherOneCallTimelineAsync<DailyWeatherForecast>(ApiPaths.OneCallTimeline1Day, latitude, longitude, start: null);
        }

        public Task<OneCallTimeline<DailyWeatherForecast>> GetWeatherOneCallDailyAsync(double latitude, double longitude, DateTime start)
        {
            return this.GetWeatherOneCallTimelineAsync<DailyWeatherForecast>(ApiPaths.OneCallTimeline1Day, latitude, longitude, start);
        }

        private Task<OneCallTimeline<T>> GetWeatherOneCallTimelineAsync<T>(string path, double latitude, double longitude, DateTime? start)
        {
            var startQuery = "";
            if (start is DateTime startDateTime)
            {
                startDateTime = startDateTime.ToUniversalTime();
                if (startDateTime < MinOneCallTimelineDate)
                {
                    throw new ArgumentOutOfRangeException(nameof(start), $"Weather data is available from {MinOneCallTimelineDate:yyyy-MM-dd}");
                }

                startQuery = $"&start={EpochDateTimeConverter.Convert(startDateTime)}";
            }

            this.logger.LogDebug($"GetWeatherOneCallTimelineAsync: path={path}, latitude={latitude}, longitude={longitude}, start={start:O}");

            var query = $"{GetCoordinatesQuery(latitude, longitude)}{startQuery}&{this.GetUnitsAndLanguageQuery()}";
            return this.GetAsync<OneCallTimeline<T>>("GetWeatherOneCallTimelineAsync", path, query);
        }

        public Task<OneCallTimeline<T>?> GetWeatherOneCallNextPageAsync<T>(OneCallTimeline<T> timeline)
        {
            if (timeline == null)
            {
                throw new ArgumentNullException(nameof(timeline));
            }

            return this.GetWeatherOneCallPageAsync<T>(nameof(this.GetWeatherOneCallNextPageAsync), timeline.Next);
        }

        public Task<OneCallTimeline<T>?> GetWeatherOneCallPreviousPageAsync<T>(OneCallTimeline<T> timeline)
        {
            if (timeline == null)
            {
                throw new ArgumentNullException(nameof(timeline));
            }

            return this.GetWeatherOneCallPageAsync<T>(nameof(this.GetWeatherOneCallPreviousPageAsync), timeline.Previous);
        }

        private async Task<OneCallTimeline<T>?> GetWeatherOneCallPageAsync<T>(string methodName, string? pageUrl)
        {
            if (string.IsNullOrEmpty(pageUrl))
            {
                return null;
            }

            // Only follow page URLs of the configured API endpoint, since the API key is added to the request.
            var pageUri = new Uri(pageUrl, UriKind.Absolute);
            var path = pageUri.AbsolutePath.TrimStart('/');
            if (!string.Equals(pageUri.Host, new Uri(this.apiEndpoint).Host, StringComparison.OrdinalIgnoreCase) ||
                !path.StartsWith(ApiPaths.OneCallTimelinePrefix, StringComparison.Ordinal))
            {
                throw new InvalidOperationException($"Page URL is not a One Call API 4.0 timeline URL of {this.apiEndpoint}");
            }

            var queryParameters = pageUri.Query.TrimStart('?')
                .Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(p => !p.StartsWith("appid=", StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Page URLs are not guaranteed to contain the units and language of the initial request.
            if (!queryParameters.Any(p => p.StartsWith("units=", StringComparison.OrdinalIgnoreCase)))
            {
                queryParameters.Add($"units={this.unitSystem}");
            }

            if (!queryParameters.Any(p => p.StartsWith("lang=", StringComparison.OrdinalIgnoreCase)))
            {
                queryParameters.Add($"lang={this.language}");
            }

            return await this.GetAsync<OneCallTimeline<T>>(methodName, path, string.Join("&", queryParameters));
        }

        public Task<AlertInfo> GetWeatherOneCallAlertAsync(string alertId)
        {
            if (string.IsNullOrWhiteSpace(alertId))
            {
                throw new ArgumentException("Alert ID must not be null or empty", nameof(alertId));
            }

            this.logger.LogDebug($"GetWeatherOneCallAlertAsync: alertId={alertId}");

            var path = $"{ApiPaths.OneCallAlert}/{Uri.EscapeDataString(alertId)}";
            return this.GetAsync<AlertInfo>(nameof(this.GetWeatherOneCallAlertAsync), path, query: "");
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

        public Task<AirPollutionInfo> GetAirPollutionForecastAsync(double latitude, double longitude)
        {
            this.logger.LogDebug($"GetAirPollutionForecastAsync: latitude={latitude}, longitude={longitude}");

            var query = GetCoordinatesQuery(latitude, longitude);
            return this.GetAsync<AirPollutionInfo>(nameof(this.GetAirPollutionForecastAsync), ApiPaths.AirPollutionForecast, query);
        }

        public Task<AirPollutionInfo> GetAirPollutionHistoryAsync(double latitude, double longitude, DateTime start, DateTime end)
        {
            start = start.ToUniversalTime();
            end = end.ToUniversalTime();

            if (start < MinAirPollutionHistoryDate)
            {
                throw new ArgumentOutOfRangeException(nameof(start), $"Historical air pollution data is available from {MinAirPollutionHistoryDate:yyyy-MM-dd}");
            }

            if (end <= start)
            {
                throw new ArgumentOutOfRangeException(nameof(end), "End must be after start");
            }

            this.logger.LogDebug($"GetAirPollutionHistoryAsync: latitude={latitude}, longitude={longitude}, start={start:O}, end={end:O}");

            var query = $"{GetCoordinatesQuery(latitude, longitude)}&start={EpochDateTimeConverter.Convert(start)}&end={EpochDateTimeConverter.Convert(end)}";
            return this.GetAsync<AirPollutionInfo>(nameof(this.GetAirPollutionHistoryAsync), ApiPaths.AirPollutionHistory, query);
        }

        public Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByNameAsync(string query)
        {
            return this.GetLocationsByNameInternalAsync(query, limitQuery: "");
        }

        public Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByNameAsync(string query, int limit)
        {
            return this.GetLocationsByNameInternalAsync(query, GetLimitQuery(limit));
        }

        private Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByNameInternalAsync(string query, string limitQuery)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Query must not be null or empty", nameof(query));
            }

            this.logger.LogDebug($"GetLocationsByNameAsync: query={query}");

            var requestQuery = $"q={Uri.EscapeDataString(query)}{limitQuery}";
            return this.GetAsync<IReadOnlyCollection<GeocodingLocation>>("GetLocationsByNameAsync", ApiPaths.GeocodingDirect, requestQuery);
        }

        public Task<ZipCodeLocation> GetLocationByZipCodeAsync(string zipCode, string countryCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
            {
                throw new ArgumentException("Zip code must not be null or empty", nameof(zipCode));
            }

            if (string.IsNullOrWhiteSpace(countryCode))
            {
                throw new ArgumentException("Country code must not be null or empty", nameof(countryCode));
            }

            this.logger.LogDebug($"GetLocationByZipCodeAsync: zipCode={zipCode}, countryCode={countryCode}");

            var query = $"zip={Uri.EscapeDataString(zipCode)},{Uri.EscapeDataString(countryCode)}";
            return this.GetAsync<ZipCodeLocation>(nameof(this.GetLocationByZipCodeAsync), ApiPaths.GeocodingZip, query);
        }

        public Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByCoordinatesAsync(double latitude, double longitude)
        {
            return this.GetLocationsByCoordinatesInternalAsync(latitude, longitude, limitQuery: "");
        }

        public Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByCoordinatesAsync(double latitude, double longitude, int limit)
        {
            return this.GetLocationsByCoordinatesInternalAsync(latitude, longitude, GetLimitQuery(limit));
        }

        private Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByCoordinatesInternalAsync(double latitude, double longitude, string limitQuery)
        {
            this.logger.LogDebug($"GetLocationsByCoordinatesAsync: latitude={latitude}, longitude={longitude}");

            var query = $"{GetCoordinatesQuery(latitude, longitude)}{limitQuery}";
            return this.GetAsync<IReadOnlyCollection<GeocodingLocation>>("GetLocationsByCoordinatesAsync", ApiPaths.GeocodingReverse, query);
        }

        private static string GetLimitQuery(int limit)
        {
            if (limit is < 1 or > MaxGeocodingLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), $"Limit must be between 1 and {MaxGeocodingLimit}");
            }

            return $"&limit={limit}";
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
                Query = string.IsNullOrEmpty(query) ? $"appid={this.apiKey}" : $"{query}&appid={this.apiKey}"
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

        private static string FormatCoordinate(double coordinate)
        {
            return coordinate.ToString("0.0000", CultureInfo.InvariantCulture);
        }
    }
}
