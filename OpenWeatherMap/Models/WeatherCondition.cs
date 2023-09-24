using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    [DebuggerDisplay("{this.Id}")]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class WeatherCondition
    {
        /// <summary>
        /// Gets the identifier of the weather condition.
        /// See also: https://openweathermap.org/weather-conditions
        /// </summary>
        [JsonRequired]
        [JsonProperty("id")]
        [JsonConverter(typeof(WeatherConditionCodeJsonConverter))]
        public WeatherConditionCode Id { get; set; }

        /// <summary>
        /// Gets the scalar type of the weather condition.
        /// See also: https://openweathermap.org/weather-conditions
        /// </summary>
        [JsonRequired]
        [JsonProperty("main")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WeatherConditionGroup Main { get; set; }

        /// <summary>
        /// Gets the language-specific description of the weather condition.
        /// </summary>
        [JsonRequired]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets the openweathermap icon identifier (e.g. 09d).
        /// See also: https://openweathermap.org/weather-conditions#How-to-get-icon-URL
        /// </summary>
        [JsonRequired]
        [JsonProperty("icon")]
        public string IconId { get; set; }
    }
}