using System.Text.Json.Nodes;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using Moq.Contrib.HttpClient;
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

        [Theory]
        [ClassData(typeof(OneCallTestData))]
        public async Task GetWeatherOneCallAsync_WithOptions_ReturnsOneCallWeatherInfo(OneCallOptions oneCallOptions, string expectedUri)
        {
            // Arrange
            this.SetupResponse("/data/3.0/onecall", Responses.GetJson(Responses.OneCall));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var oneCallWeatherInfo = await openWeatherMapService.GetWeatherOneCallAsync(Latitude, Longitude, oneCallOptions);

            // Assert
            oneCallWeatherInfo.Should().NotBeNull();
            oneCallWeatherInfo.Timezone.Should().Be("Europe/Zurich");
            oneCallWeatherInfo.CurrentWeather.Should().NotBeNull();
            oneCallWeatherInfo.CurrentWeather.Rain!.Last1h.Should().NotBeNull();
            oneCallWeatherInfo.MinutelyForecasts.Should().HaveCount(61);
            oneCallWeatherInfo.HourlyForecasts.Should().HaveCount(48);
            oneCallWeatherInfo.HourlyForecasts.First().Rain!.Last1h.Should().NotBeNull();
            oneCallWeatherInfo.DailyForecasts.Should().HaveCount(8);
            oneCallWeatherInfo.DailyForecasts.Should().OnlyContain(d => !string.IsNullOrEmpty(d.Summary));
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
                    "https://api.openweathermap.org/data/3.0/onecall?lat=1.1111&lon=1.2222&units=metric&lang=en&appid=apikey");

                this.Add(new OneCallOptions
                {
                    IncludeCurrentWeather = false,
                    IncludeMinutelyForecasts = false,
                    IncludeHourlyForecasts = false,
                    IncludeDailyForecasts = true,
                },
                "https://api.openweathermap.org/data/3.0/onecall?lat=1.1111&lon=1.2222&exclude=current,minutely,hourly&units=metric&lang=en&appid=apikey");

                this.Add(new OneCallOptions
                {
                    IncludeAlerts = false,
                },
                "https://api.openweathermap.org/data/3.0/onecall?lat=1.1111&lon=1.2222&exclude=alerts&units=metric&lang=en&appid=apikey");
            }
        }

        [Fact]
        public async Task GetWeatherOneCallTimeMachineAsync_ValidDateTime_ReturnsOneCallTimeMachineInfo()
        {
            // Arrange
            var dateTime = new DateTime(2026, 10, 6, 12, 0, 0, DateTimeKind.Utc);

            this.SetupResponse("/data/3.0/onecall/timemachine", Responses.GetJson(Responses.OneCallTimeMachine));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var oneCallTimeMachineInfo = await openWeatherMapService.GetWeatherOneCallTimeMachineAsync(Latitude, Longitude, dateTime);

            // Assert
            oneCallTimeMachineInfo.Should().NotBeNull();
            oneCallTimeMachineInfo.Timezone.Should().Be("Europe/Zurich");
            oneCallTimeMachineInfo.Data.Should().ContainSingle()
                .Which.DateTime.Should().Be(dateTime);

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/3.0/onecall/timemachine?lat=1.1111&lon=1.2222&dt=1791288000&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCallTimeMachineAsync_DateTimeBefore1979_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var dateTime = new DateTime(1978, 12, 31, 23, 59, 59, DateTimeKind.Utc);

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetWeatherOneCallTimeMachineAsync(Latitude, Longitude, dateTime);

            // Assert
            await action.Should().ThrowAsync<ArgumentOutOfRangeException>().WithParameterName("dateTime");
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCallDaySummaryAsync_ValidDate_ReturnsOneCallDaySummary()
        {
            // Arrange
            var date = new DateTime(2026, 10, 6);

            this.SetupResponse("/data/3.0/onecall/day_summary", Responses.GetJson(Responses.OneCallDaySummary));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var daySummary = await openWeatherMapService.GetWeatherOneCallDaySummaryAsync(Latitude, Longitude, date);

            // Assert
            daySummary.Should().NotBeNull();
            daySummary.Date.Should().Be(date);
            daySummary.Timezone.Should().Be("+02:00");
            daySummary.Units.Should().Be(UnitSystem.Metric);
            daySummary.CloudCover.Afternoon.Should().Be(Ratio.FromPercent(20d));
            daySummary.Humidity.Afternoon.Should().Be(RelativeHumidity.FromPercent(56d));
            daySummary.Precipitation.Total.Should().Be(Length.FromMillimeters(1.25d));
            daySummary.Temperature.Min.Should().Be(Temperature.FromDegreesCelsius(8.1d));
            daySummary.Temperature.Max.Should().Be(Temperature.FromDegreesCelsius(17.4d));
            daySummary.Pressure.Afternoon.Should().Be(Pressure.FromHectopascals(1017d));
            daySummary.Wind.Max.Speed.Should().Be(Speed.FromMetersPerSecond(4.8d));
            daySummary.Wind.Max.Direction.Should().Be(Angle.FromDegrees(220d));

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/3.0/onecall/day_summary?lat=1.1111&lon=1.2222&date=2026-10-06&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(2, "%2B02%3A00")]
        [InlineData(-5.5, "-05%3A30")]
        [InlineData(0, "%2B00%3A00")]
        public async Task GetWeatherOneCallDaySummaryAsync_WithTimezoneOffset_RequestsTimezone(double offsetHours, string expectedTimezone)
        {
            // Arrange
            var date = new DateTime(2026, 10, 6);
            var timezoneOffset = TimeSpan.FromHours(offsetHours);

            this.SetupResponse("/data/3.0/onecall/day_summary", Responses.GetJson(Responses.OneCallDaySummary));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            await openWeatherMapService.GetWeatherOneCallDaySummaryAsync(Latitude, Longitude, date, timezoneOffset);

            // Assert
            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                $"https://api.openweathermap.org/data/3.0/onecall/day_summary?lat=1.1111&lon=1.2222&date=2026-10-06&tz={expectedTimezone}&units=metric&lang=en&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCallDaySummaryAsync_DateBefore1979_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var date = new DateTime(1979, 1, 1);

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetWeatherOneCallDaySummaryAsync(Latitude, Longitude, date);

            // Assert
            await action.Should().ThrowAsync<ArgumentOutOfRangeException>().WithParameterName("date");
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(14.5)]
        [InlineData(-14.5)]
        public async Task GetWeatherOneCallDaySummaryAsync_InvalidTimezoneOffset_ThrowsArgumentOutOfRangeException(double offsetHours)
        {
            // Arrange
            var date = new DateTime(2026, 10, 6);
            var timezoneOffset = TimeSpan.FromHours(offsetHours);

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            Func<Task> action = () => openWeatherMapService.GetWeatherOneCallDaySummaryAsync(Latitude, Longitude, date, timezoneOffset);

            // Assert
            await action.Should().ThrowAsync<ArgumentOutOfRangeException>().WithParameterName("timezoneOffset");
            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCallOverviewAsync_ValidCoordinates_ReturnsOneCallWeatherOverview()
        {
            // Arrange
            this.SetupResponse("/data/3.0/onecall/overview", Responses.GetJson(Responses.OneCallOverview));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            var weatherOverview = await openWeatherMapService.GetWeatherOneCallOverviewAsync(Latitude, Longitude);

            // Assert
            weatherOverview.Should().NotBeNull();
            weatherOverview.Date.Should().Be(new DateTime(2026, 10, 6));
            weatherOverview.WeatherOverview.Should().StartWith("The current weather is partly cloudy");

            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/3.0/onecall/overview?lat=1.1111&lon=1.2222&units=metric&appid=apikey",
                Times.Once());

            this.httpMessageHandlerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task GetWeatherOneCallOverviewAsync_WithDate_RequestsDate()
        {
            // Arrange
            var date = new DateTime(2026, 10, 7);

            this.SetupResponse("/data/3.0/onecall/overview", Responses.GetJson(Responses.OneCallOverview));

            IOpenWeatherMapService openWeatherMapService = this.autoMocker.CreateInstance<OpenWeatherMapService>();

            // Act
            await openWeatherMapService.GetWeatherOneCallOverviewAsync(Latitude, Longitude, date);

            // Assert
            this.httpMessageHandlerMock.VerifyRequest(HttpMethod.Get,
                "https://api.openweathermap.org/data/3.0/onecall/overview?lat=1.1111&lon=1.2222&date=2026-10-07&units=metric&appid=apikey",
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
