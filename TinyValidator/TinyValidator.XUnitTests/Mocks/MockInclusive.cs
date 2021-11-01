using System.Collections.Generic;
using TinyValidator.Classes;
using TinyValidator.Interfaces;

namespace TinyValidator.XUnitTests.Mocks
{
    public class MockInclusive : IValidationEntity<MockInclusive>
    {
        public int Value { get; init; }
        public double DoubleVal { get; set; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockInclusive> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Value).InclusiveBetween(1, 3)
                .RuleFor(x => x.DoubleVal).InclusiveBetween(1.0, 3.0)
                .ToList();
        }
    }
}