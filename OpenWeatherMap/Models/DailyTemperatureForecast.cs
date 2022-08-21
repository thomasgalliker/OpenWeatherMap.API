﻿using Newtonsoft.Json;

namespace OpenWeatherMap.Models
{
    public class DailyTemperatureForecast
    {
        [JsonProperty("day")]
        public Temperature Day { get; set; }

        [JsonProperty("min")]
        public Temperature Min { get; set; }

        [JsonProperty("max")]
        public Temperature Max { get; set; }

        [JsonProperty("night")]
        public Temperature Night { get; set; }

        [JsonProperty("eve")]
        public Temperature Evening { get; set; }

        [JsonProperty("morn")]
        public Temperature Morning { get; set; }

        public override string ToString()
        {
            return $"Morning: {this.Morning}, Day: {this.Day}, Evening: {this.Evening}, Night: {this.Night}, Min: {this.Min}, Max: {this.Max}";
        }
    }
}