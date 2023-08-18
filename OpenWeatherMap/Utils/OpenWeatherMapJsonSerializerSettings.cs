using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;
using UnitsNet.Units;

namespace OpenWeatherMap.Utils
{
    internal static class OpenWeatherMapJsonSerializerSettings
    {
        public static JsonSerializerSettings GetJsonSerializerSettings(string unitSystem)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            var temperatureUnit = GetTemperatureUnit(unitSystem);
            jsonSerializerSettings.Converters.Add(new TemperatureJsonConverter(temperatureUnit));

            var speedUnit = GetWindSpeedUnit(unitSystem);
            jsonSerializerSettings.Converters.Add(new WindSpeedJsonConverter(speedUnit));

            return jsonSerializerSettings;
        }

        private static TemperatureUnit GetTemperatureUnit(string unitSystem)
        {
            switch (unitSystem)
            {
                case "imperial":
                    return TemperatureUnit.DegreeFahrenheit;
                case "metric":
                case "standard":
                default:
                    return TemperatureUnit.DegreeCelsius;
            }
        }

        private static SpeedUnit GetWindSpeedUnit(string unitSystem)
        {
            switch (unitSystem)
            {
                case "imperial":
                    return SpeedUnit.MilePerHour;
                case "metric":
                case "standard":
                default:
                    return SpeedUnit.MeterPerSecond;
            }
        }

    }
}
