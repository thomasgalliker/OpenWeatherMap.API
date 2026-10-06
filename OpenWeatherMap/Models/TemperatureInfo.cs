using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    public class TemperatureInfo
    {
        /// <summary>
        /// Gets the air temperature.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("temp")]
        public Temperature Temperature { get; set; }

        /// <summary>
        /// Gets the human perception of weather.
        /// </summary>
        /// <value>the human perception of weather.</value>
        [JsonRequired]
        [JsonPropertyName("feels_like")]
        public Temperature FeelsLike { get; set; }

        /// <summary>
        /// Gets the air humidity.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("humidity")]
        [JsonConverter(typeof(HumidityJsonConverter))]
        public RelativeHumidity Humidity { get; set; }

        /// <summary>
        /// Gets the maximum temperature.
        /// </summary>
        [JsonPropertyName("temp_max")]
        public Temperature MaximumTemperature { get; set; }

        /// <summary>
        /// Gets the minimum temperature.
        /// </summary>
        [JsonPropertyName("temp_min")]
        public Temperature MinimumTemperature { get; set; }

        /// <summary>
        /// Gets the atmospheric pressure.
        /// </summary>
        [JsonRequired]
        [JsonPropertyName("pressure")]
        [JsonConverter(typeof(PressureJsonConverter))]
        public Pressure Pressure { get; set; }

        /// <summary>
        /// Gets the atmospheric pressure on the ground level (in hPa).
        /// </summary>
        [JsonPropertyName("grnd_level")]
        [JsonConverter(typeof(PressureJsonConverter))]
        public Pressure? GroundLevel { get; set; }

        /// <summary>
        /// Gets the atmospheric pressure on the sea level (in hPa).
        /// </summary>
        [JsonPropertyName("sea_level")]
        [JsonConverter(typeof(PressureJsonConverter))]
        public Pressure? SeaLevel { get; set; }

        public override string ToString()
        {
            return $"Temperature: {this.Temperature}, Humidity: {this.Humidity}";
        }
    }
}
