using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models.Converters
{
    internal class WeatherConditionCodeJsonConverter : JsonConverter<WeatherConditionCode>
    {
        public override void Write(Utf8JsonWriter writer, WeatherConditionCode value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override WeatherConditionCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return WeatherConditionCode.FromValue((int)reader.ReadInt64());
        }
    }
}
