using System;
using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

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
        /// Precipitation volume.
        /// </summary>
        [JsonProperty("precipitation")]
        [JsonConverter(typeof(MillimeterPerHourJsonConverter))]
        public Speed Precipitation { get; set; }

        public override string ToString()
        {
            return $"DateTime: {this.DateTime}, Precipitation: {this.Precipitation}";
        }
    }
}