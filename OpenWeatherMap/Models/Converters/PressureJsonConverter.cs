using System;
using Newtonsoft.Json;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    internal class PressureJsonConverter : JsonConverter<Pressure>
    {
        public override void WriteJson(JsonWriter writer, Pressure value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override Pressure ReadJson(JsonReader reader, Type objectType, Pressure existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is long longValue)
            {
                return Pressure.FromHectopascals(longValue);
            }

            if (reader.Value is double doubleValue)
            {
                return Pressure.FromHectopascals(doubleValue);
            }

            return reader.Value is string stringValue && double.TryParse(stringValue, out var value)
                ? Pressure.FromHectopascals(value)
                : default;
        }
    }
}
