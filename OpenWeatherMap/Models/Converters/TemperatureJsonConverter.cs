using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet;
using UnitsNet.Units;

namespace OpenWeatherMap.Models.Converters
{
    internal class TemperatureJsonConverter : JsonConverter<Temperature>
    {
        private readonly TemperatureUnit temperatureUnit;

        public TemperatureJsonConverter(TemperatureUnit temperatureUnit)
        {
            this.temperatureUnit = temperatureUnit;
        }

        public override void Write(Utf8JsonWriter writer, Temperature value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }

        public override Temperature Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new Temperature(reader.ReadDouble(), this.temperatureUnit);
        }
    }
}
