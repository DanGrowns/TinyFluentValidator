using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockLtEqual : IValidationTarget<MockLtEqual>
    {
        public int Value { get; init; }
        public double DoubleVal { get; set; }

        public ValidationResult IsValid(IValidator<MockLtEqual> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Value).LessThanOrEqualTo(1)
                .RuleFor(x => x.DoubleVal).LessThanOrEqualTo(1.0)
                .GetResult();
        }
    }
}