using System;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    public class AirPollutionInfoItem
    {
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("main")]
        public AirQualitySummary Main { get; set; } = null!;

        [JsonPropertyName("components")]
        public AirConcentrationComponents Components { get; set; } = null!;
    }
}
