using System;
using System.Globalization;
using System.Text.Json;

namespace OpenWeatherMap.Models.Converters
{
    internal static class JsonReaderExtensions
    {
        public static double ReadDouble(this ref Utf8JsonReader reader)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetDouble(out var value))
            {
                return value;
            }

            if (reader.TokenType == JsonTokenType.String
                && double.TryParse(reader.GetString(), NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out value))
            {
                return value;
            }

            throw new JsonException($"Cannot convert token type {reader.TokenType} to double.");
        }

        public static long ReadInt64(this ref Utf8JsonReader reader)
        {
            if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out var value))
            {
                return value;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString();
                if (long.TryParse(stringValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
                {
                    return value;
                }

                throw new FormatException($"The input string '{stringValue}' was not in a correct format.");
            }

            throw new JsonException($"Cannot convert token type {reader.TokenType} to long.");
        }
    }
}
