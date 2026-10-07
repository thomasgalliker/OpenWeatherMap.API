using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Maximum wind information of a <see cref="DaySummaryWind"/>.
    /// </summary>
    public sealed class DaySummaryMaxWind
    {
        /// <summary>
        /// Maximum wind speed for the requested date.
        /// </summary>
        [JsonPropertyName("speed")]
        public Speed Speed { get; set; } = Speed.FromMetersPerSecond(0d);

        /// <summary>
        /// Wind direction (meteorological) relevant to the maximum wind speed.
        /// </summary>
        [JsonPropertyName("direction")]
        [JsonConverter(typeof(WindDirectionJsonConverter))]
        public Angle Direction { get; set; }
    }
}
