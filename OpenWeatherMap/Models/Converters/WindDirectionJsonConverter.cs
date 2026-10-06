using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    internal class WindDirectionJsonConverter : JsonConverter<Angle>
    {
        public override void Write(Utf8JsonWriter writer, Angle value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override Angle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Angle.FromDegrees(reader.ReadDouble());
        }
    }
}
