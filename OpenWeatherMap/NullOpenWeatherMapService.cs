using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;
using OpenWeatherMap.Models;
using UnitsNet;
using UnitsNet.Units;

namespace OpenWeatherMap
{
    [ExcludeFromCodeCoverage]
    public class NullOpenWeatherMapService : IOpenWeatherMapService
    {
        private readonly OpenWeatherMapOptions options;

        public NullOpenWeatherMapService(OpenWeatherMapOptions options)
        {
            this.options = options;
        }

        public Task<AirPollutionInfo> GetAirPollutionAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public Task<AirPollutionInfo> GetAirPollutionForecastAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public Task<AirPollutionInfo> GetAirPollutionHistoryAsync(double latitude, double longitude, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherInfo> GetCurrentWeatherAsync(double latitude, double longitude)
        {
            return Task.FromResult(new WeatherInfo
            {
                Main = new TemperatureInfo
                {
                    Temperature = new Temperature(-27d, TemperatureUnit.DegreeCelsius),
                }
            });
        }

        public Task<WeatherForecastDaily> GetWeatherForecastDailyAsync(double latitude, double longitude, int? count = null)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast> GetWeatherForecast4Async(double latitude, double longitude, int? count = null)
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast> GetWeatherForecast5Async(double latitude, double longitude, int? count = null)
        {
            throw new NotImplementedException();
        }

        public Task<Stream> GetWeatherIconAsync(WeatherCondition weatherCondition, IWeatherIconMapping? weatherIconMapping = null)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallTimeline<CurrentWeatherForecast>> GetWeatherOneCallCurrentAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallTimeline<MinutelyWeatherForecast>> GetWeatherOneCallMinutelyAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCall15MinutesAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCall15MinutesAsync(double latitude, double longitude, DateTime start)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCallHourlyAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallTimeline<TimelineWeatherForecast>> GetWeatherOneCallHourlyAsync(double latitude, double longitude, DateTime start)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallTimeline<DailyWeatherForecast>> GetWeatherOneCallDailyAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallTimeline<DailyWeatherForecast>> GetWeatherOneCallDailyAsync(double latitude, double longitude, DateTime start)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallTimeline<T>?> GetWeatherOneCallNextPageAsync<T>(OneCallTimeline<T> timeline)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallTimeline<T>?> GetWeatherOneCallPreviousPageAsync<T>(OneCallTimeline<T> timeline)
        {
            throw new NotImplementedException();
        }

        public Task<AlertInfo> GetWeatherOneCallAlertAsync(string alertId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByNameAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByNameAsync(string query, int limit)
        {
            throw new NotImplementedException();
        }

        public Task<ZipCodeLocation> GetLocationByZipCodeAsync(string zipCode, string countryCode)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByCoordinatesAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<GeocodingLocation>> GetLocationsByCoordinatesAsync(double latitude, double longitude, int limit)
        {
            throw new NotImplementedException();
        }
    }
}
