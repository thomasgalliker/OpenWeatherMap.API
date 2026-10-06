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
        internal const string OneCall = "onecall.json";
        internal const string OneCallTimeMachine = "onecall_timemachine.json";
        internal const string OneCallDaySummary = "onecall_day_summary.json";
        internal const string OneCallOverview = "onecall_overview.json";
        internal const string AirPollution = "air_pollution.json";
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
