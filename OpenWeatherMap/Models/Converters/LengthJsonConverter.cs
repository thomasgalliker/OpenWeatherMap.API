using System;
using Newtonsoft.Json;
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

        public override void WriteJson(JsonWriter writer, Length value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override Length ReadJson(JsonReader reader, Type objectType, Length existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is double doubleValue)
            {
                return Length.From(doubleValue, this.lengthUnit);
            }

            if (reader.Value is long longValue)
            {
                return Length.From(longValue, this.lengthUnit);
            }

            return reader.Value is string stringValue && double.TryParse(stringValue, out var value)
                ? Length.From(value, this.lengthUnit)
                : default;
        }
    }
}
