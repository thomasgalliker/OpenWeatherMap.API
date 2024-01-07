namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Weather condition groups.
    /// </summary>
    /// <remarks>
    /// https://openweathermap.org/weather-conditions
    /// </remarks>
    public enum WeatherConditionGroup : byte
    {
        Thunderstorm,
        Drizzle,
        Rain,
        Snow,
        Mist,
        Smoke,
        Haze,
        Dust,
        Fog,
        Sand,
        Ash,
        Squall,
        Tornado,
        Clear,
        Clouds,
    }
}