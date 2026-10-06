using FluentAssertions;
using OpenWeatherMap.Models;
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
    }
}
