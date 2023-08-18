using Newtonsoft.Json;
using OpenWeatherMap.Models.Converters;
using UnitsNet;

namespace OpenWeatherMap.Models
{
    /// <summary>
    /// Concentrations of gases and particles in the air.
    /// </summary>
    /// <remarks>
    /// The concentration of an air pollutant is given in micrograms per cubic meter air (µg/m3).
    /// </remarks>
    public class AirConcentrationComponents
    {
        /// <summary>
        /// Concentration of Carbon Monoxide (CO) in the air, in µg/m3.
        /// </summary>
        [JsonProperty("co")]
        [JsonConverter(typeof(MicrogramPerCubicMeterJsonConverter))]
        public MassConcentration CarbonMonoxide { get; set; }

        /// <summary>
        /// Concentration of Nitrogen Monoxide (NO) in the air, in µg/m3.
        /// </summary>
        [JsonProperty("no")]
        [JsonConverter(typeof(MicrogramPerCubicMeterJsonConverter))]
        public MassConcentration NitrogenMonoxide { get; set; }

        /// <summary>
        /// Concentration of Nitrogen Dioxide (NO2) in the air, in µg/m3.
        /// </summary>
        [JsonProperty("no2")]
        [JsonConverter(typeof(MicrogramPerCubicMeterJsonConverter))]
        public MassConcentration NitrogenDioxide { get; set; }

        /// <summary>
        /// Concentration of Ozone (O3) in the air, in µg/m3.
        /// </summary>
        [JsonProperty("o3")]
        [JsonConverter(typeof(MicrogramPerCubicMeterJsonConverter))]
        public MassConcentration Ozone { get; set; }

        /// <summary>
        /// Concentration of Sulphur Dioxide (SO2) in the air, in µg/m3.
        /// </summary>
        [JsonProperty("so2")]
        [JsonConverter(typeof(MicrogramPerCubicMeterJsonConverter))]
        public MassConcentration SulphurDioxide { get; set; }

        /// <summary>
        /// Concentration of fine particles matter (PM2.5) in the air, in µg/m3.
        /// </summary>
        [JsonProperty("pm2_5")]
        [JsonConverter(typeof(MicrogramPerCubicMeterJsonConverter))]
        public MassConcentration FineParticulateMatter { get; set; }

        /// <summary>
        /// Concentration of coarse particulate matter (PM10) in the air, in µg/m3.
        /// </summary>
        [JsonProperty("pm10")]
        [JsonConverter(typeof(MicrogramPerCubicMeterJsonConverter))]
        public MassConcentration CoarseParticulateMatter { get; set; }

        /// <summary>
        /// Concentration of ammonia (NH3) in the air, in µg/m3.
        /// </summary>
        [JsonProperty("nh3")]
        [JsonConverter(typeof(MicrogramPerCubicMeterJsonConverter))]
        public MassConcentration Ammonia { get; set; }
    }
}