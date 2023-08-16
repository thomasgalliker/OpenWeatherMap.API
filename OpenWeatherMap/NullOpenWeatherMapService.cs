using System;
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
        private readonly IOpenWeatherMapConfiguration openWeatherMapConfiguration;

        public NullOpenWeatherMapService(IOpenWeatherMapConfiguration openWeatherMapConfiguration)
        {
            this.openWeatherMapConfiguration = openWeatherMapConfiguration;
        }

        public Task<AirPollutionInfo> GetAirPollutionAsync(double latitude, double longitude)
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

        public Task<Stream> GetWeatherIconAsync(WeatherCondition weatherCondition, IWeatherIconMapping weatherIconMapping = null)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallWeatherInfo> GetWeatherOneCallAsync(double latitude, double longitude, OneCallOptions oneCallOptions = null)
        {
            throw new NotImplementedException();
        }

        public Task<OneCallWeatherInfo> GetWeatherOneCallHistoricAsync(double latitude, double longitude, DateTime dateTime, bool onlyCurrent = false)
        {
            throw new NotImplementedException();
        }
    }
}