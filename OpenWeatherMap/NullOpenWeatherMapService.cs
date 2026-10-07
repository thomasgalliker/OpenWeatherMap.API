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

        public Task<OneCallWeatherInfo> GetWeatherOneCallAsync(double latitude, double longitude, OneCallOptions? oneCallOptions = null)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallTimeMachineInfo> GetWeatherOneCallTimeMachineAsync(double latitude, double longitude, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallDaySummary> GetWeatherOneCallDaySummaryAsync(double latitude, double longitude, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallDaySummary> GetWeatherOneCallDaySummaryAsync(double latitude, double longitude, DateTime date, TimeSpan timezoneOffset)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallWeatherOverview> GetWeatherOneCallOverviewAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallWeatherOverview> GetWeatherOneCallOverviewAsync(double latitude, double longitude, DateTime date)
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
