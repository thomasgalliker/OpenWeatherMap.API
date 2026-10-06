using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    public class PrecipitationVolume
    {
        /// <summary>
        /// Precipitation volume for the last 1 hour, mm.
        /// </summary>
        [JsonPropertyName("1h")]
        [JsonConverter(typeof(MillimeterLengthJsonConverter))]
        public Length? Last1h { get; set; }

        /// <summary>
        /// Precipitation volume for the last 3 hours, mm.
        /// </summary>
        [JsonPropertyName("3h")]
        [JsonConverter(typeof(MillimeterLengthJsonConverter))]
        public Length? Last3h { get; set; }

        public override string ToString()
        {
            return $"1h: {this.Last1h}, 3h: {this.Last3h}";
        }
    }
}
