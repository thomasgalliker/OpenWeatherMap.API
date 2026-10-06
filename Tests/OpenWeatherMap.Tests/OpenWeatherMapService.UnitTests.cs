using System.Text.Json.Nodes;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using Moq.Contrib.HttpClient;
using OpenWeatherMap.Tests.Logging;
using OpenWeatherMap.Tests.Testdata;
using Xunit;
using Xunit.Abstractions;
using MockHttpMessageHandlerExtensions = Moq.Contrib.HttpClient.MockHttpMessageHandlerExtensions;

namespace OpenWeatherMap.Tests
{
    [Trait(Traits.Category, Traits.UnitTests)]
    public class OpenWeatherMapServiceUnitTests
    {
        private const double Latitude = 1.1111111111d;
        private const double Longitude = 1.2222222222d;
        private const int ExpectedCityId = 2659685;
        private const string ExpectedCityName = "Menznau";

        private readonly AutoMocker autoMocker;
        private readonly Mock<HttpMessageHandler> httpMessageHandlerMock;

        public OpenWeatherMapServiceUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.autoMocker = new AutoMocker();

            this.httpMessageHandlerMock = this.autoMocker.GetMock<HttpMessageHandler>();
            this.autoMocker.Use(MockHttpMessageHandlerExtensions.CreateClient(this.httpMessageHandlerMock));

            this.autoMocker.Use<ILogger<OpenWeatherMapService>>(new TestOutputHelperLogger<OpenWeatherMapService>(testOutputHelper));

            var openWeatherMapOptionsMock = this.autoMocker.GetMock<OpenWeatherMapOptions>();
            openWeatherMapOptionsMock.SetupGet(c => c.ApiEndpoint)
                .Returns("https://api.openweathermap.org");
            openWeatherMapOptionsMock.SetupGet(c => c.Language)
                .Returns("en");
            openWeatherMapOptionsMock.SetupGet(c => c.ApiKey)
                .Returns("apikey");
            openWeatherMapOptionsMock.SetupGet(c => c.UnitSystem)
                .Returns("metric");
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_ValidCoordinates_ReturnsWeatherInfo()
        {
            // Arrange
            this.SetupResponse("/data/2.5/weather", Responses.GetJson(Responses.CurrentWeather));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var weatherInfo = await openWeatherMapService.GetCurrentWeatherAsync(Latitude, Longitude);

            // Assert
            weatherInfo.Should().NotBeNull();
            weatherInfo.CityId.Should().Be(ExpectedCityId);
            weatherInfo.CityName.Should().Be(ExpectedCityName);
            weatherInfo.Date.Should().BeAfter(DateTime.MinValue);
            weatherInfo.Weather.Should().NotBeEmpty();
            weatherInfo.Main.Should().NotBeNull();

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/2.5/weather?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, 96, "https://api.openweathermap.org/data/2.5/forecast/hourly?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey")]
        [InlineData(24, 24, "https://api.openweathermap.org/data/2.5/forecast/hourly?lat=1.1111&lon=1.2222&units=metric&lang=en&cnt=24&appid=apikey")]
        public async Task GetWeatherForecast4Async_WithCount_ReturnsHourlyForecast(int? count, int expectedCount, string expectedUri)
        {
            // Arrange
            this.SetupResponse("/data/2.5/forecast/hourly", GetForecastJson(Responses.ForecastHourly, count));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var weatherForecast = await openWeatherMapService.GetWeatherForecast4Async(Latitude, Longitude, count);

            // Assert
            weatherForecast.Should().NotBeNull();
            weatherForecast.Count.Should().Be(expectedCount);
            weatherForecast.Items.Should().HaveCount(expectedCount);
            weatherForecast.City.Id.Should().Be(ExpectedCityId);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get, expectedUri, Times.Once());
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherForecast5Async_ValidCoordinates_ReturnsForecast()
        {
            // Arrange
            this.SetupResponse("/data/2.5/forecast", Responses.GetJson(Responses.Forecast5));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var weatherForecast = await openWeatherMapService.GetWeatherForecast5Async(Latitude, Longitude);

            // Assert
            weatherForecast.Should().NotBeNull();
            weatherForecast.Count.Should().Be(40);
            weatherForecast.Items.Should().HaveCount(40);
            weatherForecast.City.Id.Should().Be(ExpectedCityId);
            weatherForecast.City.Name.Should().Be(ExpectedCityName);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/2.5/forecast?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherForecastDailyAsync_ValidCoordinates_ReturnsDailyForecast()
        {
            // Arrange
            this.SetupResponse("/data/2.5/forecast/daily", Responses.GetJson(Responses.ForecastDaily));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var weatherForecast = await openWeatherMapService.GetWeatherForecastDailyAsync(Latitude, Longitude);

            // Assert
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

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/2.5/forecast/daily?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [ClassData(typeof(OneCallTestData))]
        public async Task GetWeatherOneCallAsync_WithOptions_ReturnsOneCallWeatherInfo(OneCallOptions oneCallOptions, string expectedUri)
        {
            // Arrange
            this.SetupResponse("/data/2.5/onecall", Responses.GetJson(Responses.OneCall));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
#pragma warning disable CS0618 // Tests the obsolete One Call API 2.5
            var oneCallWeatherInfo = await openWeatherMapService.GetWeatherOneCallAsync(Latitude, Longitude, oneCallOptions);
#pragma warning restore CS0618

            // Assert
            oneCallWeatherInfo.Should().NotBeNull();
            oneCallWeatherInfo.Timezone.Should().Be("Europe/Zurich");
            oneCallWeatherInfo.CurrentWeather.Should().NotBeNull();
            oneCallWeatherInfo.MinutelyForecasts.Should().HaveCount(61);
            oneCallWeatherInfo.HourlyForecasts.Should().HaveCount(48);
            oneCallWeatherInfo.DailyForecasts.Should().HaveCount(8);
            oneCallWeatherInfo.Alerts.Should().ContainSingle();

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get, expectedUri, Times.Once());
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        public class OneCallTestData : TheoryData<OneCallOptions, string>
        {
            public OneCallTestData()
            {
                this.Add(
                    OneCallOptions.Default,
                    "https://api.openweathermap.org/data/2.5/onecall?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey");

                this.Add(new OneCallOptions
                {
                    IncludeCurrentWeather = false,
                    IncludeMinutelyForecasts = false,
                    IncludeHourlyForecasts = false,
                    IncludeDailyForecasts = true,
                },
                "https://api.openweathermap.org/data/2.5/onecall?lat=1.1111&lon=1.2222&exclude=current,minutely,hourly&units=metric&lang=en&appid=apikey");
            }
        }

        [Fact]
        public async Task GetWeatherOneCallHistoricAsync_ValidDateTime_ReturnsOneCallWeatherInfo()
        {
            // Arrange
            var dateTime = new DateTime(2026, 10, 6, 12, 0, 0, DateTimeKind.Utc);

            this.SetupResponse("/data/2.5/onecall/timemachine", Responses.GetJson(Responses.OneCallTimemachine));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
#pragma warning disable CS0618 // Tests the obsolete One Call API 2.5
            var oneCallWeatherInfo = await openWeatherMapService.GetWeatherOneCallHistoricAsync(Latitude, Longitude, dateTime);
#pragma warning restore CS0618

            // Assert
            oneCallWeatherInfo.Should().NotBeNull();
            oneCallWeatherInfo.CurrentWeather.DateTime.Should().Be(dateTime);
            oneCallWeatherInfo.HourlyForecasts.Should().HaveCount(24);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/2.5/onecall/timemachine?lat=1.1111&lon=1.2222&dt=1791288000&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAirPollutionAsync_ValidCoordinates_ReturnsAirPollutionInfo()
        {
            // Arrange
            this.SetupResponse("/data/2.5/air_pollution", Responses.GetJson(Responses.AirPollution));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var airPollutionInfo = await openWeatherMapService.GetAirPollutionAsync(Latitude, Longitude);

            // Assert
            airPollutionInfo.Should().NotBeNull();
            airPollutionInfo.Coordinates.Latitude.Should().Be(47.0907d);
            airPollutionInfo.Items.Should().ContainSingle();

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/2.5/air_pollution?lat=1.1111&lon=1.2222&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        private void SetupResponse(string localPath, string responseJson)
        {
            this.httpMessageHandlerMock.SetupRequest(HttpMethod.Get, r => r.RequestUri!.LocalPath == localPath)
                .ReturnsResponse(responseJson, "application/json");
        }

        /// <summary>
        /// Returns the recorded forecast response limited to <paramref name="count"/> items,
        /// the same way the API does when query parameter cnt is set.
        /// </summary>
        private static string GetForecastJson(string fileName, int? count)
        {
            var json = Responses.GetJson(fileName);
            if (count is not { } itemCount)
            {
                return json;
            }

            var forecast = JsonNode.Parse(json)!.AsObject();
            var items = forecast["list"]!.AsArray()
                .Take(itemCount)
                .Select(i => i!.DeepClone())
                .ToArray();

            forecast["list"] = new JsonArray(items);
            forecast["cnt"] = itemCount;
            return forecast.ToJsonString();
        }
    }
}
