using System.Text.Json.Serialization;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Temperature information of a <see cref="OneCallDaySummary"/>.
    /// </summary>
    public sealed class DaySummaryTemperature
    {
        /// <summary>
        /// Minimum temperature for the requested date.
        /// </summary>
        [JsonPropertyName("min")]
        public Temperature Min { get; set; }

        /// <summary>
        /// Maximum temperature for the requested date.
        /// </summary>
        [JsonPropertyName("max")]
        public Temperature Max { get; set; }

        /// <summary>
        /// Temperature at 06:00 for the requested date.
        /// </summary>
        [JsonPropertyName("morning")]
        public Temperature Morning { get; set; }

        /// <summary>
        /// Temperature at 12:00 for the requested date.
        /// </summary>
        [JsonPropertyName("afternoon")]
        public Temperature Afternoon { get; set; }

        /// <summary>
        /// Temperature at 18:00 for the requested date.
        /// </summary>
        [JsonPropertyName("evening")]
        public Temperature Evening { get; set; }

        /// <summary>
        /// Temperature at 00:00 for the requested date.
        /// </summary>
        [JsonPropertyName("night")]
        public Temperature Night { get; set; }
    }
}
