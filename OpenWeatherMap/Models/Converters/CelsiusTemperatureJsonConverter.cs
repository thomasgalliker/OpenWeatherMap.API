using System;
using Newtonsoft.Json;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    internal class CelsiusTemperatureJsonConverter : JsonConverter<Temperature>
    {
        public override void WriteJson(JsonWriter writer, Temperature value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override Temperature ReadJson(JsonReader reader, Type objectType, Temperature existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is double doubleValue)
            {
                return Temperature.FromDegreesCelsius(doubleValue);
            }

            if (reader.Value is long longValue)
            {
                return Temperature.FromDegreesCelsius(longValue);
            }

            return reader.Value is string stringValue && double.TryParse(stringValue, out var value)
                ? Temperature.FromDegreesCelsius(value)
                : default;
        }
    }
}
