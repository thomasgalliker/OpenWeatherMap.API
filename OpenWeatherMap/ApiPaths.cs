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
        internal const string OneCall = "data/3.0/onecall";
        internal const string OneCallTimeMachine = "data/3.0/onecall/timemachine";
        internal const string OneCallDaySummary = "data/3.0/onecall/day_summary";
        internal const string OneCallOverview = "data/3.0/onecall/overview";
        internal const string AirPollution = "data/2.5/air_pollution";
    }
}
