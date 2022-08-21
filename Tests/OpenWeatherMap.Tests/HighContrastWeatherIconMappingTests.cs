using System.Threading.Tasks;
using FluentAssertions;
using OpenWeatherMap.Models;
using OpenWeatherMap.Tests.Testdata;
using Xunit;

namespace OpenWeatherMap.Tests
{
    public class HighContrastWeatherIconMappingTests
    {
        [Theory]
        [ClassData(typeof(WeatherConditionTestData))]
        public async Task ShouldGetIconAsync(WeatherCondition weatherCondition)
        {
            // Arrange
            IWeatherIconMapping weatherIconMapping = new HighContrastWeatherIconMapping();

            // Act
            var icon = await weatherIconMapping.GetIconAsync(weatherCondition);

            // Assert
            icon.Should().NotBeNull();
        }

        public class WeatherConditionTestData : TheoryData<WeatherCondition>
        {
            public WeatherConditionTestData()
            {
                foreach (var weatherCondition in WeatherConditions.GetTestWeatherConditions())
                {
                    this.Add(weatherCondition);
                }
            }
        }
    }
}