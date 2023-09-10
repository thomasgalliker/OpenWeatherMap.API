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
        public static readonly WeatherConditionCode ThunderstormWithLighRain = new WeatherConditionCode(nameof(ThunderstormWithLighRain), 200);
        public static readonly WeatherConditionCode ThunderstormWithRain = new WeatherConditionCode(nameof(ThunderstormWithRain), 201);
        public static readonly WeatherConditionCode ThunderstormWithHeavyRain = new WeatherConditionCode(nameof(ThunderstormWithHeavyRain), 202);
        public static readonly WeatherConditionCode LightThunderstorm = new WeatherConditionCode(nameof(LightThunderstorm), 210);
        public static readonly WeatherConditionCode Thunderstorm = new WeatherConditionCode(nameof(Thunderstorm), 211);
        public static readonly WeatherConditionCode HeavyThunderstorm = new WeatherConditionCode(nameof(HeavyThunderstorm), 212);
        public static readonly WeatherConditionCode RaggedThunderstorm = new WeatherConditionCode(nameof(RaggedThunderstorm), 221);
        public static readonly WeatherConditionCode ThunderstormWithLightDrizzle = new WeatherConditionCode(nameof(ThunderstormWithLightDrizzle), 230);
        public static readonly WeatherConditionCode ThunderstormWithDrizzle = new WeatherConditionCode(nameof(ThunderstormWithDrizzle), 231);
        public static readonly WeatherConditionCode ThunderstormWithHeavyDrizzle = new WeatherConditionCode(nameof(ThunderstormWithHeavyDrizzle), 232);

        public static readonly WeatherConditionCode LightIntensityDrizzle = new WeatherConditionCode(nameof(LightIntensityDrizzle), 300);
        public static readonly WeatherConditionCode Drizzle = new WeatherConditionCode(nameof(Drizzle), 301);
        public static readonly WeatherConditionCode HeavyIntensityDrizzle = new WeatherConditionCode(nameof(HeavyIntensityDrizzle), 302);
        public static readonly WeatherConditionCode LightIntensityDrizzleRain = new WeatherConditionCode(nameof(LightIntensityDrizzleRain), 310);
        public static readonly WeatherConditionCode DrizzleRain = new WeatherConditionCode(nameof(DrizzleRain), 311);
        public static readonly WeatherConditionCode HeavyIntensityDrizzleRain = new WeatherConditionCode(nameof(HeavyIntensityDrizzleRain), 312);
        public static readonly WeatherConditionCode ShowerRainAndDrizzle = new WeatherConditionCode(nameof(ShowerRainAndDrizzle), 313);
        public static readonly WeatherConditionCode HeavyShowerRainAndDrizzle = new WeatherConditionCode(nameof(HeavyShowerRainAndDrizzle), 314);
        public static readonly WeatherConditionCode ShowerDrizzle = new WeatherConditionCode(nameof(ShowerDrizzle), 321);

        public static readonly WeatherConditionCode LightRain = new WeatherConditionCode(nameof(LightRain), 500);
        public static readonly WeatherConditionCode ModerateRain = new WeatherConditionCode(nameof(ModerateRain), 501);
        public static readonly WeatherConditionCode HeavyIntensityRain = new WeatherConditionCode(nameof(HeavyIntensityRain), 502);
        public static readonly WeatherConditionCode VeryHeavyRain = new WeatherConditionCode(nameof(VeryHeavyRain), 503);
        public static readonly WeatherConditionCode ExtremeRain = new WeatherConditionCode(nameof(ExtremeRain), 504);
        public static readonly WeatherConditionCode FreezingRain = new WeatherConditionCode(nameof(FreezingRain), 511);
        public static readonly WeatherConditionCode LightIntensityShowerRain = new WeatherConditionCode(nameof(LightIntensityShowerRain), 520);
        public static readonly WeatherConditionCode ShowerRain = new WeatherConditionCode(nameof(ShowerRain), 521);
        public static readonly WeatherConditionCode HeavyIntensityShowerRain = new WeatherConditionCode(nameof(HeavyIntensityShowerRain), 522);
        public static readonly WeatherConditionCode RaggedShowerRain = new WeatherConditionCode(nameof(RaggedShowerRain), 531);

        public static readonly WeatherConditionCode LightSnow = new WeatherConditionCode(nameof(LightSnow), 600);
        public static readonly WeatherConditionCode Snow = new WeatherConditionCode(nameof(Snow), 601);
        public static readonly WeatherConditionCode HeavySnow = new WeatherConditionCode(nameof(HeavySnow), 602);
        public static readonly WeatherConditionCode Sleet = new WeatherConditionCode(nameof(Sleet), 611);
        public static readonly WeatherConditionCode LightShowerSleet = new WeatherConditionCode(nameof(LightShowerSleet), 612);
        public static readonly WeatherConditionCode ShowerSleet = new WeatherConditionCode(nameof(ShowerSleet), 613);
        public static readonly WeatherConditionCode LightRainAndSnow = new WeatherConditionCode(nameof(LightRainAndSnow), 615);
        public static readonly WeatherConditionCode RainAndSnow = new WeatherConditionCode(nameof(RainAndSnow), 616);
        public static readonly WeatherConditionCode LightShowerSnow = new WeatherConditionCode(nameof(LightShowerSnow), 620);
        public static readonly WeatherConditionCode ShowerSnow = new WeatherConditionCode(nameof(ShowerSnow), 621);
        public static readonly WeatherConditionCode HeavyShowerSnow = new WeatherConditionCode(nameof(HeavyShowerSnow), 622);

        public static readonly WeatherConditionCode Mist = new WeatherConditionCode(nameof(Mist), 701);
        public static readonly WeatherConditionCode Smoke = new WeatherConditionCode(nameof(Smoke), 711);
        public static readonly WeatherConditionCode Haze = new WeatherConditionCode(nameof(Haze), 721);
        public static readonly WeatherConditionCode SandDustWhirls = new WeatherConditionCode(nameof(SandDustWhirls), 731);
        public static readonly WeatherConditionCode Fog = new WeatherConditionCode(nameof(Fog), 741);
        public static readonly WeatherConditionCode Sand = new WeatherConditionCode(nameof(Sand), 751);
        public static readonly WeatherConditionCode Dust = new WeatherConditionCode(nameof(Dust), 761);
        public static readonly WeatherConditionCode VolcanicAsh = new WeatherConditionCode(nameof(VolcanicAsh), 762);
        public static readonly WeatherConditionCode Squalls = new WeatherConditionCode(nameof(Squalls), 771);
        public static readonly WeatherConditionCode Tornado = new WeatherConditionCode(nameof(Tornado), 781);

        public static readonly WeatherConditionCode Clear = new WeatherConditionCode(nameof(Clear), 800);
        public static readonly WeatherConditionCode FewClouds = new WeatherConditionCode(nameof(FewClouds), 801);
        public static readonly WeatherConditionCode ScatteredClouds = new WeatherConditionCode(nameof(ScatteredClouds), 802);
        public static readonly WeatherConditionCode BrokenClouds = new WeatherConditionCode(nameof(BrokenClouds), 803);
        public static readonly WeatherConditionCode OvercastClouds = new WeatherConditionCode(nameof(OvercastClouds), 804);

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

        private readonly string resourceId;

        private WeatherConditionCode(string resourceId, int value)
        {
            this.resourceId = resourceId;
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