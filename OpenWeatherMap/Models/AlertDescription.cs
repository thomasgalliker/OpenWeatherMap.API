using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Description of a weather alert in a specific language.
    /// </summary>
    public sealed class AlertDescription
    {
        /// <summary>
        /// Language of the description, e.g. "en-GB".
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; } = null!;

        /// <summary>
        /// The description text.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        public override string ToString()
        {
            return $"{this.Language}: {this.Description}";
        }
    }
}
