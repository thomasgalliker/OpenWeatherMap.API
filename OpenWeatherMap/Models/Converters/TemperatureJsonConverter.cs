using System;
using Newtonsoft.Json;
using UnitsNet;
using UnitsNet.Units;

namespace OpenWeatherMap.Models.Converters
{
    internal class TemperatureJsonConverter : JsonConverter<Temperature>
    {
        private readonly TemperatureUnit temperatureUnit;

        public TemperatureJsonConverter(TemperatureUnit temperatureUnit)
        {
            this.temperatureUnit = temperatureUnit;
        }

        public override void WriteJson(JsonWriter writer, Temperature value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override Temperature ReadJson(JsonReader reader, Type objectType, Temperature existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is double doubleValue)
            {
                return new Temperature(doubleValue, this.temperatureUnit);
            }

            if (reader.Value is long longValue)
            {
                return new Temperature(longValue, this.temperatureUnit);
            }

            return reader.Value is string stringValue && double.TryParse(stringValue, out var value)
                ? new Temperature(value, this.temperatureUnit)
                : default;
        }
    }
}
