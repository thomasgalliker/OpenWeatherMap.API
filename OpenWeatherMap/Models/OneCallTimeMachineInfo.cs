using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Weather data for a single timestamp returned by One Call API 3.0 (onecall/timemachine).
    /// </summary>
    public sealed class OneCallTimeMachineInfo
    {
        public OneCallTimeMachineInfo()
        {
            this.Data = new List<CurrentWeatherForecast>();
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
        /// Weather data for the requested timestamp.
        /// </summary>
        [JsonPropertyName("data")]
        public IReadOnlyCollection<CurrentWeatherForecast> Data { get; set; }

        public override string ToString()
        {
            return $"Timezone: {this.Timezone}, Data: {this.Data.Count}";
        }
    }
}
