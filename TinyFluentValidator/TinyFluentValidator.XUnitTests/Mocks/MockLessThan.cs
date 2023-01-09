using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockLessThan : IValidationTarget<MockLessThan>
    {
        public int Value { get; init; }
        public double DoubleVal { get; set; }

        public ValidationResult IsValid(IValidator<MockLessThan> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Value).LessThan(1)
                .RuleFor(x => x.DoubleVal).LessThan(1.0)
                .GetResult();
        }
    }
}