using System.Text.Json;
using System.Text.Json.Serialization;
using OpenWeatherMap.Models.Converters;
using UnitsNet.Units;

namespace OpenWeatherMap
{
    public class OpenWeatherMapJsonSerializer : IOpenWeatherMapJsonSerializer
    {
        private readonly JsonSerializerOptions serializerOptions;

        public OpenWeatherMapJsonSerializer(UnitSystem unitSystem)
        {
            this.serializerOptions = GetJsonSerializerOptions(unitSystem);
        }

        public static JsonSerializerOptions GetJsonSerializerOptions(UnitSystem unitSystem)
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            var temperatureUnit = GetTemperatureUnit(unitSystem);
            jsonSerializerOptions.Converters.Add(new TemperatureJsonConverter(temperatureUnit));

            var speedUnit = GetWindSpeedUnit(unitSystem);
            jsonSerializerOptions.Converters.Add(new WindSpeedJsonConverter(speedUnit));

            return jsonSerializerOptions;
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
            return JsonSerializer.Deserialize<T>(value, this.serializerOptions)!;
        }

        public string SerializeObject<T>(T value)
        {
            return JsonSerializer.Serialize(value, this.serializerOptions);
        }
    }
}
