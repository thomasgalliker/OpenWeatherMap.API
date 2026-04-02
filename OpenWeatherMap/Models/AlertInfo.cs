using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    public class AlertInfo
    {
        public AlertInfo()
        {
            this.Tags = new List<string>();
        }

        [JsonPropertyName("sender_name")]
        public string SenderName { get; set; }

        [JsonPropertyName("event")]
        public string EventName { get; set; }

        [JsonPropertyName("start")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("end")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime EndTime { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("tags")]
        public IReadOnlyCollection<string> Tags { get; set; }
    }
}
