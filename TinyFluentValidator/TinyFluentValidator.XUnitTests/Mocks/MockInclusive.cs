using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockInclusive : IValidationTarget<MockInclusive>
    {
        public int Value { get; init; }
        public double DoubleVal { get; set; }

        public ValidationResult IsValid(IValidator<MockInclusive> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Value).InclusiveBetween(1, 3)
                .RuleFor(x => x.DoubleVal).InclusiveBetween(1.0, 3.0)
                .GetResult();
        }
    }
}