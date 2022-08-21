using System;
using System.Diagnostics;
using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    [DebuggerDisplay("WeatherForecastItem: {DateTime}, {Temperature}")]
    public class DailyWeatherForecastItem
    {
        [JsonProperty("dt")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("temp")]
        public DailyTemperatureForecast Temperature { get; set; }

        [JsonProperty("feels_like")]
        public DailyFeelsLikeForecast FeelsLike { get; set; }

        [JsonProperty("clouds")]
        public double Clouds { get; set; }

        [JsonProperty("rain")]
        public double Rain { get; set; }
    }
}
