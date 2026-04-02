using System.Diagnostics;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    [DebuggerDisplay("{this.Id}")]
    public class WeatherCondition
    {
        /// <summary>
        /// Gets the identifier of the weather condition.
        /// See also: https://openweathermap.org/weather-conditions
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("id")]
        [JsonConverter(typeof(WeatherConditionCodeJsonConverter))]
        public WeatherConditionCode Id { get; set; }

        /// <summary>
        /// Gets the scalar type of the weather condition.
        /// See also: https://openweathermap.org/weather-conditions
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("main")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeatherConditionGroup Main { get; set; }

        /// <summary>
        /// Gets the language-specific description of the weather condition.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets the openweathermap icon identifier (e.g. 09d).
        /// See also: https://openweathermap.org/weather-conditions#How-to-get-icon-URL
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("icon")]
        public string IconId { get; set; }
    }
}
