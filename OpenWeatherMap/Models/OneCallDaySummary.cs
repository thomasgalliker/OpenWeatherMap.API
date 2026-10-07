using System;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Aggregated weather data for a particular date returned by One Call API 3.0 (onecall/day_summary).
    /// </summary>
    public sealed class OneCallDaySummary
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
        /// The requested date.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Units of measurement used in the response, see <see cref="UnitSystem"/>.
        /// </summary>
        [JsonPropertyName("units")]
        public string Units { get; set; } = null!;

        /// <summary>
        /// Cloud cover information.
        /// </summary>
        [JsonPropertyName("cloud_cover")]
        public DaySummaryCloudCover CloudCover { get; set; } = null!;

        /// <summary>
        /// Humidity information.
        /// </summary>
        [JsonPropertyName("humidity")]
        public DaySummaryHumidity Humidity { get; set; } = null!;

        /// <summary>
        /// Precipitation information.
        /// </summary>
        [JsonPropertyName("precipitation")]
        public DaySummaryPrecipitation Precipitation { get; set; } = null!;

        /// <summary>
        /// Temperature information.
        /// </summary>
        [JsonPropertyName("temperature")]
        public DaySummaryTemperature Temperature { get; set; } = null!;

        /// <summary>
        /// Atmospheric pressure information.
        /// </summary>
        [JsonPropertyName("pressure")]
        public DaySummaryPressure Pressure { get; set; } = null!;

        /// <summary>
        /// Wind information.
        /// </summary>
        [JsonPropertyName("wind")]
        public DaySummaryWind Wind { get; set; } = null!;

        public override string ToString()
        {
            return $"Date: {this.Date:yyyy-MM-dd}, Temperature: {this.Temperature?.Min}/{this.Temperature?.Max}";
        }
    }
}
