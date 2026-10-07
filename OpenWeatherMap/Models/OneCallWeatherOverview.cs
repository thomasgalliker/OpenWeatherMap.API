using System;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Human-readable weather summary returned by One Call API 3.0 (onecall/overview).
    /// </summary>
    public sealed class OneCallWeatherOverview
    {
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
        /// Timezone in the ±XX:XX format, e.g. "+02:00".
        /// </summary>
        [JsonPropertyName("tz")]
        public string Timezone { get; set; } = null!;

        /// <summary>
        /// The date of the weather summary.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Units of measurement used in the response, see <see cref="UnitSystem"/>.
        /// </summary>
        [JsonPropertyName("units")]
        public string Units { get; set; } = null!;

        /// <summary>
        /// AI generated, human-readable weather summary.
        /// </summary>
        [JsonPropertyName("weather_overview")]
        public string WeatherOverview { get; set; } = null!;

        public override string ToString()
        {
            return this.WeatherOverview;
        }
    }
}
