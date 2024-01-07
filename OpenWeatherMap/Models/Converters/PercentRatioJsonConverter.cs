using System;
using Newtonsoft.Json;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    internal class PercentRatioJsonConverter : JsonConverter<Ratio>
    {
        public override void WriteJson(JsonWriter writer, Ratio value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override Ratio ReadJson(JsonReader reader, Type objectType, Ratio existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is double doubleValue)
            {
                return Ratio.FromPercent(doubleValue);
            }

            if (reader.Value is long longValue)
            {
                return Ratio.FromPercent(longValue);
            }
            
            if (reader.Value is null)
            {
                return Ratio.Zero;
            }

            throw new NotSupportedException($"Cannot convert from {reader.Value} to {nameof(Ratio)}");
        }
    }
}
