using System;
using System.Globalization;
using FluentAssertions;
using OpenWeatherMap.Models;
using Xunit;

namespace OpenWeatherMap.Tests.Models
{
    public class CardinalWindDirectionTests
    {
        [Theory]
        [ClassData(typeof(CardinalWindDirectionTestData))]

        public void ShouldReturnToString(CardinalWindDirection cardinalWindDirection, string format, IFormatProvider formatProvider, string expectedString)
        {
            // Act
            var toString = cardinalWindDirection.ToString(format, formatProvider);

            // Assert
            toString.Should().Be(expectedString);
        }

        public class CardinalWindDirectionTestData : TheoryData<CardinalWindDirection, string, IFormatProvider, string>
        {
            public CardinalWindDirectionTestData()
            {
                var deCulture = new CultureInfo("de");
                this.Add(CardinalWindDirection.N, null, deCulture, "Nord");
                this.Add(CardinalWindDirection.NNE, null, deCulture, "Nord-Nordost");

                var enCulture = new CultureInfo("en");
                this.Add(CardinalWindDirection.N, null, enCulture, "North");
                this.Add(CardinalWindDirection.NNE, null, enCulture, "North-northeast");

                var frCulture = new CultureInfo("fr");
                this.Add(CardinalWindDirection.N, null, frCulture, "Nord");
                this.Add(CardinalWindDirection.NNE, null, frCulture, "Nord-nordest");

                var itCulture = new CultureInfo("fr");
                this.Add(CardinalWindDirection.N, null, itCulture, "Nord");
                this.Add(CardinalWindDirection.NNE, null, itCulture, "Nord-nordest");
            }
        }
    }
}