using System;
using Newtonsoft.Json;

namespace OpenWeatherMap.Models.Converters
{
    internal class WeatherConditionCodeJsonConverter : JsonConverter<WeatherConditionCode>
    {
        public override void WriteJson(JsonWriter writer, WeatherConditionCode value, JsonSerializer serializer)
        {
            writer.WriteValue(value.Value);
        }

        public override WeatherConditionCode ReadJson(JsonReader reader, Type objectType, WeatherConditionCode existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value is long longValue)
            {
                return WeatherConditionCode.FromValue((int)longValue);
            }

            throw new NotSupportedException($"Cannot convert from {reader.Value} to WeatherConditionCode");
        }
    }
}
