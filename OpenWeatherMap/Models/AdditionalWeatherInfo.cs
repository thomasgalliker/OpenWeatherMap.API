using System;
using System.Globalization;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    public class AdditionalWeatherInfo
    {
        /// <summary>
        /// Country code.
        /// </summary>
        [JsonPropertyName("country")]
        [JsonConverter(typeof(RegionInfoJsonConverter))]
        public RegionInfo? Country { get; set; }

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

        public override string ToString()
        {
            return $"Country: {this.Country}, Sunrise: {this.Sunrise}, Sunset: {this.Sunset}";
        }
    }
}
