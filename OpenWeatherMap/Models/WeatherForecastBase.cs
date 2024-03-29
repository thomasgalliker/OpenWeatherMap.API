﻿using Newtonsoft.Json;

namespace OpenWeatherMap.Models
{
    public abstract class WeatherForecastBase
    {
        [JsonProperty("cod")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("cnt")]
        public int Count { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }
}
