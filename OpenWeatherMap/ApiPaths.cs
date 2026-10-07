namespace OpenWeatherMap
{
    /// <summary>
    /// Relative paths of the OpenWeatherMap API endpoints.
    /// </summary>
    internal static class ApiPaths
    {
        internal const string CurrentWeather = "data/2.5/weather";
        internal const string Forecast = "data/2.5/forecast";
        internal const string ForecastHourly = "data/2.5/forecast/hourly";
        internal const string ForecastDaily = "data/2.5/forecast/daily";
        internal const string OneCallCurrent = "data/4.0/onecall/current";
        internal const string OneCallTimelinePrefix = "data/4.0/onecall/timeline/";
        internal const string OneCallTimeline1Minute = OneCallTimelinePrefix + "1min";
        internal const string OneCallTimeline15Minutes = OneCallTimelinePrefix + "15min";
        internal const string OneCallTimeline1Hour = OneCallTimelinePrefix + "1h";
        internal const string OneCallTimeline1Day = OneCallTimelinePrefix + "1day";
        internal const string OneCallAlert = "data/4.0/onecall/alert";
        internal const string AirPollution = "data/2.5/air_pollution";
        internal const string AirPollutionForecast = "data/2.5/air_pollution/forecast";
        internal const string AirPollutionHistory = "data/2.5/air_pollution/history";
        internal const string GeocodingDirect = "geo/1.0/direct";
        internal const string GeocodingZip = "geo/1.0/zip";
        internal const string GeocodingReverse = "geo/1.0/reverse";
    }
}
