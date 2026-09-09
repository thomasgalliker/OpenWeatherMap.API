using System.Diagnostics;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    [DebuggerDisplay("WeatherForecastItem: {DateTime}, {Main.Temperature}")]
    public class WeatherForecastItem
    {
        public WeatherForecastItem()
        {
            this.WeatherConditions = new List<WeatherCondition>();
        }

        [JsonPropertyName("dt")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("clouds")]
        public CloudsInformation Clouds { get; set; } = null!;

        [JsonPropertyName("rain")]
        public PrecipitationVolume Rain { get; set; } = null!;

        /// <summary>
        /// Probability of precipitation.
        /// The values of the parameter vary between 0 and 1, where 0 is equal to 0%, 1 is equal to 100%.
        /// </summary>
        [JsonPropertyName("pop")]
        [JsonConverter(typeof(DecimalFractionRatioJsonConverter))]
        public Ratio Pop { get; set; }

        [JsonRequired]
        [JsonPropertyName("main")]
        public TemperatureInfo Main { get; set; } = null!;

        [JsonRequired]
        [JsonPropertyName("weather")]
        public IReadOnlyList<WeatherCondition> WeatherConditions { get; set; }

        [JsonPropertyName("wind")]
        public WindInfo Wind { get; set; } = null!;
    }
}
