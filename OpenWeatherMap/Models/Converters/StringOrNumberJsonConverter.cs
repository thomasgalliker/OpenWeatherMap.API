using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models.Converters
{
    internal class StringOrNumberJsonConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    return reader.GetString();
                case JsonTokenType.Number:
                    if (reader.TryGetInt64(out var longValue))
                    {
                        return longValue.ToString(CultureInfo.InvariantCulture);
                    }

                    if (reader.TryGetDouble(out var doubleValue))
                    {
                        return doubleValue.ToString(CultureInfo.InvariantCulture);
                    }

                    break;
                case JsonTokenType.Null:
                    return null;
            }

            throw new JsonException($"Cannot convert token type {reader.TokenType} to string.");
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
