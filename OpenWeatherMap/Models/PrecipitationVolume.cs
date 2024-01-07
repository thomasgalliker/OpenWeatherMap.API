using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PrecipitationVolume
    {
        /// <summary>
        /// Precipitation volume for the last 1 hour, mm.
        /// </summary>
        [JsonProperty("1h")]
        [JsonConverter(typeof(MillimeterLengthJsonConverter))]
        public Length? Last1h { get; set; }

        /// <summary>
        /// Precipitation volume for the last 3 hours, mm.
        /// </summary>
        [JsonProperty("3h")]
        [JsonConverter(typeof(MillimeterLengthJsonConverter))]
        public Length? Last3h { get; set; }

        public override string ToString()
        {
            return $"1h: {this.Last1h}, 3h: {this.Last3h}";
        }
    }
}
