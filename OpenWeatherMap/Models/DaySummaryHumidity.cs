using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Humidity information of a <see cref="OneCallDaySummary"/>.
    /// </summary>
    public sealed class DaySummaryHumidity
    {
        /// <summary>
        /// Relative humidity at 12:00 for the requested date.
        /// </summary>
        [JsonPropertyName("afternoon")]
        [JsonConverter(typeof(HumidityJsonConverter))]
        public RelativeHumidity Afternoon { get; set; }
    }
}
