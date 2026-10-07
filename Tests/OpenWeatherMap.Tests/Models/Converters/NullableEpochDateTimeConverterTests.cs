using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using OpenWeatherMap.Models.Converters;
using Xunit;

namespace OpenWeatherMap.Tests.Models.Converters
{
    [Trait(Traits.Category, Traits.UnitTests)]
    public class NullableEpochDateTimeConverterTests
    {
        [Theory]
        [ClassData(typeof(NullableEpochDateTimeConverterTestData))]
        public void Read_Json_ReturnsDateTime(string json, DateTime? expectedDateTime)
        {
            // Act
            var testObject = JsonSerializer.Deserialize<NullableEpochDateTimeTestObject>(json);

            // Assert
            testObject!.DateTime.Should().Be(expectedDateTime);
        }

        public class NullableEpochDateTimeConverterTestData : TheoryData<string, DateTime?>
        {
            public NullableEpochDateTimeConverterTestData()
            {
                this.Add("{}", null);
                this.Add("{\"dt\":null}", null);
                this.Add("{\"dt\":0}", null);
                this.Add("{\"dt\":\"0\"}", null);
                this.Add("{\"dt\":1791359063}", new DateTime(2026, 10, 7, 7, 44, 23, DateTimeKind.Utc));
            }
        }

        [Theory]
        [ClassData(typeof(NullableEpochDateTimeConverterWriteTestData))]
        public void Write_DateTime_ReturnsJson(DateTime? dateTime, string expectedJson)
        {
            // Arrange
            var testObject = new NullableEpochDateTimeTestObject { DateTime = dateTime };

            // Act
            var json = JsonSerializer.Serialize(testObject);

            // Assert
            json.Should().Be(expectedJson);
        }

        public class NullableEpochDateTimeConverterWriteTestData : TheoryData<DateTime?, string>
        {
            public NullableEpochDateTimeConverterWriteTestData()
            {
                this.Add(null, "{\"dt\":null}");
                this.Add(new DateTime(2026, 10, 7, 7, 44, 23, DateTimeKind.Utc), "{\"dt\":1791359063}");
            }
        }

        private class NullableEpochDateTimeTestObject
        {
            [JsonPropertyName("dt")]
            [JsonConverter(typeof(NullableEpochDateTimeConverter))]
            public DateTime? DateTime { get; set; }
        }
    }
}
