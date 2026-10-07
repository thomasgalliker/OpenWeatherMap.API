using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Weather record of the 1 minute step timeline of One Call API 4.0.
    /// </summary>
    public class MinutelyWeatherForecast
    {
        /// <summary>
        /// Time of the forecasted data.
        /// </summary>
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Precipitation volume.
        /// </summary>
        [JsonPropertyName("precipitation")]
        [JsonConverter(typeof(MillimeterPerHourJsonConverter))]
        public Speed Precipitation { get; set; }


        /// <summary>
        /// IDs of the weather alerts associated with the location and time.
        /// Use <see cref="IOpenWeatherMapService.GetWeatherOneCallAlertAsync"/> to get the details of an alert.
        /// </summary>
        [JsonPropertyName("alerts")]
        public IReadOnlyCollection<string> Alerts { get; set; } = Array.Empty<string>();

        public override string ToString()
        {
            return $"DateTime: {this.DateTime}, Precipitation: {this.Precipitation}";
        }
    }
}