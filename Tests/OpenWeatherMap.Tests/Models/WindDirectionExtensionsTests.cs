using FluentAssertions;
using OpenWeatherMap.Models;
using Xunit;

namespace OpenWeatherMap.Tests.Models
{
    public class WindDirectionExtensionsTests
    {
        [Theory]
        [ClassData(typeof(CardinalWindDirectionTestData))]
        public void ShouldGetCardinalWindDirection(WindDirection windDirection, CardinalWindDirection expectedCardinalWindDirection)
        {
            // Act
            var cardinalWindDirection = windDirection.GetCardinalWindDirection();

            // Assert
            cardinalWindDirection.Should().Be(expectedCardinalWindDirection);
        }

        public class CardinalWindDirectionTestData : TheoryData<WindDirection, CardinalWindDirection>
        {
            public CardinalWindDirectionTestData()
            {
                this.Add(new WindDirection(120), CardinalWindDirection.E);
                this.Add(new WindDirection(146), CardinalWindDirection.S);
                this.Add(new WindDirection(147), CardinalWindDirection.S);
            }
        }

        [Theory]
        [ClassData(typeof(IntercardinalWindDirectionTestData))]
        public void ShouldGetIntercardinalWindDirection(WindDirection windDirection, CardinalWindDirection expectedCardinalWindDirection)
        {
            // Act
            var intercardinalWindDirection = windDirection.GetIntercardinalWindDirection();

            // Assert
            intercardinalWindDirection.Should().Be(expectedCardinalWindDirection);
        }

        public class IntercardinalWindDirectionTestData : TheoryData<WindDirection, CardinalWindDirection>
        {
            public IntercardinalWindDirectionTestData()
            {
                this.Add(new WindDirection(120), CardinalWindDirection.SE);
                this.Add(new WindDirection(146), CardinalWindDirection.SE);
                this.Add(new WindDirection(147), CardinalWindDirection.SE);
            }
        }
        
        [Theory]
        [ClassData(typeof(SecondaryIntercardinalWindDirectionTestData))]
        public void ShouldGetSecondaryIntercardinalWindDirection(WindDirection windDirection, CardinalWindDirection expectedCardinalWindDirection)
        {
            // Act
            var SecondaryIntercardinalWindDirection = windDirection.GetSecondaryIntercardinalWindDirection();

            // Assert
            SecondaryIntercardinalWindDirection.Should().Be(expectedCardinalWindDirection);
        }

        public class SecondaryIntercardinalWindDirectionTestData : TheoryData<WindDirection, CardinalWindDirection>
        {
            public SecondaryIntercardinalWindDirectionTestData()
            {
                this.Add(new WindDirection(120), CardinalWindDirection.ESE);
                this.Add(new WindDirection(146), CardinalWindDirection.SE);
                this.Add(new WindDirection(147), CardinalWindDirection.SSE);
            }
        }
    }
}