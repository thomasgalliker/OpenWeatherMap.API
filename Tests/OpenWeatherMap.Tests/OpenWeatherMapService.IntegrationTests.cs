using System;
using System.Threading.Tasks;
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
    public class OpenWeatherMapServiceIntegrationTests
    {
        private readonly ILogger<OpenWeatherMapService> logger;
        private readonly OpenWeatherMapOptions openWeatherMapOptions;
        private readonly ITestOutputHelper testOutputHelper;
        private readonly DumpOptions dumpOptions;

        public OpenWeatherMapServiceIntegrationTests(ITestOutputHelper testOutputHelper)
        {
            this.logger = new TestOutputHelperLogger<OpenWeatherMapService>(testOutputHelper);
            this.openWeatherMapOptions = AppSettings.GetApiConfiguration("OpenWeatherMap_PRO");
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

        [Theory]
        [InlineData(null, 96)]
        [InlineData(24, 24)]
        public async Task ShouldGetWeatherForecast4Async(int? count, int expectedCount)
        {
            // Arrange
            var latitude = 47.0907124d;
            var longitude = 8.0559381d;

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var weatherForecast = await openWeatherMapService.GetWeatherForecast4Async(latitude, longitude, count);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(weatherForecast, this.dumpOptions));

            weatherForecast.Should().NotBeNull();
            weatherForecast.Count.Should().Be(expectedCount);
            weatherForecast.Items.Should().HaveCount(expectedCount);
        }

        [Fact]
        public async Task ShouldGetWeatherForecast5Async()
        {
            // Arrange
            var latitude = 47.0907124d;
            var longitude = 8.0559381d;

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var weatherForecast = await openWeatherMapService.GetWeatherForecast5Async(latitude, longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(weatherForecast, this.dumpOptions));

            weatherForecast.Should().NotBeNull();
            weatherForecast.Count.Should().Be(40);
            weatherForecast.Items.Should().HaveCount(40);
        }

        [Fact]
        public async Task ShouldGetWeatherForecast16Async()
        {
            // Arrange
            var latitude = 47.0907124d;
            var longitude = 8.0559381d;

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var weatherForecast = await openWeatherMapService.GetWeatherForecastDailyAsync(latitude, longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(weatherForecast, this.dumpOptions));

            weatherForecast.Should().NotBeNull();
            weatherForecast.Count.Should().Be(7);
            weatherForecast.Items.Should().HaveCount(7);
        }

        [Fact]
        public async Task ShouldGetWeatherOneCallAsync()
        {
            // Arrange
            var latitude = 47.0907124d;
            var longitude = 8.0559381d;

            var oneCallOptions = new OneCallOptions
            {
                IncludeCurrentWeather = true,
                IncludeDailyForecasts = true,
                IncludeMinutelyForecasts = true,
                IncludeHourlyForecasts = true,
            };

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var oneCallWeatherInfo = await openWeatherMapService.GetWeatherOneCallAsync(latitude, longitude, oneCallOptions);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(oneCallWeatherInfo, this.dumpOptions));

            oneCallWeatherInfo.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldGetWeatherOneCallHistoricAsync()
        {
            // Arrange
            var latitude = 47.0907124d;
            var longitude = 8.0559381d;

            var dateTime = DateTime.Now;

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var oneCallWeatherInfo = await openWeatherMapService.GetWeatherOneCallHistoricAsync(latitude, longitude, dateTime);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(oneCallWeatherInfo, this.dumpOptions));

            oneCallWeatherInfo.Should().NotBeNull();
        }

        [Fact]
        public async Task ShouldGetAirPollutionAsync()
        {
            // Arrange
            var latitude = 47.0907124d;
            var longitude = 8.0559381d;

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapOptions);

            // Act
            var airPollutionInfo = await openWeatherMapService.GetAirPollutionAsync(latitude, longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(airPollutionInfo, this.dumpOptions));

            airPollutionInfo.Should().NotBeNull();
        }
    }
}