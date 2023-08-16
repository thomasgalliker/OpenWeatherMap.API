using System;
using Newtonsoft.Json;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    internal class HumidityJsonConverter : JsonConverter<RelativeHumidity>
    {
        public override void WriteJson(JsonWriter writer, RelativeHumidity value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override RelativeHumidity ReadJson(JsonReader reader, Type objectType, RelativeHumidity existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is long humidity)
            {
                return RelativeHumidity.FromPercent(humidity);
            }

            throw new NotSupportedException($"Cannot convert from {reader.Value} to {nameof(RelativeHumidity)}");
        }
    }
}
