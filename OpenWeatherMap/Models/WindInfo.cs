using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;

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
        /// Wind direction, degrees (meteorological).
        /// </summary>
        [JsonProperty("deg")]
        public double? DirectionDegrees { get; set; }

        /// <summary>
        ///  Cardinal wind direction.
        /// </summary>
        [JsonIgnore]
        public CardinalWindDirection? Direction => this.DirectionDegrees is double d ? WindHelper.GetCardinalWindDirection(d) : null;

        /// <summary>
        /// Wind gust. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        /// </summary>
        [JsonProperty("gust")]
        public double? Gust { get; set; }

        public override string ToString()
        {
            return $"Speed: {this.Speed}, Direction: {this.DirectionDegrees}";
        }
    }
}
