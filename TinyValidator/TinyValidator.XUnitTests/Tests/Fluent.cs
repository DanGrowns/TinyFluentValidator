using FluentValidation;
using TinyValidator.XUnitTests.Mocks;

namespace TinyValidator.XUnitTests.Tests
{
    public class Fluent : AbstractValidator<MockPrimitives>
    {
        public Fluent()
        {

            RuleFor(x => x.Line1).Must(x => x.Contains("T"));
            //RuleFor(x => x.Id).

        }
    }
}