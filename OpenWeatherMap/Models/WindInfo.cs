using Newtonsoft.Json;
using OpenWeatherMap.Extensions;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class WindInfo
    {
        /// <summary>
        /// Wind speed.
        /// </summary>
        [JsonProperty("speed")]
        public Speed Speed { get; set; } = Speed.FromMetersPerSecond(0d);

        /// <summary>
        /// Wind direction (meteorological).
        /// </summary>
        [JsonProperty("deg")]
        [JsonConverter(typeof(WindDirectionJsonConverter))]
        public Angle Direction { get; set; }

        /// <summary>
        /// Wind gust.
        /// </summary>
        [JsonProperty("gust")]
        public Speed? Gust { get; set; }

        public override string ToString()
        {
            return $"Speed: {this.Speed}, Direction: {this.Direction.ToIntercardinalWindDirection()}";
        }
    }
}
