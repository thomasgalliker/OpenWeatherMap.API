namespace OpenWeatherMap.Models.Converters
{
    internal static class WindHelper
    {
        /// <summary>
        ///     http://snowfence.umn.edu/Components/winddirectionanddegrees.htm
        /// </summary>
        internal static CardinalWindDirection GetCardinalWindDirection(double windDegrees)
        {
            if (windDegrees is > 11.25 and <= 33.75)
            {
                return CardinalWindDirection.NNE;
            }

            if (windDegrees is > 33.75 and <= 56.25)
            {
                return CardinalWindDirection.NE;
            }

            if (windDegrees is > 56.25 and <= 78.75)
            {
                return CardinalWindDirection.ENE;
            }

            if (windDegrees is > 78.75 and <= 101.25)
            {
                return CardinalWindDirection.E;
            }

            if (windDegrees is > 101.25 and <= 123.75)
            {
                return CardinalWindDirection.ESE;
            }

            if (windDegrees is > 123.75 and <= 146.25)
            {
                return CardinalWindDirection.SE;
            }

            if (windDegrees is > 146.25 and <= 168.75)
            {
                return CardinalWindDirection.SSE;
            }

            if (windDegrees is > 168.75 and <= 191.25)
            {
                return CardinalWindDirection.S;
            }

            if (windDegrees is > 191.25 and <= 213.75)
            {
                return CardinalWindDirection.SSW;
            }

            if (windDegrees is > 213.75 and <= 236.25)
            {
                return CardinalWindDirection.SW;
            }

            if (windDegrees is > 236.25 and <= 258.75)
            {
                return CardinalWindDirection.WSW;
            }

            if (windDegrees is > 258.75 and <= 281.25)
            {
                return CardinalWindDirection.W;
            }

            if (windDegrees is > 281.25 and <= 303.75)
            {
                return CardinalWindDirection.WNW;
            }

            if (windDegrees is > 303.75 and <= 326.25)
            {
                return CardinalWindDirection.NW;
            }

            if (windDegrees is > 326.25 and <= 348.75)
            {
                return CardinalWindDirection.NNW;
            }

            return CardinalWindDirection.N;
        }
    }
}