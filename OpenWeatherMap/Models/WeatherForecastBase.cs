using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    public abstract class WeatherForecastBase
    {
        [JsonPropertyName("cod")]
        public string Code { get; set; } = null!;

        [JsonPropertyName("message")]
        [JsonConverter(typeof(StringOrNumberJsonConverter))]
        public string Message { get; set; } = null!;

        [JsonPropertyName("cnt")]
        public int Count { get; set; }

        [JsonPropertyName("city")]
        public City City { get; set; } = null!;
    }
}
