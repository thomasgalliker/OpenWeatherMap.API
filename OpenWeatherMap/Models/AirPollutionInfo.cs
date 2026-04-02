using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenWeatherMap.Models
{
    public class AirPollutionInfo
    {
        public AirPollutionInfo()
        {
            this.Items = new List<AirPollutionInfoItem>();
        }

        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }

        [JsonPropertyName("list")]
        public IReadOnlyCollection<AirPollutionInfoItem> Items { get; set; }
    }
}