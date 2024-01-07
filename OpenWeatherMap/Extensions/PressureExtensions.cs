using OpenWeatherMap.Models;
using UnitsNet;

namespace OpenWeatherMap.Extensions
{
    public static class PressureExtensions
    {
        public static PressureRange GetRange(this Pressure pressure)
        {
            return PressureRange.FromValue(pressure);
        }
    }
}
