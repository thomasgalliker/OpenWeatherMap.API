using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    /// <summary>
    /// Reads a precipitation volume in mm which is either provided as number (e.g. <c>"rain": 1.2</c>)
    /// or as object with the volume of the last hour (e.g. <c>"rain": { "1h": 1.2 }</c>).
    /// </summary>
    internal class PrecipitationVolumeJsonConverter : JsonConverter<Length>
    {
        private const string LastHourPropertyName = "1h";

        public override void Write(Utf8JsonWriter writer, Length value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Millimeters);
        }

        public override Length Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                return Length.FromMillimeters(reader.ReadDouble());
            }

            var millimeters = 0d;
            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                var propertyName = reader.GetString();
                reader.Read();

                if (propertyName == LastHourPropertyName)
                {
                    millimeters = reader.ReadDouble();
                }
                else
                {
                    reader.Skip();
                }
            }

            return Length.FromMillimeters(millimeters);
        }
    }
}
