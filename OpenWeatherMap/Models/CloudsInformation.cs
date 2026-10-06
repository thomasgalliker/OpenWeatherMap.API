using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    public class CloudsInformation
    {
        /// <summary>
        /// Gets the cloudiness in percent (%).
        /// </summary>
        [JsonPropertyName("all")]
        [JsonConverter(typeof(PercentRatioJsonConverter))]
        public Ratio All { get; set; }

        /// <summary>
        /// Gets the cloudiness today in percent (%).
        /// </summary>
        [JsonPropertyName("today")]
        [JsonConverter(typeof(PercentRatioJsonConverter))]
        public Ratio Today { get; set; }
    }
}