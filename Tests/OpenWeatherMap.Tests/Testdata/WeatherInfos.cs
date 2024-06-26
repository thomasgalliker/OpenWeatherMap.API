﻿using System;
using System.Collections.Generic;
using OpenWeatherMap.Models;
using UnitsNet;

namespace OpenWeatherMap.Tests.Testdata
{
    internal static class WeatherInfos
    {

        internal static WeatherInfo GetTestWeatherInfo()
        {
            return GetTestWeatherInfo(Temperature.FromDegreesCelsius(5.5d));
        }

        internal static string GetTestWeatherInfoJson(IOpenWeatherMapJsonSerializer jsonSerializer)
        {
            var weatherInfo = GetTestWeatherInfo();
            var weatherInfoJson = jsonSerializer.SerializeObject(weatherInfo);
            return weatherInfoJson;
        }

        internal static WeatherInfo GetTestWeatherInfo(Temperature mainTemperature)
        {
            return new WeatherInfo
            {
                CityName = "Test Location",
                Date = new DateTime(2000, 1, 1, 12, 13, 14, DateTimeKind.Utc),
                Main = new TemperatureInfo
                {
                    Temperature = mainTemperature,
                    Humidity = RelativeHumidity.FromPercent(35),
                    Pressure = Pressure.FromHectopascals(998),
                    FeelsLike = mainTemperature,
                    MinimumTemperature = new Temperature(mainTemperature.Value - 10, mainTemperature.Unit),
                    MaximumTemperature = new Temperature(mainTemperature.Value + 10, mainTemperature.Unit),
                },
                Weather = new[]
                {
                    new WeatherCondition
                    {
                        Id = WeatherConditionCode.Clear,
                        Description = "Klarer Himmel",
                        IconId = "09d",
                        Main = WeatherConditionGroup.Clear,
                    },
                },
                AdditionalInformation = new AdditionalWeatherInfo
                {
                    Sunrise = new DateTime(2000, 1, 1, 7, 0, 0, DateTimeKind.Utc),
                    Sunset = new DateTime(2000, 1, 1, 20, 0, 0, DateTimeKind.Utc),
                }
            };
        }

    }
}
