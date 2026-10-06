namespace OpenWeatherMap
{
    /// <summary>
    /// Selects the parts of the One Call API response to be requested.
    /// </summary>
    public class OneCallOptions
    {
        /// <summary>
        /// Gets a new instance of <see cref="OneCallOptions"/> which requests all parts of the response.
        /// </summary>
        public static OneCallOptions Default => new OneCallOptions();

        /// <summary>
        /// Indicates if the CurrentWeather property should be requested.
        /// </summary>
        public bool IncludeCurrentWeather { get; set; } = true;

        /// <summary>
        /// Indicates if the DailyForecasts property should be requested.
        /// </summary>
        public bool IncludeDailyForecasts { get; set; } = true;

        /// <summary>
        /// Indicates if the MinutelyForecasts property should be requested.
        /// </summary>
        public bool IncludeMinutelyForecasts { get; set; } = true;

        /// <summary>
        /// Indicates if the HourlyForecasts property should be requested.
        /// </summary>
        public bool IncludeHourlyForecasts { get; set; } = true;

        /// <summary>
        /// Indicates if the Alerts property should be requested.
        /// </summary>
        public bool IncludeAlerts { get; set; } = true;
    }
}
