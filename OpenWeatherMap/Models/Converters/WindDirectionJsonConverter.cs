using System;
using Newtonsoft.Json;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    internal class WindDirectionJsonConverter : JsonConverter<Angle>
    {
        public override void WriteJson(JsonWriter writer, Angle value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override Angle ReadJson(JsonReader reader, Type objectType, Angle existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is double doubleValue)
            {
                return Angle.FromDegrees(doubleValue);
            }

            if (reader.Value is long longValue)
            {
                return Angle.FromDegrees(longValue);
            }

            throw new NotSupportedException($"Cannot convert from {reader.Value} to {nameof(Angle)}");
        }
    }
}
