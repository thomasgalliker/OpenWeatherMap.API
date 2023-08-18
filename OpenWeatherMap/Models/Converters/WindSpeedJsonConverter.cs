using UnitsNet.Units;

namespace OpenWeatherMap.Models.Converters
{
    internal class WindSpeedJsonConverter : SpeedJsonConverter
    {
        public WindSpeedJsonConverter(SpeedUnit speedUnit)
            : base(speedUnit)
        {
        }
    }
}
