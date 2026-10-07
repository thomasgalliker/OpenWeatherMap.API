using System.Globalization;
using FluentAssertions;
using OpenWeatherMap.Models;
using UnitsNet;
using UnitsNet.Units;
using Xunit;

namespace OpenWeatherMap.Tests.Models
{
    [Trait(Traits.Category, Traits.UnitTests)]
    public class WeatherInfoTests
    {
        // Recorded response of GET https://api.openweathermap.org/data/2.5/weather?lat=47.1815&lon=8.4606&units=metric&lang=en
        private const string CurrentWeatherResponseJson =
            """
            {"coord":{"lon":8.4606,"lat":47.1815},"weather":[{"id":802,"main":"Clouds","description":"scattered clouds","icon":"03d"}],"base":"stations","main":{"temp":22.32,"feels_like":22.07,"temp_min":21.1,"temp_max":23.78,"pressure":1017,"humidity":56,"sea_level":1017,"grnd_level":955},"visibility":1757,"wind":{"speed":0.51,"deg":0},"clouds":{"all":45},"dt":1791295291,"sys":{"type":5,"id":50001179,"country":"CH","sunrise":1791264677,"sunset":1791305828},"timezone":7200,"id":2661228,"name":"Cham","cod":200}
            """;

        [Fact]
        public void ShouldDeserializeCurrentWeatherResponse()
        {
            // Arrange
            var serializer = new OpenWeatherMapJsonSerializer(UnitSystem.Metric);

            // Act
            var result = serializer.DeserializeObject<WeatherInfo>(CurrentWeatherResponseJson);

            // Assert
            result.Should().BeEquivalentTo(GetExpectedWeatherInfo());
        }

        [Fact]
        public void ShouldSerializeAndDeserializeWeatherInfo()
        {
            // Arrange
            var serializer = new OpenWeatherMapJsonSerializer(UnitSystem.Metric);
            var weatherInfo = GetExpectedWeatherInfo();

            // Act
            var json = serializer.SerializeObject(weatherInfo);
            var result = serializer.DeserializeObject<WeatherInfo>(json);

            // Assert
            json.Should().Contain("\"id\":2661228");
            result.Should().BeEquivalentTo(weatherInfo, options => options
                .Using<Ratio>(ctx => ctx.Subject.Percent.Should().Be(ctx.Expectation.Percent))
                .WhenTypeIs<Ratio>());
        }

        [Theory]
        [InlineData("""{"sys":{"sunrise":1791264677,"sunset":1791305828}}""")]
        [InlineData("""{"sys":{"country":"","sunrise":1791264677,"sunset":1791305828}}""")]
        public void DeserializeObject_WithoutCountry_ReturnsNullCountry(string json)
        {
            // Arrange
            var serializer = new OpenWeatherMapJsonSerializer(UnitSystem.Metric);

            // Act
            var result = serializer.DeserializeObject<WeatherInfo>(json);

            // Assert
            result.AdditionalInformation.Country.Should().BeNull();
        }

        private static WeatherInfo GetExpectedWeatherInfo()
        {
            return new WeatherInfo
            {
                Coordinates = new Coordinates
                {
                    Latitude = 47.1815d,
                    Longitude = 8.4606d,
                },
                Weather = new[]
                {
                    new WeatherCondition
                    {
                        Id = WeatherConditionCode.ScatteredClouds,
                        Main = WeatherConditionGroup.Clouds,
                        Description = "scattered clouds",
                        IconId = "03d",
                    },
                },
                Main = new TemperatureInfo
                {
                    Temperature = new Temperature(22.32d, TemperatureUnit.DegreeCelsius),
                    FeelsLike = new Temperature(22.07d, TemperatureUnit.DegreeCelsius),
                    MinimumTemperature = new Temperature(21.1d, TemperatureUnit.DegreeCelsius),
                    MaximumTemperature = new Temperature(23.78d, TemperatureUnit.DegreeCelsius),
                    Pressure = Pressure.FromHectopascals(1017d),
                    Humidity = RelativeHumidity.FromPercent(56d),
                    SeaLevel = Pressure.FromHectopascals(1017d),
                    GroundLevel = Pressure.FromHectopascals(955d),
                },
                Visibility = Length.FromMeters(1757d),
                Wind = new WindInfo
                {
                    Speed = Speed.FromMetersPerSecond(0.51d),
                    Direction = Angle.FromDegrees(0d),
                },
                Clouds = new CloudsInformation
                {
                    All = Ratio.FromPercent(45d),
                },
                Date = new DateTime(2026, 10, 6, 14, 1, 31, DateTimeKind.Utc),
                AdditionalInformation = new AdditionalWeatherInfo
                {
                    Country = new RegionInfo("CH"),
                    Sunrise = new DateTime(2026, 10, 6, 5, 31, 17, DateTimeKind.Utc),
                    Sunset = new DateTime(2026, 10, 6, 16, 57, 8, DateTimeKind.Utc),
                },
                Timezone = 7200,
                CityId = 2661228,
                CityName = "Cham",
            };
        }
    }
}
