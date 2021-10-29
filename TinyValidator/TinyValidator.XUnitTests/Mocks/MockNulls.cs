using System.Collections.Generic;
using TinyValidator.Interfaces;

namespace TinyValidator.XUnitTests.Mocks
{
    public class MockNulls : IValidationEntity<MockNulls>
    {
        public string Line1 { get; init; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockNulls> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).NotNull()
                .ToList();
        }
    }
}