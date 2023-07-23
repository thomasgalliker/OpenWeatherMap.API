using System;
using Newtonsoft.Json;

namespace OpenWeatherMap.Models.Converters
{
    internal class WindDirectionJsonConverter : JsonConverter<WindDirection>
    {
        public override void WriteJson(JsonWriter writer, WindDirection value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override WindDirection ReadJson(JsonReader reader, Type objectType, WindDirection existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is double windDirection)
            {
                return (WindDirection)windDirection;
            }

            if (reader.Value is long windDirectionLong)
            {
                return (WindDirection)windDirectionLong;
            }

            throw new NotSupportedException($"Cannot convert from {reader.Value} to WindDirection");
        }
    }
}
