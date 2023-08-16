using FluentAssertions;
using OpenWeatherMap.Models;
using UnitsNet;
using UnitsNet.Units;
using Xunit;

namespace OpenWeatherMap.Tests.Models
{
    public class WindDirectionExtensionsTests
    {
        [Theory]
        [ClassData(typeof(CardinalWindDirectionTestData))]
        public void ShouldGetCardinalWindDirection(Angle windDirection, CardinalWindDirection expectedCardinalWindDirection)
        {
            // Act
            var cardinalWindDirection = windDirection.GetCardinalWindDirection();

            // Assert
            cardinalWindDirection.Should().Be(expectedCardinalWindDirection);
        }

        public class CardinalWindDirectionTestData : TheoryData<Angle, CardinalWindDirection>
        {
            public CardinalWindDirectionTestData()
            {
                this.Add(new Angle(120, AngleUnit.Degree), CardinalWindDirection.E);
                this.Add(new Angle(146, AngleUnit.Degree), CardinalWindDirection.S);
                this.Add(new Angle(147, AngleUnit.Degree), CardinalWindDirection.S);
            }
        }

        [Theory]
        [ClassData(typeof(IntercardinalWindDirectionTestData))]
        public void ShouldGetIntercardinalWindDirection(Angle windDirection, CardinalWindDirection expectedCardinalWindDirection)
        {
            // Act
            var intercardinalWindDirection = windDirection.GetIntercardinalWindDirection();

            // Assert
            intercardinalWindDirection.Should().Be(expectedCardinalWindDirection);
        }

        public class IntercardinalWindDirectionTestData : TheoryData<Angle, CardinalWindDirection>
        {
            public IntercardinalWindDirectionTestData()
            {
                this.Add(new Angle(120, AngleUnit.Degree), CardinalWindDirection.SE);
                this.Add(new Angle(146, AngleUnit.Degree), CardinalWindDirection.SE);
                this.Add(new Angle(147, AngleUnit.Degree), CardinalWindDirection.SE);
            }
        }
        
        [Theory]
        [ClassData(typeof(SecondaryIntercardinalWindDirectionTestData))]
        public void ShouldGetSecondaryIntercardinalWindDirection(Angle windDirection, CardinalWindDirection expectedCardinalWindDirection)
        {
            // Act
            var SecondaryIntercardinalWindDirection = windDirection.GetSecondaryIntercardinalWindDirection();

            // Assert
            SecondaryIntercardinalWindDirection.Should().Be(expectedCardinalWindDirection);
        }

        public class SecondaryIntercardinalWindDirectionTestData : TheoryData<Angle, CardinalWindDirection>
        {
            public SecondaryIntercardinalWindDirectionTestData()
            {
                this.Add(new Angle(120, AngleUnit.Degree), CardinalWindDirection.ESE);
                this.Add(new Angle(146, AngleUnit.Degree), CardinalWindDirection.SE);
                this.Add(new Angle(147, AngleUnit.Degree), CardinalWindDirection.SSE);
            }
        }
    }
}