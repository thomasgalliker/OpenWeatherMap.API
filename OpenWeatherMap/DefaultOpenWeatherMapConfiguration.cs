namespace OpenWeatherMap
{
    public class DefaultOpenWeatherMapConfiguration : OpenWeatherMapConfiguration
    {
        public DefaultOpenWeatherMapConfiguration(string apiKey)
        {
            this.ApiEndpoint = "https://api.openweathermap.org";
            this.ApiKey = apiKey;
            this.UnitSystem = "metric";
            this.Language = "en";
        }
    }
}