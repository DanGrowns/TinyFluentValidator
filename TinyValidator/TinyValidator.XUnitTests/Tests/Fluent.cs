using FluentValidation;
using TinyValidator.XUnitTests.Mocks;

namespace TinyValidator.XUnitTests.Tests
{
    public class Fluent : AbstractValidator<MockPrimitives>
    {
        public Fluent()
        {
            RuleFor(x => x.Line1).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);

        }
    }
}