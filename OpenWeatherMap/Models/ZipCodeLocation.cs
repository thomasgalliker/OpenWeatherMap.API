using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// A location returned by the Geocoding API for a zip/post code.
    /// </summary>
    public sealed class ZipCodeLocation
    {
        /// <summary>
        /// The requested zip/post code.
        /// </summary>
        [JsonPropertyName("zip")]
        public string ZipCode { get; set; } = null!;

        /// <summary>
        /// Name of the found area.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Latitude of the centroid of the found zip/post code.
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the centroid of the found zip/post code.
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// ISO 3166 country code of the found zip/post code.
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; } = null!;

        public override string ToString()
        {
            return $"{this.ZipCode} {this.Name}, {this.Country} ({this.Latitude}, {this.Longitude})";
        }
    }
}
