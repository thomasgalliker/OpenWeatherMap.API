using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    public class PrecipitationSpeed
    {
        /// <summary>
        /// Precipitation speed for the last 1 hour, mm/h.
        /// </summary>
        [JsonPropertyName("1h")]
        [JsonConverter(typeof(MillimeterPerHourJsonConverter))]
        public Speed? Last1h { get; set; }

        public override string ToString()
        {
            return $"1h: {this.Last1h}";
        }
    }
}
