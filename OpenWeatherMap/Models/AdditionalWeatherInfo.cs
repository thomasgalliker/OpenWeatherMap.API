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
        public RegionInfo Country { get; set; }

        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Sunset { get; set; }

        public override string ToString()
        {
            return $"Country: {this.Country}, Sunrise: {this.Sunrise}, Sunset: {this.Sunset}";
        }
    }
}
