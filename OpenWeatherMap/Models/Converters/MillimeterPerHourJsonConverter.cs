using UnitsNet.Units;

namespace OpenWeatherMap.Models.Converters
{
    internal class MillimeterPerHourJsonConverter : SpeedJsonConverter
    {
        public MillimeterPerHourJsonConverter()
            : base(SpeedUnit.MillimeterPerHour)
        {
        }
    }
}
