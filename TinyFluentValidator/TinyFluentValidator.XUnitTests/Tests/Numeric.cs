using FluentAssertions;
using TinyFluentValidator.Classes;
using TinyFluentValidator.XUnitTests.Mocks;
using Xunit;

namespace TinyFluentValidator.XUnitTests.Tests
{
    public class Numeric
    {
        [Theory]
        [InlineData(2, 1.1, 0)]
        [InlineData(1, 1.1, 1)]
        [InlineData(2, 1.0, 1)]
        public void GreaterThan_Ok(int value, double doubleVal, int expectedErrors)
        {
            var mock = new MockGreaterThan { Value = value, DoubleVal = doubleVal};
            
            var errors = mock.StateIsValid(new Validator<MockGreaterThan>());
            errors.Count.Should().Be(expectedErrors);
        }
        
        [Theory]
        [InlineData(1, 1.0, 0)]
        [InlineData(2, 1.1, 0)]
        [InlineData(0, 1.0, 1)]
        [InlineData(1, 0.9, 1)]
        public void GreaterThanOrEqualTo_Ok(int value, double doubleVal, int expectedErrors)
        {
            var mock = new MockGtEqual { Value = value, DoubleVal = doubleVal };
            
            var errors = mock.StateIsValid(new Validator<MockGtEqual>());
            errors.Count.Should().Be(expectedErrors);
        }
        
        [Theory]
        [InlineData(0, 0.9, 0)]
        [InlineData(1, 0.9, 1)]
        [InlineData(0, 1.0, 1)]
        public void LessThan_Ok(int value, double doubleVal, int expectedErrors)
        {
            var mock = new MockLessThan { Value = value, DoubleVal = doubleVal };
            
            var errors = mock.StateIsValid(new Validator<MockLessThan>());
            errors.Count.Should().Be(expectedErrors);
        }
        
        [Theory]
        [InlineData(0, 0.9, 0)]
        [InlineData(1, 0.9, 0)]
        [InlineData(0, 1.0, 0)]
        [InlineData(2, 1.0, 1)]
        [InlineData(1, 1.1, 1)]
        public void LessThanOrEqualTo_Ok(int value, double doubleVal, int expectedErrors)
        {
            var mock = new MockLtEqual { Value = value, DoubleVal = doubleVal };
            
            var errors = mock.StateIsValid(new Validator<MockLtEqual>());
            errors.Count.Should().Be(expectedErrors);
        }
        
        [Theory]
        [InlineData(1, 1.0, 0)]
        [InlineData(2, 2.0, 0)]
        [InlineData(3, 3.0, 0)]
        [InlineData(4, 3.1, 2)]
        [InlineData(0, 0.9, 2)]
        public void InclusiveBetween_Ok(int value, double doubleVal, int expectedErrors)
        {
            var mock = new MockInclusive { Value = value, DoubleVal = doubleVal };
            
            var errors = mock.StateIsValid(new Validator<MockInclusive>());
            errors.Count.Should().Be(expectedErrors);
        }
        
        [Theory]
        [InlineData(1, 1.0, 2)]
        [InlineData(2, 2.0, 0)]
        [InlineData(3, 3.0, 2)]
        [InlineData(0, 0.9, 2)]
        public void ExclusiveBetween_Ok(int value, double doubleVal, int expectedErrors)
        {
            var mock = new MockExclusive { Value = value, DoubleVal = doubleVal };
            
            var errors = mock.StateIsValid(new Validator<MockExclusive>());
            errors.Count.Should().Be(expectedErrors);
        }
    }
}