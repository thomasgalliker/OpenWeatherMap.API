using System;
using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    public class AirPollutionInfoItem
    {
        [JsonProperty("dt")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("main")]
        public AirQualitySummary Main { get; set; }

        [JsonProperty("components")]
        public AirConcentrationComponents Components { get; set; }
    }
}