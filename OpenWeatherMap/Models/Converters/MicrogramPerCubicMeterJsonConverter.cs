using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet;
using UnitsNet.Units;

namespace OpenWeatherMap.Models.Converters
{
    internal class MicrogramPerCubicMeterJsonConverter : JsonConverter<MassConcentration>
    {
        private readonly MassConcentrationUnit unit;

        public MicrogramPerCubicMeterJsonConverter()
        {
            this.unit = MassConcentrationUnit.MicrogramPerCubicMeter;
        }

        public override void Write(Utf8JsonWriter writer, MassConcentration value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override MassConcentration Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new MassConcentration(reader.ReadDouble(), this.unit);
        }
    }
}
