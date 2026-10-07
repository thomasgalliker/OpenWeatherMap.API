using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Weather record of the 1 day step timeline of One Call API 4.0.
    /// </summary>
    public class DailyWeatherForecast
    {
        public DailyWeatherForecast()
        {
            this.Weather = Array.Empty<WeatherCondition>();
        }

        [JsonPropertyName("dt")]
        [JsonConverter(typeof(EpochDateTimeConverter))]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Sunrise time (UTC). <c>null</c> in polar areas during midnight sun and polar night.
        /// </summary>
        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(NullableEpochDateTimeConverter))]
        public DateTime? Sunrise { get; set; }

        /// <summary>
        /// Sunset time (UTC). <c>null</c> in polar areas during midnight sun and polar night.
        /// </summary>
        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(NullableEpochDateTimeConverter))]
        public DateTime? Sunset { get; set; }

        /// <summary>
        /// Moonrise time (UTC). <c>null</c> if the moon does not rise on this day.
        /// </summary>
        [JsonPropertyName("moonrise")]
        [JsonConverter(typeof(NullableEpochDateTimeConverter))]
        public DateTime? Moonrise { get; set; }

        /// <summary>
        /// Moonset time (UTC). <c>null</c> if the moon does not set on this day.
        /// </summary>
        [JsonPropertyName("moonset")]
        [JsonConverter(typeof(NullableEpochDateTimeConverter))]
        public DateTime? Moonset { get; set; }

        /// <summary>
        /// Moon phase (0-100%). 0 and 100% are 'new moon', 25% is 'first quarter moon', 50% is 'full moon' and 75% is 'last quarter moon'.
        /// The periods in between are called 'waxing crescent', 'waxing gibous', 'waning gibous', and 'waning crescent', respectively.
        /// </summary>
        [JsonPropertyName("moon_phase")]
        [JsonConverter(typeof(DecimalFractionRatioJsonConverter))]
        public Ratio MoonPhase { get; set; } = Ratio.FromPercent(0d);

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

        [JsonPropertyName("dew_point")]
        public Temperature DewPoint { get; set; }

        /// <summary>
        /// The maximum value of UV index for the day.
        /// </summary>
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
        public Length? Visibility { get; set; }

        [JsonPropertyName("wind_speed")]
        public Speed WindSpeed { get; set; } = Speed.FromMetersPerSecond(0d);

        [JsonPropertyName("wind_deg")]
        [JsonConverter(typeof(WindDirectionJsonConverter))]
        public Angle WindDirection { get; set; }

        /// <summary>
        /// Wind gust is a brief increase in the speed of the wind, usually less than 20 seconds. (German: Windböe).
        /// </summary>
        [JsonPropertyName("wind_gust")]
        public Speed? WindGust { get; set; }

        [JsonPropertyName("weather")]
        public WeatherCondition[] Weather { get; set; }

        /// <summary>
        /// Probability of precipitation.
        /// The values of the parameter vary between 0 and 1, where 0 is equal to 0%, 1 is equal to 100%.
        /// </summary>
        [JsonPropertyName("pop")]
        [JsonConverter(typeof(DecimalFractionRatioJsonConverter))]
        public Ratio Pop { get; set; } = Ratio.FromPercent(0d);

        /// <summary>
        /// Daily volume of rain, in mm.
        /// </summary>
        [JsonPropertyName("rain")]
        [JsonConverter(typeof(PrecipitationVolumeJsonConverter))]
        public Length Rain { get; set; } = Length.FromMillimeters(0d);

        /// <summary>
        /// Daily volume of snow, in mm.
        /// </summary>
        [JsonPropertyName("snow")]
        [JsonConverter(typeof(PrecipitationVolumeJsonConverter))]
        public Length Snow { get; set; } = Length.FromMillimeters(0d);


        /// <summary>
        /// IDs of the weather alerts associated with the location and time.
        /// Use <see cref="IOpenWeatherMapService.GetWeatherOneCallAlertAsync"/> to get the details of an alert.
        /// </summary>
        [JsonPropertyName("alerts")]
        public IReadOnlyCollection<string> Alerts { get; set; } = Array.Empty<string>();

        public override string ToString()
        {
            return $"DateTime: {this.DateTime}, Temperature: {this.Temperature.Min}/{this.Temperature.Max}";
        }
    }
}
