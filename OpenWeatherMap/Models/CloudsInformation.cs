using Newtonsoft.Json;

namespace OpenWeatherMap.Models
{
    public class CloudsInformation
    {
        /// <summary>
        ///     Gets the cloudiness in percent (%).
        /// </summary>
        [JsonProperty("all")]
        public double All { get; set; }

        /// <summary>
        ///     Gets the cloudiness today in percent (%).
        /// </summary>
        [JsonProperty("today")]
        public double Today { get; set; }
    }
}