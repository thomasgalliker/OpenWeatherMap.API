using System;
using FluentAssertions;
using OpenWeatherMap.Models;
using UnitsNet;
using UnitsNet.Units;
using Xunit;
using Xunit.Abstractions;

namespace OpenWeatherMap.Tests.Models
{
    public class TemperatureTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public TemperatureTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [ClassData(typeof(TemperatureTestData))]
        public void ShouldConvertToString(double value, TemperatureUnit unit, string format, string expectedStringOutput)
        {
            // Arrange
            var temperature = new Temperature(value, unit);

            // Act
            var stringOutput = temperature.ToString(format);

            // Assert
            this.testOutputHelper.WriteLine($"stringOutput={stringOutput}");

            temperature.Value.Should().Be(value);
            temperature.Unit.Should().Be(unit);

            stringOutput.Should().Be(expectedStringOutput);
        }

        public class TemperatureTestData : TheoryData<double, TemperatureUnit, string, string>
        {
            public TemperatureTestData()
            {
                // Default format
                this.Add(-1d, TemperatureUnit.DegreeCelsius, null, "-1�C");
                this.Add(-0.1d, TemperatureUnit.DegreeCelsius, null, "-0.1�C");
                this.Add(0d, TemperatureUnit.DegreeCelsius, null, "0�C");
                this.Add(1d, TemperatureUnit.DegreeCelsius, null, "1�C");
                this.Add(1.2d, TemperatureUnit.DegreeCelsius, null, "1.2�C");
                this.Add(1.23d, TemperatureUnit.DegreeCelsius, null, "1.23�C");
                this.Add(1.234d, TemperatureUnit.DegreeCelsius, null, "1.23�C");
                this.Add(1.2345d, TemperatureUnit.DegreeCelsius, null, "1.23�C");
                this.Add(99.99999999d, TemperatureUnit.DegreeCelsius, null, "100�C");

                // Format "N0"
                this.Add(-1d, TemperatureUnit.DegreeCelsius, "N0", "-1");
                this.Add(-0.1d, TemperatureUnit.DegreeCelsius, "N0", "0");
                this.Add(0d, TemperatureUnit.DegreeCelsius, "N0", "0");
                this.Add(1d, TemperatureUnit.DegreeCelsius, "N0", "1");
                this.Add(1.2d, TemperatureUnit.DegreeCelsius, "N0", "1");
                this.Add(1.23d, TemperatureUnit.DegreeCelsius, "N0", "1");
                this.Add(1.234d, TemperatureUnit.DegreeCelsius, "N0", "1");
                this.Add(1.2345d, TemperatureUnit.DegreeCelsius, "N0", "1");
                this.Add(99.99999999d, TemperatureUnit.DegreeCelsius, "N0", "100");
            }
        }

        [Fact]
        public void ShouldThrowOutOfRangeException_NegativeKelvin()
        {
            // Act
            Action action = () => new Temperature(-1d, TemperatureUnit.Kelvin);

            // Assert
            action.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}