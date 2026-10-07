using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Response of a One Call API 4.0 endpoint: a (page of a) timeline of weather records for a location.
    /// </summary>
    /// <typeparam name="T">The type of the weather records.</typeparam>
    public sealed class OneCallTimeline<T>
    {
        public OneCallTimeline()
        {
            this.Data = new List<T>();
        }

        /// <summary>
        /// Latitude of the location.
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the location.
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Timezone name of the requested location, e.g. "Europe/Zurich".
        /// </summary>
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; } = null!;

        /// <summary>
        /// Shift in seconds from UTC.
        /// </summary>
        [JsonPropertyName("timezone_offset")]
        public int TimezoneOffset { get; set; }

        /// <summary>
        /// The weather records.
        /// </summary>
        [JsonPropertyName("data")]
        public IReadOnlyList<T> Data { get; set; }

        /// <summary>
        /// API URL of the previous page of the timeline (if available).
        /// Use <see cref="IOpenWeatherMapService.GetWeatherOneCallPreviousPageAsync{T}"/> to request it.
        /// </summary>
        [JsonPropertyName("prev")]
        public string? Previous { get; set; }

        /// <summary>
        /// API URL of the next page of the timeline (if available).
        /// Use <see cref="IOpenWeatherMapService.GetWeatherOneCallNextPageAsync{T}"/> to request it.
        /// </summary>
        [JsonPropertyName("next")]
        public string? Next { get; set; }

        public override string ToString()
        {
            return $"Timezone: {this.Timezone}, Data: {this.Data.Count}";
        }
    }
}
