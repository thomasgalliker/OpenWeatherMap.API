using UnitsNet.Units;

namespace OpenWeatherMap.Models.Converters
{
    internal class MillimeterLengthJsonConverter : LengthJsonConverter
    {
        public MillimeterLengthJsonConverter()
            : base(LengthUnit.Millimeter)
        {
        }
    }
}
