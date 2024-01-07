namespace OpenWeatherMap
{
    public class OpenWeatherMapOptions
    {
        public OpenWeatherMapOptions()
        {
            this.ApiEndpoint = "https://api.openweathermap.org";
            this.ApiKey = null;
            this.UnitSystem = "metric";
            this.Language = "en";
        }

        public virtual string ApiEndpoint { get; set; }

        public virtual string ApiKey { get; set; }

        public virtual string UnitSystem { get; set; }

        public virtual string Language { get; set; }

        public virtual bool VerboseLogging { get; set; }
    }
}