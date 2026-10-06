using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    internal class DecimalFractionRatioJsonConverter : JsonConverter<Ratio>
    {
        public override void Write(Utf8JsonWriter writer, Ratio value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value / 100d);
        }

        public override Ratio Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Ratio.FromPercent(reader.ReadDouble() * 100d);
        }
    }
}
