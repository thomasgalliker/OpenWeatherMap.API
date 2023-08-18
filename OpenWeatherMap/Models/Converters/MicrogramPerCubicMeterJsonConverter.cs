using System;
using Newtonsoft.Json;
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

        public override void WriteJson(JsonWriter writer, MassConcentration value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override MassConcentration ReadJson(JsonReader reader, Type objectType, MassConcentration existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is double doubleValue)
            {
                return new MassConcentration(doubleValue, this.unit);
            }

            if (reader.Value is long longValue)
            {
                return new MassConcentration(longValue, this.unit);
            }

            throw new NotSupportedException($"Cannot convert from {reader.Value} to {nameof(MassConcentration)}");
        }
    }
}
