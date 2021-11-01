using System.Collections.Generic;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockNotEmpty : IValidationEntity<MockNotEmpty>
    {
        public MockSubClass SubClass { get; init; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockNotEmpty> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.SubClass).NotEmpty()
                .ToList();
        }
    }
}