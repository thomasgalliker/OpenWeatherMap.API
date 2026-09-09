using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet;
using UnitsNet.Units;

namespace OpenWeatherMap.Models.Converters
{
    internal class SpeedJsonConverter : JsonConverter<Speed>
    {
        private readonly SpeedUnit speedUnit;

        public SpeedJsonConverter(SpeedUnit speedUnit)
        {
            this.speedUnit = speedUnit;
        }

        public override void Write(Utf8JsonWriter writer, Speed value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override Speed Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new Speed(reader.ReadDouble(), this.speedUnit);
        }
    }
}
