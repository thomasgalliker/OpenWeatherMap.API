using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Atmospheric pressure information of a <see cref="OneCallDaySummary"/>.
    /// </summary>
    public sealed class DaySummaryPressure
    {
        /// <summary>
        /// Atmospheric pressure at 12:00 for the requested date.
        /// </summary>
        [JsonPropertyName("afternoon")]
        [JsonConverter(typeof(PressureJsonConverter))]
        public Pressure Afternoon { get; set; }
    }
}
