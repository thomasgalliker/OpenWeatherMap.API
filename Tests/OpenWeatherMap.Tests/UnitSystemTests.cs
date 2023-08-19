using System;
using FluentAssertions;
using Xunit;
using static OpenWeatherMap.Tests.Testdata.WeatherForecasts;

namespace OpenWeatherMap.Tests
{
    public class UnitSystemTests
    {
        [Fact]
        public void ShouldCreateFromName_NotExisting()
        {
            // Arrange
            const string name = "not-good";

            // Act
            Action action = () => UnitSystem.FromName(name);

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ShouldCreateFromName_Existing()
        {
            // Arrange
            const string name = "metric";

            // Act
            var unitSystem = UnitSystem.FromName(name);

            // Assert
            unitSystem.Should().NotBeNull();
            unitSystem.ToString().Should().Be(name);
        }

        [Fact]
        public void ShouldImplicitlyCastFromString_Existing()
        {
            // Act
            UnitSystem unitSystem = "imperial";

            // Assert
            unitSystem.Should().NotBeNull();
            unitSystem.ToString().Should().Be(UnitSystem.Imperial);
        }

        [Fact]
        public void ShouldReturnStandard_IfDefault()
        {
            // Arrange
            UnitSystem unitSystem = default;

            // Act
            var toString = unitSystem.ToString();

            // Assert
            toString.Should().Be(UnitSystem.Standard);
        }

        [Fact]
        public void ShouldReturnStandard_IfNull()
        {
            // Arrange
            UnitSystem unitSystem = null;

            // Act
            var toString = unitSystem.ToString();

            // Assert
            toString.Should().Be(UnitSystem.Standard);
        }
    }
}