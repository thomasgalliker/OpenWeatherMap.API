using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class PrecipitationSpeed
    {
        /// <summary>
        /// Precipitation speed for the last 1 hour, mm/h.
        /// </summary>
        [JsonProperty("1h")]
        [JsonConverter(typeof(MillimeterPerHourJsonConverter))]
        public Speed? Last1h { get; set; }

        public override string ToString()
        {
            return $"1h: {this.Last1h}";
        }
    }
}