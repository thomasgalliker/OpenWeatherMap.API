using System;
using FluentAssertions;
using OpenWeatherMap.Models;
using Xunit;
using Xunit.Abstractions;

namespace OpenWeatherMap.Tests.Models
{
    public class UVIndexTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public UVIndexTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [ClassData(typeof(UVIndexTestData))]
        public void ShouldCreateUVIndex(double uvIndexValue)
        {
            // Arrange
            var uvIndex = new UVIndex(uvIndexValue);

            // Act
            var stringOutput = uvIndex.ToString();

            // Assert
            this.testOutputHelper.WriteLine($"stringOutput={stringOutput}");

            uvIndex.Value.Should().Be(uvIndexValue);
            stringOutput.Should().NotBeNullOrEmpty();
        }

        public class UVIndexTestData : TheoryData<double>
        {
            public UVIndexTestData()
            {
                this.Add(0d);
                this.Add(1d);
                this.Add(1.23456789d);
                this.Add(4.99999999d);
                this.Add(11d);
                this.Add(double.MaxValue);
            }
        }

        [Fact]
        public void ShouldThrowOutOfRangeException()
        {
            // Arrange
            var uvIndex = -10d;

            // Act
            Action action = () => new UVIndex(uvIndex);

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}