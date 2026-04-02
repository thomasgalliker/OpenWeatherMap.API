using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    public class WeatherForecastDaily : WeatherForecastBase
    {
        public WeatherForecastDaily()
        {
            this.Items = new List<DailyWeatherForecastItem>();
        }

        [JsonPropertyName("list")]
        public IReadOnlyCollection<DailyWeatherForecastItem> Items { get; set; }

        public override string ToString()
        {
            var orderedItems = this.Items.OrderBy(i => i.DateTime);
            return $"From: {orderedItems.First().DateTime}, To: {orderedItems.Last().DateTime}";
        }
    }
}
