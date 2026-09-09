using System.Text.Json.Serialization;
using OpenWeatherMap.Extensions;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    public class WindInfo
    {
        /// <summary>
        /// Wind speed.
        /// </summary>
        [JsonPropertyName("speed")]
        public Speed Speed { get; set; } = Speed.FromMetersPerSecond(0d);

        /// <summary>
        /// Wind direction (meteorological).
        /// </summary>
        [JsonPropertyName("deg")]
        [JsonConverter(typeof(WindDirectionJsonConverter))]
        public Angle Direction { get; set; }

        /// <summary>
        /// Wind gust.
        /// </summary>
        [JsonPropertyName("gust")]
        public Speed? Gust { get; set; }

        public override string ToString()
        {
            return $"Speed: {this.Speed}, Direction: {this.Direction.ToIntercardinalWindDirection()}";
        }
    }
}
