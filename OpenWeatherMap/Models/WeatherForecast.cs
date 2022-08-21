using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OpenWeatherMap.Models
{
    public class WeatherForecast : WeatherForecastBase
    {
        public WeatherForecast()
        {
            this.Items = new List<WeatherForecastItem>();
        }

        [JsonProperty("list")]
        public IReadOnlyCollection<WeatherForecastItem> Items { get; set; }

        public override string ToString()
        {
            var orderedItems = this.Items.OrderBy(i => i.DateTime);
            return $"From: {orderedItems.First().DateTime}, To: {orderedItems.Last().DateTime}";
        }
    }
}
