using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using OpenWeatherMap.Models;
using OpenWeatherMap.Tests.Logging;
using OpenWeatherMap.Tests.Testdata;
using Xunit;
using Xunit.Abstractions;

namespace OpenWeatherMap.Tests
{
    public class OpenWeatherMapServiceIntegrationTests
    {
        private readonly ILogger<OpenWeatherMapService> logger;
        private readonly IOpenWeatherMapConfiguration openWeatherMapConfiguration;
        private readonly ITestOutputHelper testOutputHelper;
        private readonly DumpOptions dumpOptions;

        public OpenWeatherMapServiceIntegrationTests(ITestOutputHelper testOutputHelper)
        {
            this.logger = new TestOutputHelperLogger<OpenWeatherMapService>(testOutputHelper);
            this.openWeatherMapConfiguration = AppSettings.GetApiConfiguration("OpenWeatherMap_PRO");
            this.testOutputHelper = testOutputHelper;


            this.dumpOptions = new DumpOptions
            {
                DumpStyle = DumpStyle.CSharp,
                SetPropertiesOnly = true
            };

            this.dumpOptions.CustomInstanceFormatters.AddFormatter<Temperature>(t => $"new Temperature({t.Value}, {nameof(TemperatureUnit)}.{t.Unit})");
            this.dumpOptions.CustomInstanceFormatters.AddFormatter<Pressure>(p => $"new Pressure({p.Value})");
            this.dumpOptions.CustomInstanceFormatters.AddFormatter<Humidity>(h => $"new Humidity({h.Value})");
            this.dumpOptions.CustomInstanceFormatters.AddFormatter<UVIndex>(uvi => $"new UVIndex({uvi.Value})");
        }

        [Theory]
        [InlineData(null, 96)]
        [InlineData(24, 24)]
        public async Task ShouldGetWeatherForecast4Async(int? count, int expectedCount)
        {
            // Arrange
            var latitude = 47.0907124d;
            var longitude = 8.0559381d;

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapConfiguration);

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

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapConfiguration);

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

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapConfiguration);

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

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapConfiguration);

            // Act
            var oneCallWeatherInfo = await openWeatherMapService.GetWeatherOneCallAsync(latitude, longitude, oneCallOptions);

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

            IOpenWeatherMapService openWeatherMapService = new OpenWeatherMapService(this.logger, this.openWeatherMapConfiguration);

            // Act
            var airPollutionInfo = await openWeatherMapService.GetAirPollutionAsync(latitude, longitude);

            // Assert
            this.testOutputHelper.WriteLine(ObjectDumper.Dump(airPollutionInfo, DumpStyle.CSharp));

            airPollutionInfo.Should().NotBeNull();
        }
    }
}