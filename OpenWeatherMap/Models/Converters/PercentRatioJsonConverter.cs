using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    internal class PercentRatioJsonConverter : JsonConverter<Ratio>
    {
        public override void Write(Utf8JsonWriter writer, Ratio value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override Ratio Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return Ratio.Zero;
            }

            return Ratio.FromPercent(reader.ReadDouble());
        }
    }
}
