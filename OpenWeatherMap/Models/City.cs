using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    [DebuggerDisplay("{Name}")]
    public class City
    {
        /// <summary>
        /// City ID.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// City geo location.
        /// </summary>
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; } = null!;

        /// <summary>
        /// Country code.
        /// </summary>
        [JsonPropertyName("country")]
        [JsonConverter(typeof(RegionInfoJsonConverter))]
        public RegionInfo? Country { get; set; }

        [JsonPropertyName("population")]
        public int Population { get; set; }

        /// <summary>
        /// Shift in seconds from UTC.
        /// </summary>
        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        /// <summary>
        /// Sunrise time (UTC). <c>null</c> in polar areas during midnight sun and polar night.
        /// </summary>
        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(NullableEpochDateTimeConverter))]
        public DateTime? Sunrise { get; set; }

        /// <summary>
        /// Sunset time (UTC). <c>null</c> in polar areas during midnight sun and polar night.
        /// </summary>
        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(NullableEpochDateTimeConverter))]
        public DateTime? Sunset { get; set; }
    }
}
