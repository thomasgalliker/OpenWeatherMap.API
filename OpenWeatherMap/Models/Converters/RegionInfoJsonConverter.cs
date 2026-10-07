using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models.Converters
{
    internal class RegionInfoJsonConverter : JsonConverter<RegionInfo>
    {
        public override void Write(Utf8JsonWriter writer, RegionInfo value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.TwoLetterISORegionName);
        }

        public override RegionInfo? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var name = reader.GetString();
                return string.IsNullOrEmpty(name) ? null : new RegionInfo(name);
            }

            throw new NotSupportedException($"Cannot convert from {reader.TokenType} to RegionInfo");
        }
    }
}
