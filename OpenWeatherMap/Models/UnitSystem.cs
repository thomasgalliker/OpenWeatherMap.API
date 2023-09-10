using System;
using System.Diagnostics;
using System.Linq;

namespace OpenWeatherMap
{
    [DebuggerDisplay("UnitSystem: {this.name}")]
    public struct UnitSystem
    {
        public const string Standard = "standard";
        public const string Metric = "metric";
        public const string Imperial = "imperial";

        public static UnitSystem Default = Standard;

        private readonly string name;

        private UnitSystem(string name)
        {
            this.name = name;
        }

        public static UnitSystem FromName(string name)
        {
            if (name == null)
            {
                return new UnitSystem(Default);
            }

            var all = new[] { Metric, Imperial, Standard };
            var unitSystem = all.SingleOrDefault(x => string.Equals(x, name, StringComparison.InvariantCultureIgnoreCase));
            if (unitSystem == null)
            {
                throw new ArgumentException($"Parameter '{nameof(name)}' must be one of: {string.Join(", ", all.Select(u => u))}", nameof(name));
            }

            return new UnitSystem(name);
        }

        public static implicit operator string(UnitSystem u) => u.name;

        public static implicit operator UnitSystem(string n) => FromName(n);

        public override string ToString()
        {
            return this.name ?? Default;
        }
    }
}