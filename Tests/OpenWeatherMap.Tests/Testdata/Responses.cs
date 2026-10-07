using System.Reflection;

namespace OpenWeatherMap.Tests.Testdata
{
    /// <summary>
    /// JSON responses of the OpenWeatherMap API, embedded from folder Testdata/Responses.
    /// Responses of free API methods are recorded from the live API;
    /// responses of API methods which require a paid plan follow the documented response format.
    /// </summary>
    internal static class Responses
    {
        internal const string CurrentWeather = "weather.json";
        internal const string Forecast5 = "forecast.json";
        internal const string ForecastHourly = "forecast_hourly.json";
        internal const string ForecastDaily = "forecast_daily.json";
        internal const string OneCallCurrent = "onecall_current.json";
        internal const string OneCallMinutely = "onecall_1min.json";
        internal const string OneCall15Minutes = "onecall_15min.json";
        internal const string OneCallHourly = "onecall_1h.json";
        internal const string OneCallDaily = "onecall_1day.json";
        internal const string OneCallAlert = "onecall_alert.json";
        internal const string AirPollution = "air_pollution.json";
        internal const string AirPollutionForecast = "air_pollution_forecast.json";
        internal const string AirPollutionHistory = "air_pollution_history.json";
        internal const string GeocodingDirect = "geo_direct.json";
        internal const string GeocodingZip = "geo_zip.json";
        internal const string GeocodingReverse = "geo_reverse.json";

        private static readonly Assembly Assembly = typeof(Responses).Assembly;

        internal static string GetJson(string fileName)
        {
            return ResourceLoader.Current.GetEmbeddedResourceString(Assembly, $"Responses.{fileName}");
        }
    }
}
