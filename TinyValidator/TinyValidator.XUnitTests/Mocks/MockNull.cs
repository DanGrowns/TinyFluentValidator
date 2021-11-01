using System.Collections.Generic;
using TinyValidator.Interfaces;

namespace TinyValidator.XUnitTests.Mocks
{
    public class MockNull : IValidationEntity<MockNull>
    {
        public string Line1 { get; init; }
        public MockSubClass SubClass { get; init; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockNull> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).Null()
                .RuleFor(x => x.SubClass).Null()
                .ToList();
        }
    }
}