using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Wind information of a <see cref="OneCallDaySummary"/>.
    /// </summary>
    public sealed class DaySummaryWind
    {
        /// <summary>
        /// Maximum wind speed and its direction for the requested date.
        /// </summary>
        [JsonPropertyName("max")]
        public DaySummaryMaxWind Max { get; set; } = null!;
    }
}
