using System;
using System.Globalization;
using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AdditionalWeatherInfo
    {
        /// <summary>
        /// Country code.
        /// </summary>
        [JsonProperty("country")]
        [JsonConverter(typeof(RegionInfoJsonConverter))]
        public RegionInfo Country { get; set; }

        [JsonProperty("sunrise")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Sunrise { get; set; }

        [JsonProperty("sunset")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Sunset { get; set; }

        public override string ToString()
        {
            return $"Country: {this.Country}, Sunrise: {this.Sunrise}, Sunset: {this.Sunset}";
        }
    }
}