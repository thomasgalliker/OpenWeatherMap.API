using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models.Converters
{
    /// <summary>
    /// Converts integer/long dates starting from 1970-01-01 (Epoch) to DateTime.
    /// Helpful source: https://www.epochconverter.com
    /// </summary>
    public class EpochDateTimeConverter : JsonConverter<DateTime>
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime Convert(long seconds)
        {
            return Epoch.AddSeconds(seconds);
        }

        public static long Convert(DateTime dateTime)
        {
            var utcDateTime = dateTime.ToUniversalTime();
            return (long)(utcDateTime - Epoch).TotalSeconds;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(Convert(value));
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Convert(reader.ReadInt64());
        }
    }
}
