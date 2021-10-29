using System.Collections.Generic;
using TinyValidator.Interfaces;

namespace TinyValidator.XUnitTests.Mocks
{
    public class MockValidatableNulls : IValidationEntity<MockValidatableNulls>
    {
        public string Line1 { get; init; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockValidatableNulls> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).NotNull()
                .ToList();
        }
    }
}