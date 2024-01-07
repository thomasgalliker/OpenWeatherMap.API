using Newtonsoft.Json;
using OpenWeatherMap.Models;
using OpenWeatherMap.Models.Converters;
using UnitsNet.Units;

namespace OpenWeatherMap
{
    public class OpenWeatherMapJsonSerializer : IOpenWeatherMapJsonSerializer
    {
        private JsonSerializerSettings serializerSettings;

        public OpenWeatherMapJsonSerializer(UnitSystem unitSystem)
        {
            this.serializerSettings = GetJsonSerializerSettings(unitSystem);
        }

        public static JsonSerializerSettings GetJsonSerializerSettings(UnitSystem unitSystem)
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

        private static TemperatureUnit GetTemperatureUnit(UnitSystem unitSystem)
        {
            switch (unitSystem)
            {
                case UnitSystem.Imperial:
                    return TemperatureUnit.DegreeFahrenheit;
                case UnitSystem.Metric:
                case UnitSystem.Standard:
                default:
                    return TemperatureUnit.DegreeCelsius;
            }
        }

        private static SpeedUnit GetWindSpeedUnit(UnitSystem unitSystem)
        {
            switch (unitSystem)
            {
                case UnitSystem.Imperial:
                    return SpeedUnit.MilePerHour;
                case UnitSystem.Metric:
                case UnitSystem.Standard:
                default:
                    return SpeedUnit.MeterPerSecond;
            }
        }

        public T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, this.serializerSettings);
        }

        public string SerializeObject<T>(T value)
        {
            return JsonConvert.SerializeObject(value, this.serializerSettings);
        }
    }
}
