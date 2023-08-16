using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class WindInfo
    {
        /// <summary>
        /// Wind speed. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        /// </summary>
        [JsonProperty("speed")]
        public double? Speed { get; set; }

        /// <summary>
        /// Wind direction (meteorological).
        /// </summary>
        [JsonProperty("deg")]
        [JsonConverter(typeof(WindDirectionJsonConverter))]
        public Angle Direction { get; set; }

        /// <summary>
        /// Wind gust. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        /// </summary>
        [JsonProperty("gust")]
        public double? Gust { get; set; }

        public override string ToString()
        {
            return $"Speed: {this.Speed}, Direction: {this.Direction.GetSecondaryIntercardinalWindDirection()}";
        }
    }
}
