using System.Collections.Generic;
using TinyValidator.Interfaces;

namespace TinyValidator.XUnitTests.Mocks
{
    public class MockMust : IValidationEntity<MockMust>
    {
        public string Line1 { get; init; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockMust> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).Must(x => x?.Length > 2)
                .ToList();
        }
    }
}