using OpenWeatherMap.Models;
using UnitsNet;

namespace OpenWeatherMap.Extensions
{
    public static class HumidityExtensions
    {
        public static HumidityRange GetRange(this RelativeHumidity relativeHumidity)
        {
            return HumidityRange.FromValue(relativeHumidity);
        }
    }
}
