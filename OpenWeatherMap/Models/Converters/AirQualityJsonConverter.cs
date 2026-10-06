using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models.Converters
{
    internal class AirQualityJsonConverter : JsonConverter<AirQuality>
    {
        public override void Write(Utf8JsonWriter writer, AirQuality value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override AirQuality Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out var value))
            {
                return AirQuality.FromValue(value);
            }

            throw new NotSupportedException($"Cannot convert from {reader.TokenType} to AirQuality");
        }
    }
}
