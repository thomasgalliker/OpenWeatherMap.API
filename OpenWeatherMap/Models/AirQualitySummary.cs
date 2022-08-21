using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    public class AirQualitySummary
    {
        /// <summary>
        /// Air quality index.
        /// </summary>
        [JsonProperty("aqi")]
        [JsonConverter(typeof(AirQualityJsonConverter))]
        public AirQuality AirQuality { get; set; }
    }
}