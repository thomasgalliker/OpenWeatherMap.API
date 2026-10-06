using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    public class WeatherForecast : WeatherForecastBase
    {
        public WeatherForecast()
        {
            this.Items = new List<WeatherForecastItem>();
        }

        [JsonPropertyName("list")]
        public IReadOnlyCollection<WeatherForecastItem> Items { get; set; }

        public override string ToString()
        {
            var orderedItems = this.Items.OrderBy(i => i.DateTime).ToArray();
            return $"From: {orderedItems.First().DateTime}, To: {orderedItems.Last().DateTime}";
        }
    }
}
