using FluentAssertions;
using TinyValidator.Classes;
using TinyValidator.XUnitTests.Mocks;
using Xunit;

namespace TinyValidator.XUnitTests.Tests
{
    public class General
    {
        [Fact]
        public void NotEmptyTest_Ok()
        {
            var mock1 = new MockValidatable
            {
                Line1 = "First",
                Line2 = "Second"
            };
            
            var errors1 = mock1.StateIsValid(new Validations<MockValidatable>());

            errors1.Count.Should().Be(1);
        }
    }
}