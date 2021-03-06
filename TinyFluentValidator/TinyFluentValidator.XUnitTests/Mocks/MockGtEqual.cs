using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockGtEqual : IValidationEntity<MockGtEqual>
    {
        public int Value { get; init; }
        public double DoubleVal { get; set; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockGtEqual> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Value).GreaterThanOrEqualTo(1)
                .RuleFor(x => x.DoubleVal).GreaterThanOrEqualTo(1.0)
                .ToList();
        }
    }
}