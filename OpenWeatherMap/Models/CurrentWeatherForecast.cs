﻿using System;
using Newtonsoft.Json;
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

        [JsonProperty("dt")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime DateTime { get; set; }

        [JsonProperty("sunrise")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Sunrise { get; set; }

        [JsonProperty("sunset")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime Sunset { get; set; }

        [JsonProperty("temp")]
        public Temperature Temperature { get; set; }

        [JsonProperty("feels_like")]
        public Temperature FeelsLike { get; set; }

        /// <summary>
        ///  Atmospheric pressure on the sea level, hPa.
        /// </summary>
        [JsonProperty("pressure")]
        [JsonConverter(typeof(PressureJsonConverter))]
        public Pressure Pressure { get; set; }

        [JsonProperty("humidity")]
        [JsonConverter(typeof(HumidityJsonConverter))]
        public RelativeHumidity Humidity { get; set; }

        [JsonProperty("dew_point")]
        public Temperature DewPoint { get; set; }

        [JsonProperty("uvi")]
        [JsonConverter(typeof(UVIndexJsonConverter))]
        public UVIndex UVIndex { get; set; }

        /// <summary>
        ///  Cloudiness.
        /// </summary>
        [JsonProperty("clouds")]
        [JsonConverter(typeof(PercentRatioJsonConverter))]
        public Ratio Clouds { get; set; }

        /// <summary>
        ///  Average visibility. The maximum value of the visibility is 10km.
        /// </summary>
        [JsonProperty("visibility")]
        [JsonConverter(typeof(MeterLengthJsonConverter))]
        public Length Visibility { get; set; } = Length.FromMeters(0d);

        [JsonProperty("wind_speed")]
        public Speed WindSpeed { get; set; } = Speed.FromMetersPerSecond(0d);

        [JsonProperty("wind_deg")]
        [JsonConverter(typeof(WindDirectionJsonConverter))]
        public Angle WindDirection { get; set; }

        /// <summary>
        /// Wind gust is a brief increase in the speed of the wind, usually less than 20 seconds.
        /// (where available)
        /// (German: Windböe).
        /// </summary>
        [JsonProperty("wind_gust")]
        public Speed? WindGust { get; set; }

        /// <summary>
        /// Precipitation of rain, mm/h (where available).
        /// </summary>
        [JsonProperty("rain")]
        public PrecipitationSpeed Rain { get; set; }

        /// <summary>
        /// Precipitation of snow, mm/h (where available).
        /// </summary>
        [JsonProperty("snow")]
        public PrecipitationSpeed Snow { get; set; }

        [JsonProperty("weather")]
        public WeatherCondition[] Weather { get; set; }

        public override string ToString()
        {
            return $"DateTime: {this.DateTime}, Temperature: {this.Temperature}";
        }
    }
}