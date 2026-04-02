using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    public abstract class WeatherForecastBase
    {
        [JsonPropertyName("cod")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("cnt")]
        public int Count { get; set; }

        [JsonPropertyName("city")]
        public City City { get; set; }
    }
}
