using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    public class WeatherInfo
    {
        public WeatherInfo()
        {
            this.Weather = Array.Empty<WeatherCondition>();
        }

        [JsonPropertyName("dt")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Date { get; set; }

        [JsonPropertyName("weather")]
        public WeatherCondition[] Weather { get; set; }

        [JsonPropertyName("main")]
        public TemperatureInfo Main { get; set; }

        /// <summary>
        ///  Average visibility. The maximum value of the visibility is 10km.
        /// </summary>
        [JsonPropertyName("visibility")]
        [JsonConverter(typeof(MeterLengthJsonConverter))]
        public Length Visibility { get; set; } = Length.FromMeters(0d);

        [JsonPropertyName("wind")]
        public WindInfo Wind { get; set; }

        [JsonPropertyName("clouds")]
        public CloudsInformation Clouds { get; set; }

        [JsonPropertyName("sys")]
        public AdditionalWeatherInfo AdditionalInformation { get; set; }

        /// <summary>
        /// Shift in seconds from UTC.
        /// </summary>
        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        /// <summary>
        /// City ID.
        /// </summary>
        [JsonPropertyName("id")]
        public string CityId { get; set; }

        /// <summary>
        /// City name.
        /// </summary>
        [JsonPropertyName("name")]
        public string CityName { get; set; }

        /// <summary>
        /// City geo location.
        /// </summary>
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }
    }
}