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
        /// Current weather, minutely forecast for 1 hour, hourly forecast for 48 hours, daily forecast for 8 days
        /// and government weather alerts using One Call API 3.0.
        /// https://openweathermap.org/api/one-call-3
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="oneCallOptions">Selects the parts of the response to be returned.</param>
        Task<OneCallWeatherInfo> GetWeatherOneCallAsync(double latitude, double longitude, OneCallOptions? oneCallOptions = null);

        /// <summary>
        /// Weather data for the given <paramref name="dateTime"/> (from 1979-01-01 up to 4 days ahead) using One Call API 3.0.
        /// https://openweathermap.org/api/one-call-3#history
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="dateTime">The requested timestamp.</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="dateTime"/> is before 1979-01-01.</exception>
        Task<OneCallTimeMachineInfo> GetWeatherOneCallTimeMachineAsync(double latitude, double longitude, DateTime dateTime);

        /// <summary>
        /// Aggregated weather data for the given <paramref name="date"/> (from 1979-01-02 up to 1.5 years ahead) using One Call API 3.0.
        /// The timezone is detected from the given coordinates.
        /// https://openweathermap.org/api/one-call-3#history_daily_aggregation
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="date">The requested date (the time part is ignored).</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="date"/> is before 1979-01-02.</exception>
        Task<OneCallDaySummary> GetWeatherOneCallDaySummaryAsync(double latitude, double longitude, DateTime date);

        /// <summary>
        /// Aggregated weather data for the given <paramref name="date"/> (from 1979-01-02 up to 1.5 years ahead) using One Call API 3.0.
        /// https://openweathermap.org/api/one-call-3#history_daily_aggregation
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="date">The requested date (the time part is ignored).</param>
        /// <param name="timezoneOffset">The timezone offset from UTC to be used for the aggregation (between -14h and +14h).</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="date"/> is before 1979-01-02 or <paramref name="timezoneOffset"/> is out of range.</exception>
        Task<OneCallDaySummary> GetWeatherOneCallDaySummaryAsync(double latitude, double longitude, DateTime date, TimeSpan timezoneOffset);

        /// <summary>
        /// Human-readable weather summary for today using One Call API 3.0.
        /// https://openweathermap.org/api/one-call-3#weather_overview
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        Task<OneCallWeatherOverview> GetWeatherOneCallOverviewAsync(double latitude, double longitude);

        /// <summary>
        /// Human-readable weather summary for the given <paramref name="date"/> (today or tomorrow) using One Call API 3.0.
        /// https://openweathermap.org/api/one-call-3#weather_overview
        /// </summary>
        /// <remarks>
        /// Requires an OpenWeatherMap "One Call by Call" subscription.
        /// </remarks>
        /// <param name="latitude">The GPS latitude.</param>
        /// <param name="longitude">The GPS longitude.</param>
        /// <param name="date">The requested date (the time part is ignored).</param>
        Task<OneCallWeatherOverview> GetWeatherOneCallOverviewAsync(double latitude, double longitude, DateTime date);

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
