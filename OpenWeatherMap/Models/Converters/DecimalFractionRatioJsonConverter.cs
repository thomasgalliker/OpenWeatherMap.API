using System;
using Newtonsoft.Json;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    internal class DecimalFractionRatioJsonConverter : JsonConverter<Ratio>
    {
        public override void WriteJson(JsonWriter writer, Ratio value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value / 100d);
        }

        public override Ratio ReadJson(JsonReader reader, Type objectType, Ratio existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is double doubleValue)
            {
                return Ratio.FromPercent(doubleValue * 100d);
            }

            if (reader.Value is long longValue)
            {
                return Ratio.FromPercent(longValue * 100d);
            }

            throw new NotSupportedException($"Cannot convert from {reader.Value} to {nameof(Ratio)}");
        }
    }
}
