using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Precipitation information of a <see cref="OneCallDaySummary"/>.
    /// </summary>
    public sealed class DaySummaryPrecipitation
    {
        /// <summary>
        /// Total amount of liquid water equivalent of precipitation for the requested date.
        /// </summary>
        [JsonPropertyName("total")]
        [JsonConverter(typeof(MillimeterLengthJsonConverter))]
        public Length Total { get; set; } = Length.FromMillimeters(0d);
    }
}
