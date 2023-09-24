using System;
using System.Collections.Generic;
using System.Globalization;
using OpenWeatherMap.Models;
using UnitsNet;
using UnitsNet.Units;

namespace OpenWeatherMap.Tests.Testdata
{
    internal static class OneCallWeatherInfos
    {
        internal static string GetTestWeatherInfoJson(IOpenWeatherMapJsonSerializer jsonSerializer)
        {
            var weatherInfo = GetTestWeatherInfo();
            var weatherInfoJson = jsonSerializer.SerializeObject(weatherInfo);
            return weatherInfoJson;
        }

        internal static OneCallWeatherInfo GetTestWeatherInfo2()
        {
            return new OneCallWeatherInfo
            {
                Latitude = 47.0907d,
                Longitude = 8.0559d,
                Timezone = "Europe/Zurich",
                TimezoneOffset = 7200,
                CurrentWeather = new CurrentWeatherForecast
                {
                    DateTime = DateTime.ParseExact("2022-06-14T20:05:49.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    Sunrise = DateTime.ParseExact("2022-06-14T03:31:53.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    Sunset = DateTime.ParseExact("2022-06-14T19:24:17.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    Temperature = new Temperature(18.01, TemperatureUnit.DegreeCelsius),
                    FeelsLike = new Temperature(17.54, TemperatureUnit.DegreeCelsius),
                    Pressure = new Pressure(1017, PressureUnit.Hectopascal),
                    Humidity = new RelativeHumidity(64, RelativeHumidityUnit.Percent),
                    DewPoint = new Temperature(11.11, TemperatureUnit.DegreeCelsius),
                    UVIndex = new UVIndex(0),
                    Clouds = new Ratio(73, RatioUnit.Percent),
                    Visibility = new Length(10000, LengthUnit.Meter),
                    WindSpeed = new Speed(0d, SpeedUnit.MeterPerSecond),
                    WindDirection = new Angle(0, AngleUnit.Degree),
                    WindGust = new Speed(0d, SpeedUnit.MeterPerSecond),
                    Weather = new List<WeatherCondition>
                    {
                      new WeatherCondition
                      {
                        Id = 803,
                        Main = WeatherConditionGroup.Clouds,
                        Description = "Überwiegend bewölkt",
                        IconId = "04n"
                      }
                    }
                },
                MinutelyForecasts = new List<MinutelyWeatherForecast>
                  {
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:06:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:07:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:08:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:09:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:10:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:11:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:12:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:13:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:14:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:15:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:16:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:17:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:18:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:19:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:20:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:21:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:22:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:23:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:24:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:25:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:26:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:27:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:28:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:29:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:30:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:31:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:32:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:33:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:34:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:35:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:36:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:37:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:38:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:39:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:40:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:41:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:42:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:43:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:44:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:45:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:46:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:47:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:48:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:49:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:50:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:51:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:52:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:53:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:54:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:55:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:56:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:57:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:58:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:59:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T21:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T21:01:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T21:02:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T21:03:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T21:04:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T21:05:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T21:06:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    }
                  },
                HourlyForecasts = new List<HourlyWeatherForecast>
                  {
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T20:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.01, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(17.54, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(64, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.11, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(73, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.2d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(142, AngleUnit.Degree),
                      WindGust = new Speed(1.33d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Überwiegend bewölkt",
                          IconId = "04n"
                        }
                      },
                      Pop = new Ratio(0.03d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T21:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(17.32, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(16.88, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(68, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.36, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(70, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.29d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(160, AngleUnit.Degree),
                      WindGust = new Speed(1.35d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Überwiegend bewölkt",
                          IconId = "04n"
                        }
                      },
                      Pop = new Ratio(0.03d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T22:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(16.49, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(16.07, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(72, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.43, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(61, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.38d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(167, AngleUnit.Degree),
                      WindGust = new Speed(1.34d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Überwiegend bewölkt",
                          IconId = "04n"
                        }
                      },
                      Pop = new Ratio(0.01d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T23:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(15.6, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(15.17, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(75, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.19, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(50, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.45d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(176, AngleUnit.Degree),
                      WindGust = new Speed(1.34d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Mäßig bewölkt",
                          IconId = "03n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T00:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(14.66, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(14.19, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(77, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(10.68, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(38, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.52d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(198, AngleUnit.Degree),
                      WindGust = new Speed(1.36d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Mäßig bewölkt",
                          IconId = "03n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T01:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(13.71, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(13.23, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1019, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(80, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(9.43, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(17, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.75d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(196, AngleUnit.Degree),
                      WindGust = new Speed(1.58d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Ein paar Wolken",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0.03d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T02:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(13.7, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(13.19, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1019, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(79, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(9.18, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(11, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.9d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(189, AngleUnit.Degree),
                      WindGust = new Speed(1.7d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Ein paar Wolken",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0.01d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T03:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(13.77, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(13.21, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1019, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(77, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(8.99, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(8, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.72d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(179, AngleUnit.Degree),
                      WindGust = new Speed(1.47d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "Klarer Himmel",
                          IconId = "01n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T04:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(13.96, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(13.42, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(77, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(9.14, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(6, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.51d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(190, AngleUnit.Degree),
                      WindGust = new Speed(1.4d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "Klarer Himmel",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T05:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(15.86, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(15.51, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(77, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(10.83, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0.34),
                      Clouds = new Ratio(6, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.27d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(199, AngleUnit.Degree),
                      WindGust = new Speed(1.29d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "Klarer Himmel",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T06:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(19.04, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(18.75, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(67, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.93, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(1.01),
                      Clouds = new Ratio(6, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(0.73d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(216, AngleUnit.Degree),
                      WindGust = new Speed(1.17d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "Klarer Himmel",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T07:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(21.42, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(21.18, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(60, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.48, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(2.18),
                      Clouds = new Ratio(19, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(0.88d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(286, AngleUnit.Degree),
                      WindGust = new Speed(1.46d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Ein paar Wolken",
                          IconId = "02d"
                        }
                      },
                      Pop = new Ratio(0.14d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T08:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(23.33, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(23.13, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(54, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.54, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(3.82),
                      Clouds = new Ratio(26, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(0.98d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(289, AngleUnit.Degree),
                      WindGust = new Speed(3.1d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 500,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Leichter Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(0.3d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T09:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(25.57, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(25.36, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(45, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.1, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(5.63),
                      Clouds = new Ratio(29, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.07d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(299, AngleUnit.Degree),
                      WindGust = new Speed(3.32d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Mäßig bewölkt",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0.27d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T10:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(27.13, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(26.96, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(40, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.68, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.22),
                      Clouds = new Ratio(22, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.6d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(292, AngleUnit.Degree),
                      WindGust = new Speed(4.76d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Ein paar Wolken",
                          IconId = "02d"
                        }
                      },
                      Pop = new Ratio(0.19d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(28.26, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(27.69, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(37, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.53, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(8.11),
                      Clouds = new Ratio(20, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.36d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(284, AngleUnit.Degree),
                      WindGust = new Speed(5.7d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Ein paar Wolken",
                          IconId = "02d"
                        }
                      },
                      Pop = new Ratio(0.15d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T12:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(29, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(28.27, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1016, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(36, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.68, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(8.08),
                      Clouds = new Ratio(25, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(3.2d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(280, AngleUnit.Degree),
                      WindGust = new Speed(6.55d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Mäßig bewölkt",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0.07d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T13:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(29.44, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(28.61, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1016, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(35, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.82, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.08),
                      Clouds = new Ratio(44, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(3.76d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(272, AngleUnit.Degree),
                      WindGust = new Speed(6.65d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Mäßig bewölkt",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0.06d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T14:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(29.64, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(28.72, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1016, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(34, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.63, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(5.49),
                      Clouds = new Ratio(51, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(3.74d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(268, AngleUnit.Degree),
                      WindGust = new Speed(6.72d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Überwiegend bewölkt",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0.06d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T15:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(29.38, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(28.64, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1016, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(36, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.37, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(3.68),
                      Clouds = new Ratio(37, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(3.24d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(285, AngleUnit.Degree),
                      WindGust = new Speed(5.8d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Mäßig bewölkt",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0.08d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T16:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(28.28, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(28.23, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1016, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(44, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.37, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(2.09),
                      Clouds = new Ratio(30, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.98d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(315, AngleUnit.Degree),
                      WindGust = new Speed(4.65d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Mäßig bewölkt",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0.08d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T17:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(26.64, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(26.64, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1016, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(57, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(16.83, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0.94),
                      Clouds = new Ratio(25, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.3d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(342, AngleUnit.Degree),
                      WindGust = new Speed(4.49d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Mäßig bewölkt",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0.12d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T18:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(23.48, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(23.82, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1016, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(74, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(17.73, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0.31),
                      Clouds = new Ratio(28, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.24d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(17, AngleUnit.Degree),
                      WindGust = new Speed(1.6d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 500,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Leichter Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(0.28d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T19:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(20.36, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(20.62, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(83, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(16.48, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(10, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.42d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(176, AngleUnit.Degree),
                      WindGust = new Speed(1.46d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 500,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Leichter Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(0.53d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T20:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.12, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(18.29, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1019, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(88, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(15.35, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(18, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.88d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(194, AngleUnit.Degree),
                      WindGust = new Speed(4.2d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 500,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Leichter Regen",
                          IconId = "10n"
                        }
                      },
                      Pop = new Ratio(0.75d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T21:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(16.64, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(16.76, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1019, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(92, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.54, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(39, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.94d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(201, AngleUnit.Degree),
                      WindGust = new Speed(4.93d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 501,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Mäßiger Regen",
                          IconId = "10n"
                        }
                      },
                      Pop = new Ratio(0.74d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T22:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(14.59, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(14.59, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(95, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.89, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(31, RatioUnit.Percent),
                      Visibility = new Length(7351, LengthUnit.Meter),
                      WindSpeed = new Speed(2.94d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(161, AngleUnit.Degree),
                      WindGust = new Speed(4.55d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 501,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Mäßiger Regen",
                          IconId = "10n"
                        }
                      },
                      Pop = new Ratio(0.9d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T23:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(14, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(13.88, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(93, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.09, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(26, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.7d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(179, AngleUnit.Degree),
                      WindGust = new Speed(2.96d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 500,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Leichter Regen",
                          IconId = "10n"
                        }
                      },
                      Pop = new Ratio(0.96d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T00:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(13.87, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(13.69, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(91, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.63, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(23, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.63d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(197, AngleUnit.Degree),
                      WindGust = new Speed(2.87d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 500,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Leichter Regen",
                          IconId = "10n"
                        }
                      },
                      Pop = new Ratio(0.96d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T01:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(13.99, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(13.79, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(90, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.63, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(9, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.52d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(202, AngleUnit.Degree),
                      WindGust = new Speed(2.25d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "Klarer Himmel",
                          IconId = "01n"
                        }
                      },
                      Pop = new Ratio(0.11d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T02:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(14.15, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(14, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(91, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.91, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(18, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.44d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(201, AngleUnit.Degree),
                      WindGust = new Speed(2.5d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Ein paar Wolken",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0.07d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T03:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(14.29, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(14.15, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(91, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.98, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(14, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.99d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(203, AngleUnit.Degree),
                      WindGust = new Speed(1.89d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Ein paar Wolken",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0.04d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T04:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(14.45, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(14.3, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(90, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.08, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(13, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.8d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(203, AngleUnit.Degree),
                      WindGust = new Speed(1.62d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Ein paar Wolken",
                          IconId = "02d"
                        }
                      },
                      Pop = new Ratio(0.01d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T05:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(16.1, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(16.09, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(89, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.5, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0.34),
                      Clouds = new Ratio(14, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.74d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(213, AngleUnit.Degree),
                      WindGust = new Speed(1.82d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Ein paar Wolken",
                          IconId = "02d"
                        }
                      },
                      Pop = new Ratio(0.08d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T06:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.79, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(18.89, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(83, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.93, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(1.01),
                      Clouds = new Ratio(13, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.2d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(218, AngleUnit.Degree),
                      WindGust = new Speed(2.03d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 500,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Leichter Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(0.36d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T07:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(20.93, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(20.98, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(73, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(15.05, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(2.21),
                      Clouds = new Ratio(2, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.26d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(274, AngleUnit.Degree),
                      WindGust = new Speed(3.46d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "Klarer Himmel",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0.38d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T08:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(21.6, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(21.8, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(76, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(16.42, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(3.87),
                      Clouds = new Ratio(7, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.71d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(286, AngleUnit.Degree),
                      WindGust = new Speed(3.79d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 500,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Leichter Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(0.7d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T09:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(23.13, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(23.3, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(69, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(16.45, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(5.7),
                      Clouds = new Ratio(7, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.76d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(286, AngleUnit.Degree),
                      WindGust = new Speed(4.1d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 500,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Leichter Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(0.74d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T10:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(25.26, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(25.2, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(52, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.95, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(6.88),
                      Clouds = new Ratio(8, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.12d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(286, AngleUnit.Degree),
                      WindGust = new Speed(4.34d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 500,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Leichter Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(0.74d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(26.27, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(26.27, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(46, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.92, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.72),
                      Clouds = new Ratio(24, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.4d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(294, AngleUnit.Degree),
                      WindGust = new Speed(4.9d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Ein paar Wolken",
                          IconId = "02d"
                        }
                      },
                      Pop = new Ratio(0.69d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T12:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(26.88, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(26.92, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(43, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.45, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.7),
                      Clouds = new Ratio(37, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.81d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(302, AngleUnit.Degree),
                      WindGust = new Speed(5.14d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Mäßig bewölkt",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0.64d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T13:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(27.28, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(27.07, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(40, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.05, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(6.96),
                      Clouds = new Ratio(100, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(3.25d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(313, AngleUnit.Degree),
                      WindGust = new Speed(4.88d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 804,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Bedeckt",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0.2d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T14:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(26.53, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(26.53, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(44, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.64, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(5.4),
                      Clouds = new Ratio(97, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(3.58d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(328, AngleUnit.Degree),
                      WindGust = new Speed(4.29d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 804,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Bedeckt",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0.2d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T15:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(24.58, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(24.53, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(55, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.71, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(3.62),
                      Clouds = new Ratio(87, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.98d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(338, AngleUnit.Degree),
                      WindGust = new Speed(3.32d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 804,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Bedeckt",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0.18d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T16:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(25.67, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(25.49, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(46, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.28, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(2.15),
                      Clouds = new Ratio(74, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(2.2d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(340, AngleUnit.Degree),
                      WindGust = new Speed(2.63d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Überwiegend bewölkt",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0.14d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T17:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(24.81, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(24.76, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(54, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.28, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0.97),
                      Clouds = new Ratio(65, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.84d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(338, AngleUnit.Degree),
                      WindGust = new Speed(3.38d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Überwiegend bewölkt",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0.1d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T18:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(22.4, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(22.5, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(69, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(15.58, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0.32),
                      Clouds = new Ratio(62, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(1.29d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(335, AngleUnit.Degree),
                      WindGust = new Speed(1.56d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Überwiegend bewölkt",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0.1d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T19:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(20.11, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(20.06, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1022, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(72, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.21, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0),
                      Clouds = new Ratio(97, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(0.39d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(327, AngleUnit.Degree),
                      WindGust = new Speed(0.66d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 804,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Bedeckt",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0.05d, RatioUnit.Percent)
                    }
                  },
                DailyForecasts = new List<DailyWeatherForecast>
                  {
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-14T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2022-06-14T03:31:53.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2022-06-14T19:24:17.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2022-06-14T20:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2022-06-14T03:02:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.5d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(23.42, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(9.96, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(25.01, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(17.32, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(20.7, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(12.16, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(22.94, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(16.88, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(20.34, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(11.55, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1019, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(43, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(9.49, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.88),
                      Clouds = new Ratio(0, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(2.95d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(48, AngleUnit.Degree),
                      WindGust = new Speed(3.51d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "Klarer Himmel",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0.06d, RatioUnit.Percent),
                      Rain = new Length(0d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-15T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2022-06-15T03:31:48.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2022-06-15T19:24:45.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2022-06-15T21:09:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2022-06-15T03:57:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.54d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(28.26, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(13.7, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(29.64, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(16.64, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(26.64, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(15.86, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(27.69, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(16.76, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(26.64, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(15.51, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1017, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(37, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.53, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(8.11),
                      Clouds = new Ratio(20, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(3.76d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(272, AngleUnit.Degree),
                      WindGust = new Speed(6.72d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 501,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Mäßiger Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(0.75d, RatioUnit.Percent),
                      Rain = new Length(2.77d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-16T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2022-06-16T03:31:46.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2022-06-16T19:25:11.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("1970-01-01T00:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2022-06-16T05:08:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.58d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(26.27, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(13.87, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(27.28, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(17.66, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(24.81, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(16.1, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(26.27, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(17.49, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(24.76, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(16.09, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1020, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(46, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.92, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.72),
                      Clouds = new Ratio(24, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(3.58d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(328, AngleUnit.Degree),
                      WindGust = new Speed(5.14d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 501,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Mäßiger Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(0.96d, RatioUnit.Percent),
                      Rain = new Length(3.39d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-17T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2022-06-17T03:31:47.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2022-06-17T19:25:35.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2022-06-16T22:01:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2022-06-17T06:28:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.62d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(27.47, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(14.53, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(28.3, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(18.61, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(23.73, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(16.47, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(27.17, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(18.43, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(23.91, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(16.31, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1022, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(39, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.72, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(8.52),
                      Clouds = new Ratio(74, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(2.43d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(8, AngleUnit.Degree),
                      WindGust = new Speed(2.34d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "Überwiegend bewölkt",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent),
                      Rain = new Length(0d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-18T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2022-06-18T03:31:50.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2022-06-18T19:25:56.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2022-06-17T22:40:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2022-06-18T07:52:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.65d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(30.82, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(16.34, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(31.58, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(21.31, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(25.86, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(20.74, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(29.84, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(21.3, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(26.17, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(20.57, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1017, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(33, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.28, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(8.56),
                      Clouds = new Ratio(1, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(3.19d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(51, AngleUnit.Degree),
                      WindGust = new Speed(4.24d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "Klarer Himmel",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0.03d, RatioUnit.Percent),
                      Rain = new Length(0d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-19T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2022-06-19T03:31:56.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2022-06-19T19:26:15.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2022-06-18T23:09:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2022-06-19T09:13:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.69d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(31.74, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(17.84, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(31.74, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(17.84, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(20.36, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(21.82, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(31.01, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(17.9, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(20.8, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(21.75, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1010, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(34, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.19, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(8.57),
                      Clouds = new Ratio(0, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(3.47d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(149, AngleUnit.Degree),
                      WindGust = new Speed(7.32d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 500,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Leichter Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(0.85d, RatioUnit.Percent),
                      Rain = new Length(4.93d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-20T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2022-06-20T03:32:03.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2022-06-20T19:26:31.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2022-06-19T23:32:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2022-06-20T10:30:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.72d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(23.92, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(14.68, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(24.37, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(14.68, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(18.14, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(20.58, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(23.88, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(14.76, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(18.52, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(20.5, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1012  , PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(58, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.37, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(9),
                      Clouds = new Ratio(76, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(3.32d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(359, AngleUnit.Degree),
                      WindGust = new Speed(7.06d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 501,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Mäßiger Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(1d, RatioUnit.Percent),
                      Rain = new Length(9.69d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2022-06-21T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2022-06-21T03:32:14.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2022-06-21T19:26:45.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2022-06-20T23:51:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2022-06-21T11:43:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.75d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(7.46, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(7.46, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(14.02, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(8.01, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(12.57, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(10.98, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(5.04, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(6.87, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(11.68, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(10.69, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1015      , PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(96, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(6.06, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(9),
                      Clouds = new Ratio(100, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(3.7d, SpeedUnit.MeterPerSecond),
                      WindDirection = new Angle(211, AngleUnit.Degree),
                      WindGust = new Speed(8.22d, SpeedUnit.MeterPerSecond),
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 502,
                          Main = WeatherConditionGroup.Rain,
                          Description = "Starker Regen",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(1d, RatioUnit.Percent),
                      Rain = new Length(50.16d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    }
                },
                Alerts = new List<AlertInfo>
                {
                }
            };
        }

        internal static OneCallWeatherInfo GetTestWeatherInfo()
        {
            return new OneCallWeatherInfo
            {
                Latitude = 47.0907d,
                Longitude = 8.0559d,
                Timezone = "Europe/Zurich",
                TimezoneOffset = 7200,
                CurrentWeather = new CurrentWeatherForecast
                {
                    DateTime = DateTime.ParseExact("2023-08-18T17:57:03.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    Sunrise = DateTime.ParseExact("2023-08-18T04:28:12.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    Sunset = DateTime.ParseExact("2023-08-18T18:35:34.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                    Temperature = new Temperature(26.98d, TemperatureUnit.DegreeCelsius),
                    FeelsLike = new Temperature(26.85d, TemperatureUnit.DegreeCelsius),
                    Pressure = new Pressure(1015d, PressureUnit.Hectopascal),
                    Humidity = new RelativeHumidity(40d, RelativeHumidityUnit.Percent),
                    DewPoint = new Temperature(12.24d, TemperatureUnit.DegreeCelsius),
                    UVIndex = new UVIndex(0d),
                    Clouds = new Ratio(30, RatioUnit.Percent),
                    Visibility = new Length(10000, LengthUnit.Meter),
                    WindSpeed = new Speed(),
                    WindDirection = new Angle(),
                    WindGust = null,
                    Weather = new List<WeatherCondition>
                    {
                      new WeatherCondition
                      {
                        Id = 802,
                        Main = WeatherConditionGroup.Clouds,
                        Description = "scattered clouds",
                        IconId = "03d"
                      }
                    }
                },
                MinutelyForecasts = new List<MinutelyWeatherForecast>
                  {
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T17:58:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T17:59:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:01:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:02:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:03:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:04:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:05:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:06:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:07:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:08:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:09:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:10:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:11:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:12:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:13:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:14:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:15:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:16:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:17:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:18:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:19:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:20:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:21:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:22:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:23:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:24:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:25:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:26:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:27:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:28:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:29:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:30:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:31:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:32:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:33:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:34:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:35:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:36:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:37:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:38:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:39:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:40:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:41:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:42:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:43:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:44:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:45:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:46:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:47:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:48:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:49:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:50:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:51:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:52:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:53:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:54:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:55:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:56:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:57:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    },
                    new MinutelyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:58:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Precipitation = new Speed(0d, SpeedUnit.MillimeterPerHour)
                    }
                  },
                HourlyForecasts = new List<HourlyWeatherForecast>
                  {
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T17:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(26.9d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(26.99d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1015d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(44d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.63d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0.44d),
                      Clouds = new Ratio(28, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T18:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(26.98d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(26.85d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1015d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(40d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.24d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(30, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T19:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(25.91d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(25.71d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1015d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(44d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.73d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(31, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03n"
                        }
                      },
                      Pop = new Ratio(3d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T20:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(24.51d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(24.3d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1015d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(49d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.1d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(26, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T21:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(22.91d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(22.67d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1016d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(54d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.12d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(22, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "few clouds",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T22:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(21.13d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(20.87d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(60d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.07d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(17, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "few clouds",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T23:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(19.28d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(18.93d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(64d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.57d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(22, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "few clouds",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T00:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.96d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(18.58d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(64d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.27d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(25, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T01:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.7d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(18.3d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(64d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.01d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(5, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T02:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.6d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(18.19d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(64d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(10.7d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(46, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T03:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.44d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(17.98d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(63d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(10.46d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(54, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "broken clouds",
                          IconId = "04n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T04:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.2d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(17.72d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1017d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(63d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(10.2d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(44, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T05:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.02d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(17.57d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(65d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(10.62d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(39, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T06:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(19.97d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(19.77d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(67d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.76d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0.49d),
                      Clouds = new Ratio(41, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T07:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(23.1d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(22.95d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(57d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.38d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(1.35d),
                      Clouds = new Ratio(83, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "broken clouds",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T08:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(25.36d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(25.26d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(50d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.58d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(2.79d),
                      Clouds = new Ratio(91, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 804,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "overcast clouds",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T09:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(27.67d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(27.64d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(44d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.69d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(4.53d),
                      Clouds = new Ratio(92, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 804,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "overcast clouds",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T10:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(29.52d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(28.96d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(38d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.23d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(6.26d),
                      Clouds = new Ratio(82, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "broken clouds",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(30.66d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(29.87d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(35d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.84d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.2d),
                      Clouds = new Ratio(83, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "broken clouds",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T12:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(31.58d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(30.57d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(32d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.44d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.16d),
                      Clouds = new Ratio(78, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "broken clouds",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T13:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(32d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(30.93d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(31d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.1d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(6.19d),
                      Clouds = new Ratio(75, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "broken clouds",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T14:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(31.96d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(30.89d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(31d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.9d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(4.56d),
                      Clouds = new Ratio(49, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T15:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(31.52d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(30.5d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(32d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.05d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(2.78d),
                      Clouds = new Ratio(46, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T16:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(30.66d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(30.62d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(41d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(15.08d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(1.29d),
                      Clouds = new Ratio(42, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T17:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(27.8d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(28.67d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(55d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(17.11d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0.43d),
                      Clouds = new Ratio(47, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T18:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(24.22d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(24.29d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1019d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(61d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(15.51d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(42, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T19:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(22.62d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(22.5d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(60d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.62d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(10, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T20:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(21.82d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(21.62d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(60d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.02d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(14, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "few clouds",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T21:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(21.26d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(21.03d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(61d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.77d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(12, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "few clouds",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T22:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(20.69d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(20.46d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(63d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.6d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(11, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "few clouds",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T23:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(20.23d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(19.98d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(64d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.47d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(11, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "few clouds",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T00:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(19.76d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(19.51d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(66d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.4d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(11, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "few clouds",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T01:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(19.29d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(19.02d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(67d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.26d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(7, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T02:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.89d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(18.61d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(68d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.1d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(7, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T03:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.59d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(18.31d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(69d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.87d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(12, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "few clouds",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T04:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.45d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(18.13d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(68d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.6d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(20, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 801,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "few clouds",
                          IconId = "02n"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T05:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(18.55d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(18.26d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1022d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(69d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(11.89d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0d),
                      Clouds = new Ratio(25, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T06:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(20.35d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(20.24d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1022d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(69d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(13.65d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(0.46d),
                      Clouds = new Ratio(29, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T07:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(23.39d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(23.33d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1022d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(59d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.19d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(1.36d),
                      Clouds = new Ratio(6, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T08:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(25.71d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(25.72d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1022d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(53d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.59d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(2.82d),
                      Clouds = new Ratio(6, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T09:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(27.55d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(27.81d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(48d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.96d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(4.58d),
                      Clouds = new Ratio(5, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T10:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(29.05d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(29.05d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(44d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(15d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(6.18d),
                      Clouds = new Ratio(3, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(30.22d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(30.07d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(41d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.84d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.11d),
                      Clouds = new Ratio(3, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T12:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(31.08d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(30.73d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(38d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.53d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.08d),
                      Clouds = new Ratio(2, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T13:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(31.58d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(31.08d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(36d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.23d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(6.04d),
                      Clouds = new Ratio(0, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T14:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(31.69d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(31.22d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(36d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.01d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(4.43d),
                      Clouds = new Ratio(0, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T15:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(31.37d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(30.82d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(36d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.05d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(2.7d),
                      Clouds = new Ratio(0, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    },
                    new HourlyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T16:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Temperature = new Temperature(30.6d, TemperatureUnit.DegreeCelsius),
                      FeelsLike = new Temperature(30.82d, TemperatureUnit.DegreeCelsius),
                      Pressure = new Pressure(1020d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(43d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(15.83d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(1.28d),
                      Clouds = new Ratio(0, RatioUnit.Percent),
                      Visibility = new Length(10000, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent)
                    }
                  },
                DailyForecasts = new List<DailyWeatherForecast>
                  {
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-18T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2023-08-18T04:28:12.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2023-08-18T18:35:34.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2023-08-18T06:15:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2023-08-18T19:40:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.06d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(29.51d, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(16.29d, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(30.68d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(22.91d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(26.9d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(16.39d, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(28.76d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(22.67d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(26.99d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(15.78d, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1016d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(36d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.19d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(6.93d),
                      Clouds = new Ratio(2, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(4d, RatioUnit.Percent),
                      Rain = new Length(0d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-19T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2023-08-19T04:29:31.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2023-08-19T18:33:49.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2023-08-19T07:21:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2023-08-19T19:54:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.09d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(30.66d, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(18.02d, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(32d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(21.26d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(27.8d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(18.02d, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(29.87d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(21.03d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(28.67d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(17.57d, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1018d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(35d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(12.84d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.2d),
                      Clouds = new Ratio(83, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 803,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "broken clouds",
                          IconId = "04d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent),
                      Rain = new Length(0d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-20T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2023-08-20T04:30:50.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2023-08-20T18:32:03.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2023-08-20T08:26:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2023-08-20T20:08:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.12d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(30.22d, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(18.45d, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(31.69d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(21.6d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(28.28d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(18.55d, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(30.07d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(21.57d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(29.52d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(18.26d, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(41d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(14.84d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7.11d),
                      Clouds = new Ratio(3, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(0d, RatioUnit.Percent),
                      Rain = new Length(0d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-21T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2023-08-21T04:32:09.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2023-08-21T18:30:17.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2023-08-21T09:34:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2023-08-21T20:24:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.15d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(31.63d, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(19.11d, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(32.63d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(22.84d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(25.6d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(19.11d, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(31.44d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(22.88d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(25.83d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(18.93d, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1021d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(38d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(15.15d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(6.93d),
                      Clouds = new Ratio(0, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 800,
                          Main = WeatherConditionGroup.Clear,
                          Description = "clear sky",
                          IconId = "01d"
                        }
                      },
                      Pop = new Ratio(1d, RatioUnit.Percent),
                      Rain = new Length(0d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-22T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2023-08-22T04:33:28.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2023-08-22T18:28:29.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2023-08-22T10:43:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2023-08-22T20:42:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.19d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(32.73d, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(20.79d, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(32.87d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(22.72d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(26.12d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(21.96d, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(32.97d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(22.9d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(26.12d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(21.96d, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1017d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(38d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(16.03d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(6.96d),
                      Clouds = new Ratio(39, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 802,
                          Main = WeatherConditionGroup.Clouds,
                          Description = "scattered clouds",
                          IconId = "03d"
                        }
                      },
                      Pop = new Ratio(25d, RatioUnit.Percent),
                      Rain = new Length(0d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-23T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2023-08-23T04:34:47.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2023-08-23T18:26:40.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2023-08-23T11:56:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2023-08-23T21:05:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.22d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(33.06d, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(18.24d, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(33.19d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(18.24d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(18.71d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(21.89d, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(33.66d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(18.55d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(19.09d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(21.99d, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1014d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(39d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(16.61d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(6.87d),
                      Clouds = new Ratio(14, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 502,
                          Main = WeatherConditionGroup.Rain,
                          Description = "heavy intensity rain",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(91d, RatioUnit.Percent),
                      Rain = new Length(16.03d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-24T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2023-08-24T04:36:06.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2023-08-24T18:24:50.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2023-08-24T13:12:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("2023-08-24T21:36:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.25d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(29.53d, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(18.07d, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(29.8d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(19.01d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(23.09d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(19.06d, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(30.66d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(19.39d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(23.57d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(19.37d, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1014d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(52d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(17.93d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7d),
                      Clouds = new Ratio(31, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 501,
                          Main = WeatherConditionGroup.Rain,
                          Description = "moderate rain",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(99d, RatioUnit.Percent),
                      Rain = new Length(6.89d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    },
                    new DailyWeatherForecast
                    {
                      DateTime = DateTime.ParseExact("2023-08-25T11:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunrise = DateTime.ParseExact("2023-08-25T04:37:25.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Sunset = DateTime.ParseExact("2023-08-25T18:23:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonrise = DateTime.ParseExact("2023-08-25T14:27:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Moonset = DateTime.ParseExact("1970-01-01T00:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      MoonPhase = new Ratio(0.29d, RatioUnit.Percent),
                      Temperature = new DailyTemperatureForecast
                      {
                        Day = new Temperature(24.68d, TemperatureUnit.DegreeCelsius),
                        Min = new Temperature(17.92d, TemperatureUnit.DegreeCelsius),
                        Max = new Temperature(25.12d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(17.92d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(18.92d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(18.87d, TemperatureUnit.DegreeCelsius)
                      },
                      FeelsLike = new DailyFeelsLikeForecast
                      {
                        Day = new Temperature(25.06d, TemperatureUnit.DegreeCelsius),
                        Night = new Temperature(18.33d, TemperatureUnit.DegreeCelsius),
                        Evening = new Temperature(19.35d, TemperatureUnit.DegreeCelsius),
                        Morning = new Temperature(19.27d, TemperatureUnit.DegreeCelsius)
                      },
                      Pressure = new Pressure(1010d, PressureUnit.Hectopascal),
                      Humidity = new RelativeHumidity(71d, RelativeHumidityUnit.Percent),
                      DewPoint = new Temperature(18.02d, TemperatureUnit.DegreeCelsius),
                      UVIndex = new UVIndex(7d),
                      Clouds = new Ratio(100, RatioUnit.Percent),
                      Visibility = new Length(0, LengthUnit.Meter),
                      WindSpeed = new Speed(),
                      WindDirection = new Angle(),
                      WindGust = null,
                      Weather = new List<WeatherCondition>
                      {
                        new WeatherCondition
                        {
                          Id = 501,
                          Main = WeatherConditionGroup.Rain,
                          Description = "moderate rain",
                          IconId = "10d"
                        }
                      },
                      Pop = new Ratio(100d, RatioUnit.Percent),
                      Rain = new Length(19.6d, LengthUnit.Millimeter),
                      Snow = new Length(0d, LengthUnit.Millimeter)
                    }
                  },
                Alerts = new List<AlertInfo>
                  {
                    new AlertInfo
                    {
                      SenderName = "MeteoSwiss",
                      EventName = "Orange High-Temperature Warning",
                      StartTime = DateTime.ParseExact("2023-08-19T10:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      EndTime = DateTime.ParseExact("2023-08-24T18:00:00.0000000Z", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                      Description = "- Warning valid below 800 m a.s.l\n- Possible impacts: Significant risk of circulatory problems\n- Recommendations for action: Drink (preferably unsweetened) liquids regularly and in sufficient quantities (at least 1.5 litres a day). Contact those around you who fall into the risk category and ensure that they are well and able to follow the existing recommendations. Do not leave people or animals unattended in cars\n- Highest temperatures and humidity: 31 - 35 °C, 30 - 40 %\n- Lowest night temperatures: 18 - 22 °C\n- Peak phase of the event: -\n- Temporary mitigation: -",
                      Tags = new List<string>
                      {
                        "Extreme temperature value"
                      }
                    }
                  }
            };
        }
    }
}
