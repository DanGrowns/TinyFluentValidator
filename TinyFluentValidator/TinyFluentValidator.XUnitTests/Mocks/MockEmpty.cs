using System.Collections.Generic;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockEmpty : IValidationEntity<MockEmpty>
    {
        public string Line1 { get; init; }
        public MockSubClass SubClass { get; init; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockEmpty> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).Empty()
                .RuleFor(x => x.SubClass).Empty()
                .ToList();
        }
    }
}