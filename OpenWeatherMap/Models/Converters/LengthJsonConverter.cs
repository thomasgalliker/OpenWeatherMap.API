using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet;
using UnitsNet.Units;

namespace OpenWeatherMap.Models.Converters
{
    internal abstract class LengthJsonConverter : JsonConverter<Length>
    {
        private readonly LengthUnit lengthUnit;

        protected LengthJsonConverter(LengthUnit lengthUnit)
        {
            this.lengthUnit = lengthUnit;
        }

        public override void Write(Utf8JsonWriter writer, Length value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override Length Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Length.From(reader.ReadDouble(), this.lengthUnit);
        }
    }
}
