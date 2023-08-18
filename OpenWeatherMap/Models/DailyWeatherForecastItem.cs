using System;
using System.Diagnostics;
using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

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

        /// <summary>
        /// Daily volume of rain, in mm (where available).
        /// </summary>
        [JsonProperty("rain")]
        [JsonConverter(typeof(MillimeterLengthJsonConverter))]
        public Length Rain { get; set; } = Length.FromMillimeters(0d);
    }
}
