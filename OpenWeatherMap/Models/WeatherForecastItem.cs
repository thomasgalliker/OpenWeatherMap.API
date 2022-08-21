using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    [DebuggerDisplay("WeatherForecastItem: {DateTime}, {Main.Temperature}")]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class WeatherForecastItem
    {
        public WeatherForecastItem()
        {
            this.WeatherConditions = new List<WeatherCondition>();
        }

        [JsonProperty("dt")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("clouds")]
        public CloudsInformation Clouds { get; set; }

        [JsonProperty("rain")]
        public RainInformation Rain { get; set; }

        [JsonRequired]
        [JsonProperty("main")]
        public TemperatureInfo Main { get; set; }

        [JsonRequired]
        [JsonProperty("weather")]
        public IReadOnlyList<WeatherCondition> WeatherConditions { get; set; }

        [JsonProperty("wind")]
        public WindInformation Wind { get; set; }
    }
}
