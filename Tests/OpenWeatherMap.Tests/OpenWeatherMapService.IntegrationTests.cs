using FluentAssertions;
using Microsoft.Extensions.Logging;
using OpenWeatherMap.Models;
using OpenWeatherMap.Tests.Logging;
using OpenWeatherMap.Tests.Testdata;
using UnitsNet;
using UnitsNet.Units;
using Xunit;
using Xunit.Abstractions;

namespace OpenWeatherMap.Tests
{
    [Trait(Traits.Category, Traits.IntegrationTests)]
    public class OpenWeatherMapServiceIntegrationTests
    {
        /// <summary>
        /// Skip reason for tests which require a paid OpenWeatherMap plan.
        /// Set to null to run them (requires a valid OpenWeatherMap_PRO:ApiKey).
        /// </summary>
        private const string? ProLicenseSkipReason = "Requires an OpenWeatherMap pro license";
        private const string OneCallSkipReason = "One Call API 2.5 was retired by OpenWeatherMap";

        private const double Latitude = 47.0907124d;
        private const double Longitude = 8.0559381d;

        private readonly ILogger<OpenWeatherMapService> logger;
        private readonly OpenWeatherMapOptions openWeatherMapOptions;
        private readonly OpenWeatherMapOptions openWeatherMapProOptions;
        private readonly ITestOutputHelper testOutputHelper;
        private readonly DumpOptions dumpOptions;

        public OpenWeatherMapServiceIntegrationTests(ITestOutputHelper testOutputHelper)
        {
            this.logger = new TestOutputHelperLogger<OpenWeatherMapService>(testOutputHelper);
            this.openWeatherMapOptions = AppSettings.GetApiConfiguration("OpenWeatherMap");
            this.openWeatherMapProOptions = AppSettings.GetApiConfiguration("OpenWeatherMap_PRO");
            this.testOutputHelper = testOutputHelper;

            this.dumpOptions = new DumpOptions
            {
                DumpStyle = DumpStyle.CSharp,
                SetPropertiesOnly = true
            };

            this.dumpOptions.CustomInstanceFormatters.AddFormatter<Temperature>(t => $"new Temperature({t.Value}d, {nameof(TemperatureUnit)}.{t.Unit})");
            this.dumpOptions.CustomInstanceFormatters.AddFormatter<Pressure>(p => $"new Pressure({p.Value}d, {nameof(PressureUnit)}.{p.Unit})");
            this.dumpOptions.CustomInstanceFormatters.AddFormatter<RelativeHumidity>(h => $"new RelativeHumidity({h.Value}d, {nameof(RelativeHumidityUnit)}.{h.Unit})");
            this.dumpOptions.CustomInstanceFormatters.AddFormatter<Length>(l => $"new Length({l.Value}d, {nameof(LengthUnit)}.{l.Unit})");
            this.dumpOptions.CustomInstanceFormatters.AddFormatter<Ratio>(r => $"new Ratio({r.Value}d, {nameof(RatioUnit)}.{r.Unit})");
            this.dumpOptions.CustomInstanceFormatters.AddFormatter<MassConcentration>(r => $"new MassConcentration({r.Value}d, {nameof(MassConcentrationUnit)}.{r.Unit})");
            this.dumpOptions.CustomInstanceFormatters.AddFormatter<UVIndex>(uvi => $"new UVIndex({uvi.Value}d)");
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_ValidCoordinates_ReturnsWeatherInfo()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var weatherInfo = await openWeatherMapService.GetCurrentWeatherAsync(Latitude, Longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(weatherInfo, this.dumpOptions));

            weatherInfo.Should().NotBeNull();
            weatherInfo.CityId.Should().BePositive();
            weatherInfo.CityName.Should().NotBeNullOrEmpty();
            weatherInfo.Date.Should().BeAfter(DateTime.MinValue);
            weatherInfo.Weather.Should().NotBeEmpty();
            weatherInfo.Main.Should().NotBeNull();
        }

        [Theory(Skip = ProLicenseSkipReason)]
        [InlineData(null, 96)]
        [InlineData(24, 24)]
        public async Task GetWeatherForecast4Async_WithCount_ReturnsHourlyForecast(int? count, int expectedCount)
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapProOptions);

            // Act
            var weatherForecast = await openWeatherMapService.GetWeatherForecast4Async(Latitude, Longitude, count);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(weatherForecast, this.dumpOptions));

            weatherForecast.Should().NotBeNull();
            weatherForecast.Count.Should().Be(expectedCount);
            weatherForecast.Items.Should().HaveCount(expectedCount);
            weatherForecast.City.Id.Should().BePositive();
        }

        [Fact]
        public async Task GetWeatherForecast5Async_ValidCoordinates_ReturnsForecast()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var weatherForecast = await openWeatherMapService.GetWeatherForecast5Async(Latitude, Longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(weatherForecast, this.dumpOptions));

            weatherForecast.Should().NotBeNull();
            weatherForecast.Count.Should().Be(40);
            weatherForecast.Items.Should().HaveCount(40);
            weatherForecast.City.Id.Should().BePositive();
            weatherForecast.City.Name.Should().NotBeNullOrEmpty();
        }

        [Fact(Skip = ProLicenseSkipReason)]
        public async Task GetWeatherForecastDailyAsync_ValidCoordinates_ReturnsDailyForecast()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapProOptions);

            // Act
            var weatherForecast = await openWeatherMapService.GetWeatherForecastDailyAsync(Latitude, Longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(weatherForecast, this.dumpOptions));

            weatherForecast.Should().NotBeNull();
            weatherForecast.Count.Should().Be(7);
            weatherForecast.Items.Should().HaveCount(7);

            foreach (var dailyWeatherForecastItem in weatherForecast.Items)
            {
                dailyWeatherForecastItem.DateTime.Should().BeAfter(DateTime.MinValue);
                dailyWeatherForecastItem.Sunrise.Should().BeAfter(DateTime.MinValue);
                dailyWeatherForecastItem.Sunset.Should().BeAfter(DateTime.MinValue);
                dailyWeatherForecastItem.Temperature.Should().NotBeNull();
                dailyWeatherForecastItem.FeelsLike.Should().NotBeNull();
                dailyWeatherForecastItem.Weather.Should().HaveCountGreaterThanOrEqualTo(1);
                dailyWeatherForecastItem.Wind.Should().NotBeNull();
            }
        }

        [Fact(Skip = OneCallSkipReason)]
        public async Task GetWeatherOneCallAsync_WithOptions_ReturnsOneCallWeatherInfo()
        {
            // Arrange
            var oneCallOptions = new OneCallOptions
            {
                IncludeCurrentWeather = true,
                IncludeDailyForecasts = true,
                IncludeMinutelyForecasts = true,
                IncludeHourlyForecasts = true,
            };

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapProOptions);

            // Act
#pragma warning disable CS0618 // Tests the obsolete One Call API 2.5
            var oneCallWeatherInfo = await openWeatherMapService.GetWeatherOneCallAsync(Latitude, Longitude, oneCallOptions);
#pragma warning restore CS0618

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(oneCallWeatherInfo, this.dumpOptions));

            oneCallWeatherInfo.Should().NotBeNull();
            oneCallWeatherInfo.CurrentWeather.Should().NotBeNull();
            oneCallWeatherInfo.HourlyForecasts.Should().NotBeEmpty();
            oneCallWeatherInfo.DailyForecasts.Should().NotBeEmpty();
        }

        [Fact(Skip = OneCallSkipReason)]
        public async Task GetWeatherOneCallHistoricAsync_ValidDateTime_ReturnsOneCallWeatherInfo()
        {
            // Arrange
            var dateTime = DateTime.UtcNow.AddHours(-1);

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapProOptions);

            // Act
#pragma warning disable CS0618 // Tests the obsolete One Call API 2.5
            var oneCallWeatherInfo = await openWeatherMapService.GetWeatherOneCallHistoricAsync(Latitude, Longitude, dateTime);
#pragma warning restore CS0618

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(oneCallWeatherInfo, this.dumpOptions));

            oneCallWeatherInfo.Should().NotBeNull();
            oneCallWeatherInfo.CurrentWeather.Should().NotBeNull();
            oneCallWeatherInfo.HourlyForecasts.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetAirPollutionAsync_ValidCoordinates_ReturnsAirPollutionInfo()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var airPollutionInfo = await openWeatherMapService.GetAirPollutionAsync(Latitude, Longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(airPollutionInfo, this.dumpOptions));

            airPollutionInfo.Should().NotBeNull();
            airPollutionInfo.Items.Should().NotBeEmpty();
        }
    }
}
