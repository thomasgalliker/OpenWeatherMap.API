using FluentAssertions;
using OpenWeatherMap.Models;
using OpenWeatherMap.Tests.Testdata;
using UnitsNet;
using UnitsNet.Units;
using Xunit;

namespace OpenWeatherMap.Tests
{
    [Trait(Traits.Category, Traits.UnitTests)]
    public class OpenWeatherMapJsonSerializerTests
    {
        [Theory]
        [InlineData(UnitSystem.Standard, TemperatureUnit.Kelvin)]
        [InlineData(UnitSystem.Metric, TemperatureUnit.DegreeCelsius)]
        [InlineData(UnitSystem.Imperial, TemperatureUnit.DegreeFahrenheit)]
        public void DeserializeObject_UnitSystem_ReturnsTemperatureInUnitSystemUnit(string unitSystem, TemperatureUnit expectedTemperatureUnit)
        {
            // Arrange
            var serializer = new OpenWeatherMapJsonSerializer(unitSystem);

            // Act
            var temperatureInfo = serializer.DeserializeObject<TemperatureInfo>("""{"temp":295.15,"feels_like":295.15,"pressure":1017,"humidity":56}""");

            // Assert
            temperatureInfo.Temperature.Should().Be(new Temperature(295.15d, expectedTemperatureUnit));
        }

        [Theory]
        [InlineData(UnitSystem.Standard, SpeedUnit.MeterPerSecond)]
        [InlineData(UnitSystem.Metric, SpeedUnit.MeterPerSecond)]
        [InlineData(UnitSystem.Imperial, SpeedUnit.MilePerHour)]
        public void DeserializeObject_UnitSystem_ReturnsWindSpeedInUnitSystemUnit(string unitSystem, SpeedUnit expectedSpeedUnit)
        {
            // Arrange
            var serializer = new OpenWeatherMapJsonSerializer(unitSystem);

            // Act
            var windInfo = serializer.DeserializeObject<WindInfo>("""{"speed":3.5}""");

            // Assert
            windInfo.Speed.Should().Be(new Speed(3.5d, expectedSpeedUnit));
        }

        [Fact]
        public void DeserializeObject_WeatherForecastDaily_ReturnsWindInfo()
        {
            // Arrange
            var serializer = new OpenWeatherMapJsonSerializer(UnitSystem.Metric);
            var json = Responses.GetJson(Responses.ForecastDaily);

            // Act
            var weatherForecast = serializer.DeserializeObject<WeatherForecastDaily>(json);

            // Assert
            var wind = weatherForecast.Items.First().Wind;
            wind.Speed.Should().Be(Speed.FromMetersPerSecond(2.4d));
            wind.Direction.Should().Be(Angle.FromDegrees(220d));
            wind.Gust.Should().Be(Speed.FromMetersPerSecond(4.8d));
        }
    }
}
