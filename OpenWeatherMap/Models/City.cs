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
        public string Name { get; set; }

        /// <summary>
        /// City geo location.
        /// </summary>
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// Country code.
        /// </summary>
        [JsonPropertyName("country")]
        [JsonConverter(typeof(RegionInfoJsonConverter))]
        public RegionInfo Country { get; set; }

        [JsonPropertyName("population")]
        public int Population { get; set; }

        /// <summary>
        /// Shift in seconds from UTC.
        /// </summary>
        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Sunset { get; set; }
    }
}
