using System;
using Newtonsoft.Json;
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

        public override void WriteJson(JsonWriter writer, Speed value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override Speed ReadJson(JsonReader reader, Type objectType, Speed existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is double doubleValue)
            {
                return new Speed(doubleValue, this.speedUnit);
            }

            if (reader.Value is long longValue)
            {
                return new Speed(longValue, this.speedUnit);
            }

            throw new NotSupportedException($"Cannot convert from {reader.Value} to {nameof(Speed)}");
        }
    }
}
