using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models.Converters
{
    internal class UVIndexJsonConverter : JsonConverter<UVIndex>
    {
        public override void Write(Utf8JsonWriter writer, UVIndex value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override UVIndex Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return (UVIndex)reader.ReadDouble();
        }
    }
}
