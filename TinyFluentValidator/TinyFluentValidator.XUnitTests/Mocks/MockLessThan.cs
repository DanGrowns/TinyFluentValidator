using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockLessThan : IValidationEntity<MockLessThan>
    {
        public int Value { get; init; }
        public double DoubleVal { get; set; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockLessThan> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Value).LessThan(1)
                .RuleFor(x => x.DoubleVal).LessThan(1.0)
                .ToList();
        }
    }
}