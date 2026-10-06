using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    public class AirQualitySummary
    {
        /// <summary>
        /// Air quality index.
        /// </summary>
        [JsonPropertyName("aqi")]
        [JsonConverter(typeof(AirQualityJsonConverter))]
        public AirQuality AirQuality { get; set; } = null!;
    }
}
