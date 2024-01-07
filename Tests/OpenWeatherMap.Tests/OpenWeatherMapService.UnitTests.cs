using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using Moq.Contrib.HttpClient;
using OpenWeatherMap.Tests.Logging;
using OpenWeatherMap.Tests.Testdata;
using Xunit;
using Xunit.Abstractions;

namespace OpenWeatherMap.Tests
{
    public class OpenWeatherMapServiceUnitTests
    {
        private readonly AutoMocker autoMocker;
        private readonly Mock<HttpMessageHandler> httpMessageHandlerMock;
        private readonly IOpenWeatherMapJsonSerializer jsonSerializer;

        public OpenWeatherMapServiceUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.autoMocker = new AutoMocker();

            this.httpMessageHandlerMock = this.autoMocker.GetMock<HttpMessageHandler>();
            this.autoMocker.Use(this.httpMessageHandlerMock.CreateClient());

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

            this.jsonSerializer = new OpenWeatherMapJsonSerializer("metric");
        }

        [Fact]
        public async Task ShouldGetCurrentWeatherAsync()
        {
            // Arrange
            var latitude = 1.1111111111d;
            var longitude = 1.2222222222d;

            this.httpMessageHandlerMock.SetupRequest(HttpMethod.Get, r => r.RequestUri.LocalPath == "/data/2.5/weather")
                .ReturnsResponse(WeatherInfos.GetTestWeatherInfoJson(this.jsonSerializer), "application/json");

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var weatherInfo = await openWeatherMapService.GetCurrentWeatherAsync(latitude, longitude);

            // Assert
            weatherInfo.Should().NotBeNull();

            var expectedWeatherInfo = WeatherInfos.GetTestWeatherInfo();
            weatherInfo.Should().BeEquivalentTo(expectedWeatherInfo);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/2.5/weather?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [ClassData(typeof(OneCallTestData))]
        public async Task ShouldGetWeatherOneCallAsync(OneCallOptions oneCallOptions, string expectedUri)
        {
            // Arrange
            var latitude = 1.1111111111d;
            var longitude = 1.2222222222d;

            this.httpMessageHandlerMock.SetupRequest(HttpMethod.Get, r => r.RequestUri.LocalPath == "/data/2.5/onecall")
                .ReturnsResponse(OneCallWeatherInfos.GetTestWeatherInfoJson(this.jsonSerializer), "application/json");

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var oneCallWeatherInfo = await openWeatherMapService.GetWeatherOneCallAsync(latitude, longitude, oneCallOptions);

            // Assert
            oneCallWeatherInfo.Should().NotBeNull();

            var expectedWeatherInfo = OneCallWeatherInfos.GetTestWeatherInfo();
            oneCallWeatherInfo.Should().BeEquivalentTo(expectedWeatherInfo);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                expectedUri,
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        public class OneCallTestData : TheoryData<OneCallOptions, string>
        {
            public OneCallTestData()
            {
                this.Add(
                    OneCallOptions.Default,
                    "https://api.openweathermap.org:443/data/2.5/onecall?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey");

                this.Add(new OneCallOptions
                {
                    IncludeCurrentWeather = false,
                    IncludeMinutelyForecasts = false,
                    IncludeHourlyForecasts = false,
                    IncludeDailyForecasts = true,
                },
                "https://api.openweathermap.org:443/data/2.5/onecall?lat=1.1111&lon=1.2222&exclude=current,minutely,hourly&units=metric&lang=en&appid=apikey");
            }
        }

        [Fact]
        public async Task ShouldGetAirPollutionAsync()
        {
            // Arrange
            var latitude = 1.1111111111d;
            var longitude = 1.2222222222d;

            this.httpMessageHandlerMock.SetupRequest(HttpMethod.Get, r => r.RequestUri.LocalPath == "/data/2.5/air_pollution")
                .ReturnsResponse(AirPollutionInfos.GetTestAirPollutionInfoJson(), "application/json");

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var airPollutionInfo = await openWeatherMapService.GetAirPollutionAsync(latitude, longitude);

            // Assert
            airPollutionInfo.Should().NotBeNull();

            var expectedAirPollutionInfo = AirPollutionInfos.GetTestAirPollutionInfo();
            airPollutionInfo.Should().BeEquivalentTo(expectedAirPollutionInfo);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org:443/data/2.5/air_pollution?lat=1.1111&lon=1.2222&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }
    }
}