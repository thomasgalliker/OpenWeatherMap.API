﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenWeatherMap.Models.Converters
{
    /// <summary>
    /// Converts integer/long dates starting from 1970-01-01 (Epoch) to DateTime.
    /// Helpful source: https://www.epochconverter.com
    /// </summary>
    public class EpochDateTimeConverter : DateTimeConverterBase
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime Convert(long seconds)
        {
            return Epoch.AddSeconds(seconds);
        }

        public static long Convert(DateTime dateTime)
        {
            var utcDateTime = dateTime.ToUniversalTime();
            return (long)(utcDateTime - Epoch).TotalSeconds;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var utcDateTime = (DateTime)value;
            var seconds = Convert(utcDateTime);
            writer.WriteValue(seconds);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            var seconds = System.Convert.ToInt64(reader.Value);
            var dateTime = Convert(seconds);
            return dateTime;
        }
    }
}