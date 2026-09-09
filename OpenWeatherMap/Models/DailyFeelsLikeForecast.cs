using System.Text.Json.Serialization;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    public class DailyFeelsLikeForecast
    {
        [JsonPropertyName("day")]
        public Temperature Day { get; set; }

        [JsonPropertyName("night")]
        public Temperature Night { get; set; }

        [JsonPropertyName("eve")]
        public Temperature Evening { get; set; }

        [JsonPropertyName("morn")]
        public Temperature Morning { get; set; }

        public override string ToString()
        {
            return $"Morning: {this.Morning}, Day: {this.Day}, Evening: {this.Evening}, Night: {this.Night}";
        }
    }
}