using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    public class OneCallWeatherInfo
    {
        public OneCallWeatherInfo()
        {
            this.HourlyForecasts = new List<HourlyWeatherForecast>();
            this.MinutelyForecasts = new List<MinutelyWeatherForecast>();
            this.DailyForecasts = new List<DailyWeatherForecast>();
            this.Alerts = new List<AlertInfo>();
        }

        // TODO: Use Geolocation
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        // TODO: Use Geolocation
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; } = null!;

        [JsonPropertyName("timezone_offset")]
        public int TimezoneOffset { get; set; }

        /// <summary>
        /// Gets the weather forecast for today.
        /// </summary>
        /// <remarks>
        /// Is only included if <seealso cref="OneCallOptions.IncludeCurrentWeather"/> is true.
        /// </remarks>
        [JsonPropertyName("current")]
        public CurrentWeatherForecast CurrentWeather { get; set; } = null!;

        /// <summary>
        /// 60-minutes weather forecast.
        /// </summary>
        /// <remarks>
        /// Is only included if <seealso cref="OneCallOptions.IncludeMinutelyForecasts"/> is true.
        /// </remarks>
        [JsonPropertyName("minutely")]
        public IReadOnlyCollection<MinutelyWeatherForecast> MinutelyForecasts { get; set; }

        /// <summary>
        /// 48-hours weather forecast.
        /// </summary>
        /// <remarks>
        /// Is only included if <seealso cref="OneCallOptions.IncludeHourlyForecasts"/> is true.
        /// </remarks>
        [JsonPropertyName("hourly")]
        public IReadOnlyCollection<HourlyWeatherForecast> HourlyForecasts { get; set; }

        /// <summary>
        /// 8-days weather forecast.
        /// </summary>
        /// <remarks>
        /// Is only included if <seealso cref="OneCallOptions.IncludeDailyForecasts"/> is true.
        /// </remarks>
        [JsonPropertyName("daily")]
        public IReadOnlyCollection<DailyWeatherForecast> DailyForecasts { get; set; }

        [JsonPropertyName("alerts")]
        public IReadOnlyCollection<AlertInfo> Alerts { get; set; }

        public override string ToString()
        {
            var displayItems = new[]
            {
                (Name: "Minutely", this.MinutelyForecasts.Count),
                (Name: "Hourly", this.HourlyForecasts.Count),
                (Name: "Daily", this.DailyForecasts.Count),
                (Name: "Alerts", this.Alerts.Count) }
            .Where(x => x.Count > 0)
            .Select(x => $"{x.Name}: {x.Count}")
            .ToList();

            if (this.CurrentWeather is CurrentWeatherForecast c)
            {
                displayItems.Insert(0, $"CurrentWeather: {c.Temperature}");
            }

            var toStringVaue = string.Join(", ", displayItems);
            return toStringVaue;
        }
    }
}