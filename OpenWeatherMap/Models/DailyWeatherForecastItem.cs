using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    [DebuggerDisplay("WeatherForecastItem: {DateTime}, {Temperature}")]
    public class DailyWeatherForecastItem
    {
        private WindInfo? wind;

        public DailyWeatherForecastItem()
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
        public DailyTemperatureForecast Temperature { get; set; } = null!;

        [JsonPropertyName("feels_like")]
        public DailyFeelsLikeForecast FeelsLike { get; set; } = null!;

        /// <summary>
        ///  Atmospheric pressure on the sea level, hPa.
        /// </summary>
        [JsonPropertyName("pressure")]
        [JsonConverter(typeof(PressureJsonConverter))]
        public Pressure Pressure { get; set; }

        [JsonPropertyName("humidity")]
        [JsonConverter(typeof(HumidityJsonConverter))]
        public RelativeHumidity Humidity { get; set; }

        [JsonPropertyName("weather")]
        public WeatherCondition[] Weather { get; set; }

        /// <see cref="Wind">
        [JsonPropertyName("speed")]
        private Speed Speed { get; set; } = Speed.FromMetersPerSecond(0d);

        /// <see cref="Wind">
        [JsonPropertyName("deg")]
        [JsonConverter(typeof(WindDirectionJsonConverter))]
        private Angle Direction { get; set; }

        /// <see cref="Wind">
        [JsonPropertyName("gust")]
        private Speed? Gust { get; set; }

        /// <summary>
        /// Wind info.
        /// </summary>
        [JsonIgnore]
        public WindInfo Wind
        {
            get
            {
                return this.wind ??= new WindInfo
                {
                    Speed = this.Speed,
                    Direction = this.Direction,
                    Gust = this.Gust
                };
            }
        }

        /// <summary>
        ///  Cloudiness.
        /// </summary>
        [JsonPropertyName("clouds")]
        [JsonConverter(typeof(PercentRatioJsonConverter))]
        public Ratio Clouds { get; set; }

        /// <summary>
        /// Probability of precipitation.
        /// The values of the parameter vary between 0 and 1, where 0 is equal to 0%, 1 is equal to 100%.
        /// </summary>
        [JsonPropertyName("pop")]
        [JsonConverter(typeof(DecimalFractionRatioJsonConverter))]
        public Ratio Pop { get; set; } = Ratio.FromPercent(0d);

        /// <summary>
        /// Daily volume of rain, in mm (where available).
        /// </summary>
        [JsonPropertyName("rain")]
        [JsonConverter(typeof(MillimeterLengthJsonConverter))]
        public Length Rain { get; set; } = Length.FromMillimeters(0d);
    }
}
