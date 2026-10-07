using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// A location returned by the Geocoding API (direct and reverse geocoding).
    /// </summary>
    public sealed class GeocodingLocation
    {
        public GeocodingLocation()
        {
            this.LocalNames = new Dictionary<string, string>();
        }

        /// <summary>
        /// Name of the found location.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Name of the found location in different languages, keyed by language code (where available).
        /// </summary>
        [JsonPropertyName("local_names")]
        public IReadOnlyDictionary<string, string> LocalNames { get; set; }

        /// <summary>
        /// Latitude of the found location.
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the found location.
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// ISO 3166 country code of the found location.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; } = null!;

        /// <summary>
        /// State of the found location (where available).
        /// </summary>
        [JsonPropertyName("state")]
        public string? State { get; set; }

        public override string ToString()
        {
            return $"{this.Name}, {this.Country} ({this.Latitude}, {this.Longitude})";
        }
    }
}
