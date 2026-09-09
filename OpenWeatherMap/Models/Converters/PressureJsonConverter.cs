using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet;

namespace OpenWeatherMap.Models.Converters
{
    internal class PressureJsonConverter : JsonConverter<Pressure>
    {
        public override void Write(Utf8JsonWriter writer, Pressure value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override Pressure Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Pressure.FromHectopascals(reader.ReadDouble());
        }
    }
}
