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

        /// <summary>
        /// Skip reason for tests which require a One Call API 4.0 subscription.
        /// Set to null to run them (requires a valid OpenWeatherMap:ApiKey with a "One Call by Call" subscription).
        /// </summary>
        private const string? OneCallSubscriptionSkipReason = "Requires an OpenWeatherMap 'One Call by Call' subscription";

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

        [Fact(Skip = OneCallSubscriptionSkipReason)]
        public async Task GetWeatherOneCallCurrentAsync_ValidCoordinates_ReturnsCurrentWeather()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var timeline = await openWeatherMapService.GetWeatherOneCallCurrentAsync(Latitude, Longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(timeline, this.dumpOptions));

            timeline.Should().NotBeNull();
            timeline.Data.Should().ContainSingle();
        }

        [Fact(Skip = OneCallSubscriptionSkipReason)]
        public async Task GetWeatherOneCallMinutelyAsync_ValidCoordinates_ReturnsMinutelyTimeline()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var timeline = await openWeatherMapService.GetWeatherOneCallMinutelyAsync(Latitude, Longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(timeline, this.dumpOptions));

            timeline.Data.Should().NotBeEmpty();
        }

        [Fact(Skip = OneCallSubscriptionSkipReason)]
        public async Task GetWeatherOneCall15MinutesAsync_ValidCoordinates_Returns15MinutesTimeline()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var timeline = await openWeatherMapService.GetWeatherOneCall15MinutesAsync(Latitude, Longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(timeline, this.dumpOptions));

            timeline.Data.Should().NotBeEmpty();
        }

        [Fact(Skip = OneCallSubscriptionSkipReason)]
        public async Task GetWeatherOneCallHourlyAsync_StartInThePast_ReturnsHistoricalTimelineWithNextPage()
        {
            // Arrange
            var start = DateTime.UtcNow.Date.AddDays(-1);

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var timeline = await openWeatherMapService.GetWeatherOneCallHourlyAsync(Latitude, Longitude, start);
            var nextPage = await openWeatherMapService.GetWeatherOneCallNextPageAsync(timeline);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(timeline, this.dumpOptions));

            timeline.Data.Should().NotBeEmpty();
            timeline.Data.First().DateTime.Should().BeOnOrAfter(start);
            nextPage.Should().NotBeNull();
            nextPage!.Data.First().DateTime.Should().BeAfter(timeline.Data.Last().DateTime);
        }

        [Fact(Skip = OneCallSubscriptionSkipReason)]
        public async Task GetWeatherOneCallDailyAsync_ValidCoordinates_ReturnsDailyTimeline()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var timeline = await openWeatherMapService.GetWeatherOneCallDailyAsync(Latitude, Longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(timeline, this.dumpOptions));

            timeline.Data.Should().NotBeEmpty();
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

        [Fact]
        public async Task GetAirPollutionForecastAsync_ValidCoordinates_ReturnsAirPollutionInfo()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var airPollutionInfo = await openWeatherMapService.GetAirPollutionForecastAsync(Latitude, Longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(airPollutionInfo, this.dumpOptions));

            airPollutionInfo.Should().NotBeNull();
            airPollutionInfo.Items.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetAirPollutionHistoryAsync_ValidPeriod_ReturnsAirPollutionInfo()
        {
            // Arrange
            var end = DateTime.UtcNow.Date;
            var start = end.AddHours(-3);

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var airPollutionInfo = await openWeatherMapService.GetAirPollutionHistoryAsync(Latitude, Longitude, start, end);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(airPollutionInfo, this.dumpOptions));

            airPollutionInfo.Should().NotBeNull();
            airPollutionInfo.Items.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetLocationsByNameAsync_ValidQuery_ReturnsLocations()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var locations = await openWeatherMapService.GetLocationsByNameAsync("Menznau,CH", 5);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(locations, this.dumpOptions));

            locations.Should().NotBeEmpty();
            locations.Should().AllSatisfy(l => l.Country.Should().Be("CH"));
        }

        [Fact]
        public async Task GetLocationByZipCodeAsync_ValidZipCode_ReturnsZipCodeLocation()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var zipCodeLocation = await openWeatherMapService.GetLocationByZipCodeAsync("6122", "CH");

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(zipCodeLocation, this.dumpOptions));

            zipCodeLocation.Should().NotBeNull();
            zipCodeLocation.ZipCode.Should().Be("6122");
            zipCodeLocation.Country.Should().Be("CH");
        }

        [Fact]
        public async Task GetLocationsByCoordinatesAsync_ValidCoordinates_ReturnsLocations()
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var locations = await openWeatherMapService.GetLocationsByCoordinatesAsync(Latitude, Longitude, 1);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(locations, this.dumpOptions));

            locations.Should().ContainSingle()
                .Which.Name.Should().NotBeNullOrEmpty();
        }
    }
}
