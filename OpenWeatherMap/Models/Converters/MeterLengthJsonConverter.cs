using UnitsNet.Units;

namespace OpenWeatherMap.Models.Converters
{
    internal class MeterLengthJsonConverter : LengthJsonConverter
    {
        public MeterLengthJsonConverter()
            : base(LengthUnit.Meter)
        {
        }
    }
}
