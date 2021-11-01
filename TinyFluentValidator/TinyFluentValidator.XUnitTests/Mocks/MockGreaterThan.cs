using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockGreaterThan : IValidationEntity<MockGreaterThan>
    {
        public int Value { get; init; }
        public double DoubleVal { get; set; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockGreaterThan> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Value).GreaterThan(1)
                .RuleFor(x => x.DoubleVal).GreaterThan(1.0)
                .ToList();
        }
    }
}