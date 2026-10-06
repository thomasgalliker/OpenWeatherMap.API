using System;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    public class CurrentWeatherForecast
    {
        public CurrentWeatherForecast()
        {
            this.Weather = Array.Empty<WeatherCondition>();
        }

        [JsonPropertyName("dt")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Sunset { get; set; }

        [JsonPropertyName("temp")]
        public Temperature Temperature { get; set; }

        [JsonPropertyName("feels_like")]
        public Temperature FeelsLike { get; set; }

        /// <summary>
        ///  Atmospheric pressure on the sea level, hPa.
        /// </summary>
        [JsonPropertyName("pressure")]
        [JsonConverter(typeof(PressureJsonConverter))]
        public Pressure Pressure { get; set; }

        [JsonPropertyName("humidity")]
        [JsonConverter(typeof(HumidityJsonConverter))]
        public RelativeHumidity Humidity { get; set; }

        [JsonPropertyName("dew_point")]
        public Temperature DewPoint { get; set; }

        [JsonPropertyName("uvi")]
        [JsonConverter(typeof(UVIndexJsonConverter))]
        public UVIndex UVIndex { get; set; }

        /// <summary>
        ///  Cloudiness.
        /// </summary>
        [JsonPropertyName("clouds")]
        [JsonConverter(typeof(PercentRatioJsonConverter))]
        public Ratio Clouds { get; set; }

        /// <summary>
        ///  Average visibility. The maximum value of the visibility is 10km.
        /// </summary>
        [JsonPropertyName("visibility")]
        [JsonConverter(typeof(MeterLengthJsonConverter))]
        public Length Visibility { get; set; } = Length.FromMeters(0d);

        [JsonPropertyName("wind_speed")]
        public Speed WindSpeed { get; set; } = Speed.FromMetersPerSecond(0d);

        [JsonPropertyName("wind_deg")]
        [JsonConverter(typeof(WindDirectionJsonConverter))]
        public Angle WindDirection { get; set; }

        /// <summary>
        /// Wind gust is a brief increase in the speed of the wind, usually less than 20 seconds.
        /// (where available)
        /// (German: Windböe).
        /// </summary>
        [JsonPropertyName("wind_gust")]
        public Speed? WindGust { get; set; }

        /// <summary>
        /// Precipitation of rain, mm/h (where available).
        /// </summary>
        [JsonPropertyName("rain")]
        public PrecipitationSpeed Rain { get; set; } = null!;

        /// <summary>
        /// Precipitation of snow, mm/h (where available).
        /// </summary>
        [JsonPropertyName("snow")]
        public PrecipitationSpeed Snow { get; set; } = null!;

        [JsonPropertyName("weather")]
        public WeatherCondition[] Weather { get; set; }

        public override string ToString()
        {
            return $"DateTime: {this.DateTime}, Temperature: {this.Temperature}";
        }
    }
}