using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Cloud cover information of a <see cref="OneCallDaySummary"/>.
    /// </summary>
    public sealed class DaySummaryCloudCover
    {
        /// <summary>
        /// Cloud cover at 12:00 for the requested date.
        /// </summary>
        [JsonPropertyName("afternoon")]
        [JsonConverter(typeof(PercentRatioJsonConverter))]
        public Ratio Afternoon { get; set; }
    }
}
