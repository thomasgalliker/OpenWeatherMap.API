using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OpenWeatherMap.Models;

namespace OpenWeatherMap
{
    public interface IOpenWeatherMapService
    {
        /// <summary>
        /// Gets the current weather data for given <paramref name="latitude"/> and <paramref name="longitude"/>.
        /// </summary>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        Task<WeatherInfo> GetCurrentWeatherAsync(double latitude, double longitude);

        /// <summary>
        /// Hourly forecast for 4 days (max. 96 timestamps).
        /// https://openweathermap.org/api/hourly-forecast
        /// </summary>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="count">Number of 1-hour forecasts to be returned.</param>
        Task<WeatherForecast> GetWeatherForecast4Async(double latitude, double longitude, int? count = null);

        /// <summary>
        /// 5 day / 3 hour forecast (max. 40 timestamps).
        /// https://openweathermap.org/forecast5
        /// </summary>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="count">Number of 3-hour forecasts to be returned.</param>
        Task<WeatherForecast> GetWeatherForecast5Async(double latitude, double longitude, int? count = null);

        /// <summary>
        /// 16 day / daily forecast (max. 17 timestamps).
        /// https://openweathermap.org/forecast16
        /// </summary>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="count">Number of days to be returned.</param>
        Task<WeatherForecastDaily> GetWeatherForecastDailyAsync(double latitude, double longitude, int? count = null);

        /// <summary>
        /// Gets the icon image for the given <paramref name="weatherCondition"/>.
        /// </summary>
        /// <param name="weatherCondition">The weather condition.</param>
        /// <param name="weatherIconMapping">The icon mapping to be used. Default: <see cref="DefaultWeatherIconMapping"/> which downloads the icon from openweathermap.org.</param>
        Task<Stream> GetWeatherIconAsync(WeatherCondition weatherCondition, IWeatherIconMapping? weatherIconMapping = null);

        /// <summary>
        /// Current weather data using One Call API 4.0. The response contains 1 record.
        /// https://openweathermap.org/api/one-call-4#current
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription for One Call API 4.0.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        Task<OneCallTimeline<CurrentWeatherForecast>> GetWeatherOneCallCurrentAsync(double latitude, double longitude);

        /// <summary>
        /// Minute forecast (precipitation) for the next 60 minutes using One Call API 4.0. The response contains up to 60 records.
        /// https://openweathermap.org/api/one-call-4#min
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription for One Call API 4.0.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        Task<OneCallTimeline<MinutelyWeatherForecast>> GetWeatherOneCallMinutelyAsync(double latitude, double longitude);

        /// <summary>
        /// 15 minutes step forecast for the next 48 hours using One Call API 4.0. The response contains up to 50 records; use <see cref="GetWeatherOneCallNextPageAsync{T}"/> to get more.
        /// https://openweathermap.org/api/one-call-4#15min
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription for One Call API 4.0.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCall15MinutesAsync(double latitude, double longitude);

        /// <summary>
        /// 15 minutes step forecast for the next 48 hours using One Call API 4.0, starting at <paramref name="start"/>. The response contains up to 50 records; use <see cref="GetWeatherOneCallNextPageAsync{T}"/> to get more.
        /// https://openweathermap.org/api/one-call-4#15min
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription for One Call API 4.0.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="start">The start of the timeline (UTC). Default: now.</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="start"/> is before 1979-01-01.</exception>
        Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCall15MinutesAsync(double latitude, double longitude, DateTime start);

        /// <summary>
        /// 1 hour step timeline (history since 1979 and forecast for 48 hours) using One Call API 4.0, starting now. The response contains up to 20 records; use <see cref="GetWeatherOneCallNextPageAsync{T}"/> and <see cref="GetWeatherOneCallPreviousPageAsync{T}"/> to get more.
        /// https://openweathermap.org/api/one-call-4#hourly
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription for One Call API 4.0.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCallHourlyAsync(double latitude, double longitude);

        /// <summary>
        /// 1 hour step timeline (history since 1979 and forecast for 48 hours) using One Call API 4.0, starting at <paramref name="start"/>. The response contains up to 20 records; use <see cref="GetWeatherOneCallNextPageAsync{T}"/> and <see cref="GetWeatherOneCallPreviousPageAsync{T}"/> to get more.
        /// https://openweathermap.org/api/one-call-4#hourly
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription for One Call API 4.0.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="start">The start of the timeline (UTC). Default: now.</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="start"/> is before 1979-01-01.</exception>
        Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCallHourlyAsync(double latitude, double longitude, DateTime start);

        /// <summary>
        /// 1 day step timeline (history since 1979 and forecast for 1.5 years) using One Call API 4.0, starting today. The response contains up to 10 records; use <see cref="GetWeatherOneCallNextPageAsync{T}"/> and <see cref="GetWeatherOneCallPreviousPageAsync{T}"/> to get more.
        /// https://openweathermap.org/api/one-call-4#daily
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription for One Call API 4.0.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        Task<OneCallTimeline<DailyWeatherForecast>> GetWeatherOneCallDailyAsync(double latitude, double longitude);

        /// <summary>
        /// 1 day step timeline (history since 1979 and forecast for 1.5 years) using One Call API 4.0, starting at <paramref name="start"/>. The response contains up to 10 records; use <see cref="GetWeatherOneCallNextPageAsync{T}"/> and <see cref="GetWeatherOneCallPreviousPageAsync{T}"/> to get more.
        /// https://openweathermap.org/api/one-call-4#daily
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription for One Call API 4.0.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="start">The start of the timeline (UTC). Default: now.</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="start"/> is before 1979-01-01.</exception>
        Task<OneCallTimeline<DailyWeatherForecast>> GetWeatherOneCallDailyAsync(double latitude, double longitude, DateTime start);

        /// <summary>
        /// Requests the next page of a One Call API 4.0 <paramref name="timeline"/>.
        /// https://openweathermap.org/api/one-call-4#pagination
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription for One Call API 4.0.
        /// </remarks>
        /// <param name="timeline">A previously requested timeline.</param>
        /// <returns>The next page, or <c>null</c> if <see cref="OneCallTimeline{T}.Next"/> is not set.</returns>
        /// <exception cref="InvalidOperationException">If the page URL does not belong to the configured API endpoint.</exception>
        Task<OneCallTimeline<T>?> GetWeatherOneCallNextPageAsync<T>(OneCallTimeline<T> timeline);

        /// <summary>
        /// Requests the previous page of a One Call API 4.0 <paramref name="timeline"/>.
        /// https://openweathermap.org/api/one-call-4#pagination
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription for One Call API 4.0.
        /// </remarks>
        /// <param name="timeline">A previously requested timeline.</param>
        /// <returns>The previous page, or <c>null</c> if <see cref="OneCallTimeline{T}.Previous"/> is not set.</returns>
        /// <exception cref="InvalidOperationException">If the page URL does not belong to the configured API endpoint.</exception>
        Task<OneCallTimeline<T>?> GetWeatherOneCallPreviousPageAsync<T>(OneCallTimeline<T> timeline);

        /// <summary>
        /// Detailed information of a national weather alert using One Call API 4.0.
        /// The alert IDs are provided by the weather records of the other One Call API 4.0 methods.
        /// https://openweathermap.org/api/one-call-4#alerts
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription for One Call API 4.0.
        /// </remarks>
        /// <param name="alertId">The alert ID.</param>
        /// <exception cref="ArgumentException">If <paramref name="alertId"/> is null or empty.</exception>
        Task<AlertInfo> GetWeatherOneCallAlertAsync(string alertId);

        /// <summary>
        /// Current air pollution data for the given coordinates.
        /// https://openweathermap.org/api/air-pollution
        /// </summary>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        Task<AirPollutionInfo> GetAirPollutionAsync(double latitude, double longitude);

        /// <summary>
        /// Hourly air pollution forecast for 4 days for the given coordinates.
        /// https://openweathermap.org/api/air-pollution#forecast
        /// </summary>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        Task<AirPollutionInfo> GetAirPollutionForecastAsync(double latitude, double longitude);

        /// <summary>
        /// Historical air pollution data (available from 2020-11-27) for the given coordinates.
        /// https://openweathermap.org/api/air-pollution#history
        /// </summary>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="start">The start of the requested period.</param>
        /// <param name="end">The end of the requested period.</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="start"/> is before 2020-11-27 or <paramref name="end"/> is not after <paramref name="start"/>.</exception>
        Task<AirPollutionInfo> GetAirPollutionHistoryAsync(double latitude, double longitude, DateTime start, DateTime end);

        /// <summary>
        /// Gets the coordinates of locations by name using the Geocoding API (direct geocoding).
        /// https://openweathermap.org/api/geocoding-api#direct_name
        /// </summary>
        /// <param name="query">City name, state code (only for the US) and ISO 3166 country code divided by comma, e.g. "Menznau,CH".</param>
        /// <exception cref="ArgumentException">If <paramref name="query"/> is null or empty.</exception>
        Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByNameAsync(string query);

        /// <summary>
        /// Gets the coordinates of locations by name using the Geocoding API (direct geocoding).
        /// https://openweathermap.org/api/geocoding-api#direct_name
        /// </summary>
        /// <param name="query">City name, state code (only for the US) and ISO 3166 country code divided by comma, e.g. "Menznau,CH".</param>
        /// <param name="limit">The maximum number of locations to be returned (1 to 5).</param>
        /// <exception cref="ArgumentException">If <paramref name="query"/> is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="limit"/> is out of range.</exception>
        Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByNameAsync(string query, int limit);

        /// <summary>
        /// Gets the coordinates of a zip/post code using the Geocoding API.
        /// https://openweathermap.org/api/geocoding-api#direct_zip
        /// </summary>
        /// <param name="zipCode">The zip/post code, e.g. "6122".</param>
        /// <param name="countryCode">The ISO 3166 country code, e.g. "CH".</param>
        /// <exception cref="ArgumentException">If <paramref name="zipCode"/> or <paramref name="countryCode"/> is null or empty.</exception>
        Task<ZipCodeLocation> GetLocationByZipCodeAsync(string zipCode, string countryCode);

        /// <summary>
        /// Gets the names of locations near the given coordinates using the Geocoding API (reverse geocoding).
        /// https://openweathermap.org/api/geocoding-api#reverse
        /// </summary>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByCoordinatesAsync(double latitude, double longitude);

        /// <summary>
        /// Gets the names of locations near the given coordinates using the Geocoding API (reverse geocoding).
        /// https://openweathermap.org/api/geocoding-api#reverse
        /// </summary>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="limit">The maximum number of locations to be returned (1 to 5).</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="limit"/> is out of range.</exception>
        Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByCoordinatesAsync(double latitude, double longitude, int limit);
    }
}
