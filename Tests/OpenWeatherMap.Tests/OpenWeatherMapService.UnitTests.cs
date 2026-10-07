using System.Text.Json.Nodes;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using Moq.Contrib.HttpClient;
using OpenWeatherMap.Models;
using OpenWeatherMap.Tests.Logging;
using OpenWeatherMap.Tests.Testdata;
using UnitsNet;
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
        [InlineData(-90.1d, 0d, "latitude")]
        [InlineData(90.1d, 0d, "latitude")]
        [InlineData(0d, -180.1d, "longitude")]
        [InlineData(0d, 180.1d, "longitude")]
        public async Task GetCurrentWeatherAsync_InvalidCoordinates_ThrowsArgumentOutOfRangeException(double latitude, double longitude, string expectedParamName)
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetCurrentWeatherAsync(latitude, longitude);

            // Assert
            await action.Should().ThrowAsync<ArgumentOutOfRangeException>().WithParameterName(expectedParamName);
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, 96,"https://api.openweathermap.org/data/2.5/forecast/hourly?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey")]
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

        [Fact]
        public async Task GetWeatherOneCallCurrentAsync_ValidCoordinates_ReturnsCurrentWeather()
        {
            // Arrange
            this.SetupResponse("/data/4.0/onecall/current", Responses.GetJson(Responses.OneCallCurrent));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var timeline = await openWeatherMapService.GetWeatherOneCallCurrentAsync(Latitude, Longitude);

            // Assert
            timeline.Should().NotBeNull();
            timeline.Timezone.Should().Be("Europe/Zurich");
            timeline.Next.Should().BeNull();
            var currentWeather = timeline.Data.Should().ContainSingle().Subject;
            currentWeather.Temperature.Should().Be(Temperature.FromDegreesCelsius(21.28d));
            currentWeather.Rain!.Last1h.Should().NotBeNull();
            currentWeather.Alerts.Should().HaveCount(2);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/4.0/onecall/current?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCallMinutelyAsync_ValidCoordinates_ReturnsMinutelyTimeline()
        {
            // Arrange
            this.SetupResponse("/data/4.0/onecall/timeline/1min", Responses.GetJson(Responses.OneCallMinutely));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var timeline = await openWeatherMapService.GetWeatherOneCallMinutelyAsync(Latitude, Longitude);

            // Assert
            timeline.Data.Should().HaveCount(60);
            timeline.Data.First().Alerts.Should().HaveCount(2);
            timeline.Data.Last().Alerts.Should().BeEmpty();

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/4.0/onecall/timeline/1min?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCall15MinutesAsync_ValidCoordinates_Returns15MinutesTimeline()
        {
            // Arrange
            this.SetupResponse("/data/4.0/onecall/timeline/15min", Responses.GetJson(Responses.OneCall15Minutes));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var timeline = await openWeatherMapService.GetWeatherOneCall15MinutesAsync(Latitude, Longitude);

            // Assert
            timeline.Data.Should().HaveCount(50);
            timeline.Data.Should().BeInAscendingOrder(d => d.DateTime);
            timeline.Data.First().Rain!.Last1h.Should().NotBeNull();
            timeline.Previous.Should().BeNull();
            timeline.Next.Should().NotBeNullOrEmpty();

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/4.0/onecall/timeline/15min?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCallHourlyAsync_WithStart_RequestsHourlyTimelineFromStart()
        {
            // Arrange
            var start = new DateTime(2026, 10, 6, 12, 0, 0, DateTimeKind.Utc);

            this.SetupResponse("/data/4.0/onecall/timeline/1h", Responses.GetJson(Responses.OneCallHourly));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var timeline = await openWeatherMapService.GetWeatherOneCallHourlyAsync(Latitude, Longitude, start);

            // Assert
            timeline.Data.Should().HaveCount(20);
            timeline.Data.First().DateTime.Should().Be(start);
            timeline.Previous.Should().NotBeNullOrEmpty();
            timeline.Next.Should().NotBeNullOrEmpty();

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/4.0/onecall/timeline/1h?lat=1.1111&lon=1.2222&start=1791288000&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCallDailyAsync_ValidCoordinates_ReturnsDailyTimeline()
        {
            // Arrange
            this.SetupResponse("/data/4.0/onecall/timeline/1day", Responses.GetJson(Responses.OneCallDaily));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var timeline = await openWeatherMapService.GetWeatherOneCallDailyAsync(Latitude, Longitude);

            // Assert
            timeline.Data.Should().HaveCount(10);
            timeline.Data.Should().OnlyContain(d => d.Temperature != null && d.FeelsLike != null);
            timeline.Data.ElementAt(0).Alerts.Should().HaveCount(2);
            timeline.Data.ElementAt(1).Rain.Should().Be(Length.FromMillimeters(2.5d));
            timeline.Data.ElementAt(2).Rain.Should().Be(Length.FromMillimeters(0.8d));

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/4.0/onecall/timeline/1day?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCallDailyAsync_StartBefore1979_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var start = new DateTime(1978, 12, 31, 23, 59, 59, DateTimeKind.Utc);

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetWeatherOneCallDailyAsync(Latitude, Longitude, start);

            // Assert
            await action.Should().ThrowAsync<ArgumentOutOfRangeException>().WithParameterName("start");
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCallNextPageAsync_TimelineWithNext_RequestsNextPage()
        {
            // Arrange
            this.SetupResponse("/data/4.0/onecall/timeline/1h", Responses.GetJson(Responses.OneCallHourly));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();
            var timeline = await openWeatherMapService.GetWeatherOneCallHourlyAsync(Latitude, Longitude);

            // Act
            var nextPage = await openWeatherMapService.GetWeatherOneCallNextPageAsync(timeline);

            // Assert
            nextPage.Should().NotBeNull();
            nextPage!.Data.Should().HaveCount(20);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/4.0/onecall/timeline/1h?lat=47.0907&lon=8.0559&start=1791360000&units=metric&lang=en&appid=apikey",
                Times.Once());
        }

        [Fact]
        public async Task GetWeatherOneCallPreviousPageAsync_TimelineWithPrevious_RequestsPreviousPage()
        {
            // Arrange
            this.SetupResponse("/data/4.0/onecall/timeline/1day", Responses.GetJson(Responses.OneCallDaily));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();
            var timeline = await openWeatherMapService.GetWeatherOneCallDailyAsync(Latitude, Longitude);

            // Act
            var previousPage = await openWeatherMapService.GetWeatherOneCallPreviousPageAsync(timeline);

            // Assert
            previousPage.Should().NotBeNull();

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/4.0/onecall/timeline/1day?cnt=10&lat=47.0907&lon=8.0559&start=1790424000&units=metric&lang=en&appid=apikey",
                Times.Once());
        }

        [Fact]
        public async Task GetWeatherOneCallNextPageAsync_TimelineWithoutNext_ReturnsNull()
        {
            // Arrange
            var timeline = new OneCallTimeline<TimelineWeatherForecast>();

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var nextPage = await openWeatherMapService.GetWeatherOneCallNextPageAsync(timeline);

            // Assert
            nextPage.Should().BeNull();
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData("https://evil.example.com/data/4.0/onecall/timeline/1h?lat=1&lon=2")]
        [InlineData("https://api.openweathermap.org/data/2.5/weather?lat=1&lon=2")]
        public async Task GetWeatherOneCallNextPageAsync_ForeignPageUrl_ThrowsInvalidOperationException(string pageUrl)
        {
            // Arrange
            var timeline = new OneCallTimeline<TimelineWeatherForecast> { Next = pageUrl };

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetWeatherOneCallNextPageAsync(timeline);

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>();
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCallAlertAsync_ValidAlertId_ReturnsAlertInfo()
        {
            // Arrange
            const string alertId = "2.49.0.0.756.0.CH.20261006120000.MeteoSwiss:TS01:7c1f0e2a";

            this.httpMessageHandlerMock.SetupRequest(HttpMethod.Get, r => r.RequestUri!.AbsolutePath.StartsWith("/data/4.0/onecall/alert/"))
                .ReturnsResponse(Responses.GetJson(Responses.OneCallAlert), "application/json");

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var alertInfo = await openWeatherMapService.GetWeatherOneCallAlertAsync(alertId);

            // Assert
            alertInfo.Should().NotBeNull();
            alertInfo.Id.Should().Be(alertId);
            alertInfo.SenderName.Should().Be("MeteoSwiss");
            alertInfo.StartTime.Should().BeBefore(alertInfo.EndTime);
            alertInfo.Descriptions.Should().HaveCount(2);
            alertInfo.Descriptions.Should().Contain(d => d.Language == "en-GB");
            alertInfo.Tags.Should().ContainSingle();

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                r => r.RequestUri!.AbsoluteUri == "https://api.openweathermap.org/data/4.0/onecall/alert/2.49.0.0.756.0.CH.20261006120000.MeteoSwiss%3ATS01%3A7c1f0e2a?appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task GetWeatherOneCallAlertAsync_EmptyAlertId_ThrowsArgumentException(string? alertId)
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetWeatherOneCallAlertAsync(alertId!);

            // Assert
            await action.Should().ThrowAsync<ArgumentException>().WithParameterName("alertId");
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherIconAsync_DefaultWeatherIconMapping_ReturnsIconFromOpenWeatherMap()
        {
            // Arrange
            var weatherCondition = new WeatherCondition { Id = WeatherConditionCode.Clear, IconId = "01d" };
            var iconBytes = new byte[] { 0x89, 0x50, 0x4E, 0x47 };

            var iconRequestSetup = this.httpMessageHandlerMock.SetupRequest(HttpMethod.Get, "https://openweathermap.org/img/wn/01d@2x.png");
            MockHttpMessageHandlerExtensions.ReturnsResponse(iconRequestSetup, iconBytes, "image/png");

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var iconStream = await openWeatherMapService.GetWeatherIconAsync(weatherCondition);

            // Assert
            using var memoryStream = new MemoryStream();
            await iconStream.CopyToAsync(memoryStream);
            memoryStream.ToArray().Should().Equal(iconBytes);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get, "https://openweathermap.org/img/wn/01d@2x.png", Times.Once());
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherIconAsync_CustomWeatherIconMapping_ReturnsIconFromMapping()
        {
            // Arrange
            var weatherCondition = new WeatherCondition { Id = WeatherConditionCode.Clear, IconId = "01d" };
            var iconStream = new MemoryStream();

            var weatherIconMappingMock = new Mock<IWeatherIconMapping>();
            weatherIconMappingMock.Setup(m => m.GetIconAsync(weatherCondition))
                .ReturnsAsync(iconStream);

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var result = await openWeatherMapService.GetWeatherIconAsync(weatherCondition, weatherIconMappingMock.Object);

            // Assert
            result.Should().BeSameAs(iconStream);
            weatherIconMappingMock.Verify(m => m.GetIconAsync(weatherCondition), Times.Once());
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

        [Fact]
        public async Task GetAirPollutionForecastAsync_ValidCoordinates_ReturnsAirPollutionInfo()
        {
            // Arrange
            this.SetupResponse("/data/2.5/air_pollution/forecast", Responses.GetJson(Responses.AirPollutionForecast));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var airPollutionInfo = await openWeatherMapService.GetAirPollutionForecastAsync(Latitude, Longitude);

            // Assert
            airPollutionInfo.Should().NotBeNull();
            airPollutionInfo.Items.Should().HaveCount(4);
            airPollutionInfo.Items.Should().BeInAscendingOrder(i => i.DateTime);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/2.5/air_pollution/forecast?lat=1.1111&lon=1.2222&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAirPollutionHistoryAsync_ValidPeriod_ReturnsAirPollutionInfo()
        {
            // Arrange
            var start = new DateTime(2026, 10, 5, 0, 0, 0, DateTimeKind.Utc);
            var end = new DateTime(2026, 10, 5, 3, 0, 0, DateTimeKind.Utc);

            this.SetupResponse("/data/2.5/air_pollution/history", Responses.GetJson(Responses.AirPollutionHistory));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var airPollutionInfo = await openWeatherMapService.GetAirPollutionHistoryAsync(Latitude, Longitude, start, end);

            // Assert
            airPollutionInfo.Should().NotBeNull();
            airPollutionInfo.Items.Should().HaveCount(3);
            airPollutionInfo.Items.First().DateTime.Should().Be(start);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/2.5/air_pollution/history?lat=1.1111&lon=1.2222&start=1791158400&end=1791169200&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetAirPollutionHistoryAsync_StartBeforeMinDate_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var start = new DateTime(2020, 11, 26, 23, 59, 59, DateTimeKind.Utc);
            var end = new DateTime(2020, 11, 28, 0, 0, 0, DateTimeKind.Utc);

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetAirPollutionHistoryAsync(Latitude, Longitude, start, end);

            // Assert
            await action.Should().ThrowAsync<ArgumentOutOfRangeException>().WithParameterName("start");
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetAirPollutionHistoryAsync_EndNotAfterStart_ThrowsArgumentOutOfRangeException(int endOffsetHours)
        {
            // Arrange
            var start = new DateTime(2026, 10, 5, 0, 0, 0, DateTimeKind.Utc);
            var end = start.AddHours(endOffsetHours);

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetAirPollutionHistoryAsync(Latitude, Longitude, start, end);

            // Assert
            await action.Should().ThrowAsync<ArgumentOutOfRangeException>().WithParameterName("end");
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetLocationsByNameAsync_ValidQuery_ReturnsLocations()
        {
            // Arrange
            this.SetupResponse("/geo/1.0/direct", Responses.GetJson(Responses.GeocodingDirect));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var locations = await openWeatherMapService.GetLocationsByNameAsync("Menznau,CH");

            // Assert
            var location = locations.Should().ContainSingle().Subject;
            location.Name.Should().Be(ExpectedCityName);
            location.LocalNames.Should().ContainKey("de");
            location.Latitude.Should().Be(47.0838106d);
            location.Longitude.Should().Be(8.040131d);
            location.Country.Should().Be("CH");
            location.State.Should().Be("Lucerne");

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/geo/1.0/direct?q=Menznau%2CCH&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetLocationsByNameAsync_WithLimit_RequestsLimit()
        {
            // Arrange
            this.SetupResponse("/geo/1.0/direct", Responses.GetJson(Responses.GeocodingDirect));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            await openWeatherMapService.GetLocationsByNameAsync("Menznau", 5);

            // Assert
            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/geo/1.0/direct?q=Menznau&limit=5&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetLocationsByNameAsync_EmptyQuery_ThrowsArgumentException(string? query)
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetLocationsByNameAsync(query!);

            // Assert
            await action.Should().ThrowAsync<ArgumentException>().WithParameterName("query");
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public async Task GetLocationsByNameAsync_InvalidLimit_ThrowsArgumentOutOfRangeException(int limit)
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetLocationsByNameAsync("Menznau", limit);

            // Assert
            await action.Should().ThrowAsync<ArgumentOutOfRangeException>().WithParameterName("limit");
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetLocationByZipCodeAsync_ValidZipCode_ReturnsZipCodeLocation()
        {
            // Arrange
            this.SetupResponse("/geo/1.0/zip", Responses.GetJson(Responses.GeocodingZip));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var zipCodeLocation = await openWeatherMapService.GetLocationByZipCodeAsync("6122", "CH");

            // Assert
            zipCodeLocation.Should().NotBeNull();
            zipCodeLocation.ZipCode.Should().Be("6122");
            zipCodeLocation.Name.Should().Be(ExpectedCityName);
            zipCodeLocation.Latitude.Should().Be(47.0775d);
            zipCodeLocation.Longitude.Should().Be(8.0373d);
            zipCodeLocation.Country.Should().Be("CH");

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/geo/1.0/zip?zip=6122,CH&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, "CH", "zipCode")]
        [InlineData("", "CH", "zipCode")]
        [InlineData("6122", null, "countryCode")]
        [InlineData("6122", "", "countryCode")]
        public async Task GetLocationByZipCodeAsync_EmptyParameter_ThrowsArgumentException(string? zipCode, string? countryCode, string expectedParamName)
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetLocationByZipCodeAsync(zipCode!, countryCode!);

            // Assert
            await action.Should().ThrowAsync<ArgumentException>().WithParameterName(expectedParamName);
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetLocationsByCoordinatesAsync_ValidCoordinates_ReturnsLocations()
        {
            // Arrange
            this.SetupResponse("/geo/1.0/reverse", Responses.GetJson(Responses.GeocodingReverse));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var locations = await openWeatherMapService.GetLocationsByCoordinatesAsync(Latitude, Longitude);

            // Assert
            locations.Should().ContainSingle()
                .Which.Name.Should().Be(ExpectedCityName);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/geo/1.0/reverse?lat=1.1111&lon=1.2222&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetLocationsByCoordinatesAsync_WithLimit_RequestsLimit()
        {
            // Arrange
            this.SetupResponse("/geo/1.0/reverse", Responses.GetJson(Responses.GeocodingReverse));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            await openWeatherMapService.GetLocationsByCoordinatesAsync(Latitude, Longitude, 1);

            // Assert
            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/geo/1.0/reverse?lat=1.1111&lon=1.2222&limit=1&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public async Task GetLocationsByCoordinatesAsync_InvalidLimit_ThrowsArgumentOutOfRangeException(int limit)
        {
            // Arrange
            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetLocationsByCoordinatesAsync(Latitude, Longitude, limit);

            // Assert
            await action.Should().ThrowAsync<ArgumentOutOfRangeException>().WithParameterName("limit");
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
