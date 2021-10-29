using AutoFixture.Xunit2;
using FluentAssertions;
using TinyValidator.Classes;
using TinyValidator.XUnitTests.Mocks;
using Xunit;

namespace TinyValidator.XUnitTests.Tests
{
    public class General
    {
        [Theory]
        [InlineData("", 0, false, 0.0, 0.0, 5)]
        [InlineData(null, 1, true, 1.2, 3.14, 1)]
        [InlineData(" ", 1, true, 1.2, 3.14, 1)]
        [InlineData("Value", 1, true, 1.2, 3.14, 0)]
        public void NotEmpty_Ok(string line1, int id, bool flag, double money, float pi, int expectedErrors)
        {
            var mock = new MockValidatable
            {
                Line1 = line1,
                Id = id,
                Flag = flag,
                Money = money,
                Pi = pi
            };
            
            var errors = mock.StateIsValid(new Validations<MockValidatable>());
            errors.Count.Should().Be(expectedErrors);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData(null, 1)]
        [InlineData(" ", 0)]
        public void NotNull_Ok(string line1, int expectedErrors)
        {
            var mock = new MockValidatableNulls { Line1 = line1 };
            var errors = mock.StateIsValid(new Validations<MockValidatableNulls>());

            errors.Count.Should().Be(expectedErrors);
        }
    }
}