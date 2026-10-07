using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Detailed information of a national weather alert returned by One Call API 4.0 (onecall/alert).
    /// </summary>
    public class AlertInfo
    {
        public AlertInfo()
        {
            this.Descriptions = new List<AlertDescription>();
            this.Tags = new List<string>();
        }

        /// <summary>
        /// The alert ID.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// Name of the alert source.
        /// </summary>
        [JsonPropertyName("sender_name")]
        public string SenderName { get; set; } = null!;

        /// <summary>
        /// Alert event name.
        /// </summary>
        [JsonPropertyName("event")]
        public string EventName { get; set; } = null!;

        /// <summary>
        /// Start of the alert (UTC).
        /// </summary>
        [JsonPropertyName("start")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End of the alert (UTC).
        /// </summary>
        [JsonPropertyName("end")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Descriptions of the alert in the languages provided by the alert source.
        /// </summary>
        [JsonPropertyName("description")]
        public IReadOnlyCollection<AlertDescription> Descriptions { get; set; }

        /// <summary>
        /// Type of severe weather (where available).
        /// </summary>
        [JsonPropertyName("tags")]
        public IReadOnlyCollection<string> Tags { get; set; }

        public override string ToString()
        {
            return $"{this.SenderName}: {this.EventName} ({this.StartTime:O} - {this.EndTime:O})";
        }
    }
}
