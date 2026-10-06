using System;
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
        /// <returns></returns>
        Task<WeatherInfo> GetCurrentWeatherAsync(double latitude, double longitude);

        /// <summary>
        /// Hourly forecast for 4 days (max. 96 timestamps).
        /// https://openweathermap.org/api/hourly-forecast
        /// </summary>
        /// <param name="count">Number of 1-hour forecasts to be returned.</param>
        Task<WeatherForecast> GetWeatherForecast4Async(double latitude, double longitude, int? count = null);

        /// <summary>
        /// 5 day / 3 hour forecast (max. 40 timestamps).
        /// https://openweathermap.org/forecast5
        /// </summary>
        /// <param name="count">Number of 3-hour forecasts to be returned.</param>
        Task<WeatherForecast> GetWeatherForecast5Async(double latitude, double longitude, int? count = null);

        /// <summary>
        /// 16 day / daily forecast (max. 17 timestamps).
        /// https://openweathermap.org/forecast16
        /// </summary>
        /// <param name="count">Number of days to be returned.</param>
        Task<WeatherForecastDaily> GetWeatherForecastDailyAsync(double latitude, double longitude, int? count = null);

        Task<Stream> GetWeatherIconAsync(WeatherCondition weatherCondition, IWeatherIconMapping? weatherIconMapping = null);

        /// <summary>
        /// Current weather, minutely, hourly and daily forecasts and weather alerts using One Call API 2.5.
        /// </summary>
        /// <param name="oneCallOptions">Selects the parts of the response to be returned.</param>
        [Obsolete(ObsoleteMessages.OneCallApi25Retired, error: false)]
        Task<OneCallWeatherInfo> GetWeatherOneCallAsync(double latitude, double longitude, OneCallOptions? oneCallOptions = null);

        /// <summary>
        /// Historical weather data for the given <paramref name="dateTime"/> using One Call API 2.5.
        /// </summary>
        /// <param name="onlyCurrent">Returns only the current weather data if set to <c>true</c>.</param>
        [Obsolete(ObsoleteMessages.OneCallApi25Retired, error: false)]
        Task<OneCallWeatherInfo> GetWeatherOneCallHistoricAsync(double latitude, double longitude, DateTime dateTime, bool onlyCurrent = false);

        Task<AirPollutionInfo> GetAirPollutionAsync(double latitude, double longitude);
    }
}
