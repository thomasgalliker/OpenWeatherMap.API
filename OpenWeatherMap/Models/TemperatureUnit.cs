using System.ComponentModel;

namespace OpenWeatherMap.Models
{
    public enum TemperatureUnit
    {
        [Description("K")]
        Kelvin = 0,

        [Description("°C")]
        Celsius,

        [Description("°F")]
        Fahrenheit,
    }
}