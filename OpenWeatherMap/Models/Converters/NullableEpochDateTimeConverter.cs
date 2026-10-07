using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models.Converters
{
    /// <summary>
    /// Converts optional unix timestamps (seconds since 1970-01-01 UTC) to <see cref="DateTime"/>.
    /// The OpenWeatherMap API either omits such timestamps or returns <c>0</c> if they are not available
    /// (e.g. sunrise/sunset in polar areas during midnight sun and polar night), both are converted to <c>null</c>.
    /// </summary>
    internal sealed class NullableEpochDateTimeConverter : JsonConverter<DateTime?>
    {
        private const long NotAvailable = 0L;

        public override bool HandleNull => true;

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value is DateTime dateTime)
            {
                writer.WriteNumberValue(EpochDateTimeConverter.Convert(dateTime));
            }
            else
            {
                writer.WriteNullValue();
            }
        }

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            var seconds = reader.ReadInt64();
            return seconds == NotAvailable ? null : EpochDateTimeConverter.Convert(seconds);
        }
    }
}
