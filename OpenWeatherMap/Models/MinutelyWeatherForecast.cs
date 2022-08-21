using System;
using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;

namespace OpenWeatherMap.Models
{
    public class MinutelyWeatherForecast
    {
        /// <summary>
        /// Time of the forecasted data.
        /// </summary>
        [JsonProperty("dt")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Precipitation volume, mm.
        /// </summary>
        [JsonProperty("precipitation ")]
        public double Precipitation { get; set; }

        public override string ToString()
        {
            return $"DateTime: {this.DateTime}, Precipitation: {this.Precipitation}";
        }
    }
}