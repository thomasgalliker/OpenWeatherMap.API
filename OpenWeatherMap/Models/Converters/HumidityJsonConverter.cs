using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    internal class HumidityJsonConverter : JsonConverter<RelativeHumidity>
    {
        public override void Write(Utf8JsonWriter writer, RelativeHumidity value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override RelativeHumidity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return RelativeHumidity.FromPercent(reader.ReadDouble());
        }
    }
}
