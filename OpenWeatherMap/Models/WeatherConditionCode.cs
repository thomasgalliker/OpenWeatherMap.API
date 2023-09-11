using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OpenWeatherMap.Resources.Strings;

namespace OpenWeatherMap.Models
{
    [Serializable]
    public struct WeatherConditionCode : IComparable, IComparable<WeatherConditionCode>, IComparable<int>, IEquatable<WeatherConditionCode>, IFormattable
    {
        public static readonly WeatherConditionCode ThunderstormWithLighRain = new WeatherConditionCode(200);
        public static readonly WeatherConditionCode ThunderstormWithRain = new WeatherConditionCode(201);
        public static readonly WeatherConditionCode ThunderstormWithHeavyRain = new WeatherConditionCode(202);
        public static readonly WeatherConditionCode LightThunderstorm = new WeatherConditionCode(210);
        public static readonly WeatherConditionCode Thunderstorm = new WeatherConditionCode(211);
        public static readonly WeatherConditionCode HeavyThunderstorm = new WeatherConditionCode(212);
        public static readonly WeatherConditionCode RaggedThunderstorm = new WeatherConditionCode(221);
        public static readonly WeatherConditionCode ThunderstormWithLightDrizzle = new WeatherConditionCode(230);
        public static readonly WeatherConditionCode ThunderstormWithDrizzle = new WeatherConditionCode(231);
        public static readonly WeatherConditionCode ThunderstormWithHeavyDrizzle = new WeatherConditionCode(232);

        public static readonly WeatherConditionCode LightIntensityDrizzle = new WeatherConditionCode(300);
        public static readonly WeatherConditionCode Drizzle = new WeatherConditionCode(301);
        public static readonly WeatherConditionCode HeavyIntensityDrizzle = new WeatherConditionCode(302);
        public static readonly WeatherConditionCode LightIntensityDrizzleRain = new WeatherConditionCode(310);
        public static readonly WeatherConditionCode DrizzleRain = new WeatherConditionCode(311);
        public static readonly WeatherConditionCode HeavyIntensityDrizzleRain = new WeatherConditionCode(312);
        public static readonly WeatherConditionCode ShowerRainAndDrizzle = new WeatherConditionCode(313);
        public static readonly WeatherConditionCode HeavyShowerRainAndDrizzle = new WeatherConditionCode(314);
        public static readonly WeatherConditionCode ShowerDrizzle = new WeatherConditionCode(321);

        public static readonly WeatherConditionCode LightRain = new WeatherConditionCode(500);
        public static readonly WeatherConditionCode ModerateRain = new WeatherConditionCode(501);
        public static readonly WeatherConditionCode HeavyIntensityRain = new WeatherConditionCode(502);
        public static readonly WeatherConditionCode VeryHeavyRain = new WeatherConditionCode(503);
        public static readonly WeatherConditionCode ExtremeRain = new WeatherConditionCode(504);
        public static readonly WeatherConditionCode FreezingRain = new WeatherConditionCode(511);
        public static readonly WeatherConditionCode LightIntensityShowerRain = new WeatherConditionCode(520);
        public static readonly WeatherConditionCode ShowerRain = new WeatherConditionCode(521);
        public static readonly WeatherConditionCode HeavyIntensityShowerRain = new WeatherConditionCode(522);
        public static readonly WeatherConditionCode RaggedShowerRain = new WeatherConditionCode(531);

        public static readonly WeatherConditionCode LightSnow = new WeatherConditionCode(600);
        public static readonly WeatherConditionCode Snow = new WeatherConditionCode(601);
        public static readonly WeatherConditionCode HeavySnow = new WeatherConditionCode(602);
        public static readonly WeatherConditionCode Sleet = new WeatherConditionCode(611);
        public static readonly WeatherConditionCode LightShowerSleet = new WeatherConditionCode(612);
        public static readonly WeatherConditionCode ShowerSleet = new WeatherConditionCode(613);
        public static readonly WeatherConditionCode LightRainAndSnow = new WeatherConditionCode(615);
        public static readonly WeatherConditionCode RainAndSnow = new WeatherConditionCode(616);
        public static readonly WeatherConditionCode LightShowerSnow = new WeatherConditionCode(620);
        public static readonly WeatherConditionCode ShowerSnow = new WeatherConditionCode(621);
        public static readonly WeatherConditionCode HeavyShowerSnow = new WeatherConditionCode(622);

        public static readonly WeatherConditionCode Mist = new WeatherConditionCode(701);
        public static readonly WeatherConditionCode Smoke = new WeatherConditionCode(711);
        public static readonly WeatherConditionCode Haze = new WeatherConditionCode(721);
        public static readonly WeatherConditionCode SandDustWhirls = new WeatherConditionCode(731);
        public static readonly WeatherConditionCode Fog = new WeatherConditionCode(741);
        public static readonly WeatherConditionCode Sand = new WeatherConditionCode(751);
        public static readonly WeatherConditionCode Dust = new WeatherConditionCode(761);
        public static readonly WeatherConditionCode VolcanicAsh = new WeatherConditionCode(762);
        public static readonly WeatherConditionCode Squalls = new WeatherConditionCode(771);
        public static readonly WeatherConditionCode Tornado = new WeatherConditionCode(781);

        public static readonly WeatherConditionCode Clear = new WeatherConditionCode(800);
        public static readonly WeatherConditionCode FewClouds = new WeatherConditionCode(801);
        public static readonly WeatherConditionCode ScatteredClouds = new WeatherConditionCode(802);
        public static readonly WeatherConditionCode BrokenClouds = new WeatherConditionCode(803);
        public static readonly WeatherConditionCode OvercastClouds = new WeatherConditionCode(804);

        public static readonly IEnumerable<WeatherConditionCode> All = new List<WeatherConditionCode>
        {
            ThunderstormWithLighRain,
            ThunderstormWithRain,
            ThunderstormWithHeavyRain,
            LightThunderstorm,
            Thunderstorm,
            HeavyThunderstorm,
            RaggedThunderstorm,
            ThunderstormWithLightDrizzle,
            ThunderstormWithDrizzle,
            ThunderstormWithHeavyDrizzle,

            LightIntensityDrizzle,
            Drizzle,
            HeavyIntensityDrizzle,
            LightIntensityDrizzleRain,
            DrizzleRain,
            HeavyIntensityDrizzleRain,
            ShowerRainAndDrizzle,
            HeavyShowerRainAndDrizzle,
            ShowerDrizzle,

            LightRain,
            ModerateRain,
            HeavyIntensityRain,
            VeryHeavyRain,
            ExtremeRain,
            FreezingRain,
            LightIntensityShowerRain,
            ShowerRain,
            HeavyIntensityShowerRain,
            RaggedShowerRain,

            LightSnow,
            Snow,
            HeavySnow,
            Sleet,
            LightShowerSleet,
            ShowerSleet,
            LightRainAndSnow,
            RainAndSnow,
            LightShowerSnow,
            ShowerSnow,
            HeavyShowerSnow,

            Mist,
            Smoke,
            Haze,
            SandDustWhirls,
            Fog,
            Sand,
            Dust,
            VolcanicAsh,
            Squalls,
            Tornado,

            Clear,
            FewClouds,
            ScatteredClouds,
            BrokenClouds,
            OvercastClouds,
        };

        private WeatherConditionCode(int value)
        {
            this.Value = value;
        }

        public int Value { get; private set; }

        public static WeatherConditionCode FromValue(int value)
        {
            var weatherConditionCode = All.Cast<WeatherConditionCode?>().SingleOrDefault(x => x.Value == value);
            if (weatherConditionCode == null)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    $"Value {value} is out of range. " +
                    $"Valid values must be between {All.Min(x => x.Value)} and {All.Max(x => x.Value)}");
            }

            return weatherConditionCode.Value;
        }

        public int CompareTo(object obj)
        {
            if (obj is WeatherConditionCode)
            {
                return this.Value.CompareTo((int)obj);
            }

            return this.Value.CompareTo(obj);
        }

        public int CompareTo(WeatherConditionCode other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public int CompareTo(int other)
        {
            return this.Value.CompareTo(other);
        }

        public bool Equals(WeatherConditionCode other)
        {
            return this.Value.Equals(other.Value);
        }

        public static implicit operator WeatherConditionCode(int v) => FromValue(v);

        public static implicit operator WeatherConditionCode(long v) => FromValue((int)v);

        public static implicit operator int(WeatherConditionCode h) => h.Value;

        public static implicit operator long(WeatherConditionCode h) => h.Value;

        public override string ToString()
        {
            return this.ToString(null, null);
        }

        public string ToString(string format)
        {
            return this.ToString(format, null);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            provider ??= CultureInfo.CurrentCulture;
            var valueString = $"{this.Value}";

            switch (format)
            {
                case "G":
                    var translation = WeatherConditionCodes.ResourceManager.GetString(valueString, (CultureInfo)provider);
                    return translation;
                default:
                    return valueString;
            }
        }
    }
}