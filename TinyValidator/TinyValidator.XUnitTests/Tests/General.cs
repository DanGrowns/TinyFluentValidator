using AutoFixture.Xunit2;
using FluentAssertions;
using TinyValidator.Classes;
using TinyValidator.XUnitTests.Mocks;
using Xunit;

namespace TinyValidator.XUnitTests.Tests
{
    public class General
    {
        [Fact]
        public void Check_FluentValidation_BasicMessage()
        {
            var validator = new Fluent();
            var result = validator.Validate(new MockPrimitives());
            result.Errors.Count.Should().Be(2);
        }
        
        [Theory]
        [InlineData("", 0, false, 0.0, 0.0, 5)]
        [InlineData(null, 1, true, 1.2, 3.14, 1)]
        [InlineData(" ", 1, true, 1.2, 3.14, 1)]
        [InlineData("Value", 1, true, 1.2, 3.14, 0)]
        public void NotEmpty_Ok(string line1, int id, bool flag, double money, float pi, int expectedErrors)
        {
            var mock = new MockPrimitives
            {
                Line1 = line1,
                Id = id,
                Flag = flag,
                Money = money,
                Pi = pi
            };
            
            var errors = mock.StateIsValid(new Validator<MockPrimitives>());
            errors.Count.Should().Be(expectedErrors);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData(null, 1)]
        [InlineData(" ", 0)]
        public void NotNull_Ok(string line1, int expectedErrors)
        {
            var mock = new MockNulls { Line1 = line1 };
            var errors = mock.StateIsValid(new Validator<MockNulls>());

            errors.Count.Should().Be(expectedErrors);
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData(" ", 0)]
        [InlineData("abcd", 0)]
        [InlineData("Max length exceeded", 1)]
        public void MaxLength_Ok(string line1, int expectedErrors)
        {
            var mock = new MockMaxLength { Line1 = line1 };
            var errors = mock.StateIsValid(new Validator<MockMaxLength>());

            errors.Count.Should().Be(expectedErrors);
        }
    }
}