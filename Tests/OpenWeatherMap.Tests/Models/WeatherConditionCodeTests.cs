using FluentAssertions;
using OpenWeatherMap.Models;
using Xunit;

namespace OpenWeatherMap.Tests.Models
{
    [Trait(Traits.Category, Traits.UnitTests)]
    public class WeatherConditionCodeTests
    {
        [Fact]
        public void CompareTo_BoxedWeatherConditionCode_ReturnsComparisonResult()
        {
            // Arrange
            var weatherConditionCode = WeatherConditionCode.ScatteredClouds;
            object other = WeatherConditionCode.FewClouds;

            // Act
            var result = weatherConditionCode.CompareTo(other);

            // Assert
            result.Should().BePositive();
        }
    }
}
