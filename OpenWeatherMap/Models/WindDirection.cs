using System;
using System.Globalization;

namespace OpenWeatherMap.Models
{
    [Serializable]
    public struct WindDirection : IComparable, IComparable<WindDirection>, IComparable<double>, IEquatable<WindDirection>, IFormattable
    {
        public static double MinValue = 0;
        public static double MaxValue = 360;

        public WindDirection(double value)
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentOutOfRangeException(string.Format($"{0} must be between {MinValue} and {MaxValue}", value));
            }

            this.Value = value;
        }

        public double Value { get; private set; }

        public int CompareTo(object obj)
        {
            if (obj is WindDirection)
            {
                return this.Value.CompareTo((double)obj);
            }

            return this.Value.CompareTo(obj);
        }

        public int CompareTo(WindDirection other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public int CompareTo(double other)
        {
            return this.Value.CompareTo(other);
        }

        public bool Equals(WindDirection other)
        {
            return this.Value.Equals(other.Value);
        }

        public static WindDirection operator +(double v, WindDirection windDirection)
        {
            return new WindDirection(windDirection.Value + v);
        }

        public static WindDirection operator +(WindDirection windDirection, double v)
        {
            return v + windDirection;
        }

        public static WindDirection operator +(WindDirection value1, WindDirection value2)
        {
            return value1 + value2.Value;
        }

        public static WindDirection operator -(WindDirection windDirection, double v)
        {
            return new WindDirection(windDirection.Value - v);
        }

        public static WindDirection operator -(WindDirection windDirection1, WindDirection windDirection2)
        {
            return windDirection1 - windDirection2.Value;
        }

        public static WindDirection operator *(WindDirection windDirection, double v)
        {
            return new WindDirection(windDirection.Value * v);
        }

        public static WindDirection operator /(WindDirection windDirection, double v)
        {
            return new WindDirection(windDirection.Value / v);
        }

        public static implicit operator WindDirection(double v) => new WindDirection(v);

        public static implicit operator double(WindDirection windDirection) => windDirection.Value;

        public override string ToString()
        {
            return this.ToString(null, null);
        }

        public string ToString(string format)
        {
            return this.ToString(format, null);
        }

        /// <summary>
        /// Converts the value of the current CardinalWindDirection object to its equivalent string representation using the formatting conventions of the current culture.
        /// </summary>
        /// <param name="format">A standard format string.</param>
        /// <remarks>
        /// The valid format strings are as follows:
        /// <list type="bullet">
        ///     <item>
        ///         <term>A standard numeric format string.</term>
        ///         <description>Any of the standard numeric format for <see cref="Value" />, except for "G" or "g", which have a special implementation.
        ///         "D" or "d", "F" or "f", "N" or "n", "R" or "r" are all accepted.
        ///         See https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#standard-format-specifiers.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"G" or "g".</term>
        ///         <description>The secondary intercardinal wind direction, such as "North-Northeast".</description>
        ///     </item>
        ///     <item>
        ///         <term>"A" or "a".</term>
        ///         <description>The <see cref="CardinalWindDirection" />.</description>
        ///     </item>
        ///     <item>
        ///         <term>"A4", "A8", "A16" are accepted.</term>
        ///         <description>The <see cref="CardinalWindDirection" /> rounded to the precision specifier.
        ///         A <see cref="FormatException"/> will be thrown if the requested abbreviation index does not exist.</description>
        ///     </item>
        /// </list>
        /// </remarks>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current CardinalWindDirection object as specified by format.</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            var culture = provider as CultureInfo ?? CultureInfo.CurrentCulture;

            if (string.IsNullOrWhiteSpace(format))
            {
                format = "g";
            }

            var formatSpecifier = format![0];
            var precisionSpecifier = 0;

            switch (formatSpecifier)
            {
                case 'A':
                case 'a':
                    if (format.Length > 1 && !int.TryParse(format.Substring(1), out precisionSpecifier))
                    {
                        throw new FormatException($"The format string \"{format}\" is not supported.");
                    }
                    break;
            }

            switch (formatSpecifier)
            {
                case 'd':
                case 'D':
                case 'f':
                case 'F':
                case 'n':
                case 'N':
                case 'r':
                case 'R':
                    return this.Value.ToString(format, provider);
                case 'a':
                case 'A':
                    if (precisionSpecifier == 4)
                    {
                        return this.GetCardinalWindDirection().ToString(null, culture);
                    }
                    else if (precisionSpecifier == 8)
                    {
                        return this.GetIntercardinalWindDirection().ToString(null, culture);
                    }
                    else if (precisionSpecifier == 16)
                    {
                        return this.GetSecondaryIntercardinalWindDirection().ToString(null, culture);
                    }
                    else
                    {
                        throw new FormatException($"The format string \"{format}\" is not supported.");
                    }
                case 'g':
                case 'G':
                default:
                    return this.GetSecondaryIntercardinalWindDirection().ToString(null, culture);
            }
        }
    }
}