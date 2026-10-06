using FluentAssertions;
using OpenWeatherMap.Models;
using Xunit;

namespace OpenWeatherMap.Tests.Models
{
    public class WeatherForecastBaseTests
    {
        [Fact]
        public void ShouldDeserializeNumericMessageField()
        {
            // Arrange
            const string json = "{\"cod\":\"200\",\"message\":0,\"cnt\":1,\"list\":[]}";
            var serializer = new OpenWeatherMapJsonSerializer(UnitSystem.Metric);

            // Act
            var result = serializer.DeserializeObject<WeatherForecast>(json);

            // Assert
            result.Message.Should().Be("0");
        }
    }
}
