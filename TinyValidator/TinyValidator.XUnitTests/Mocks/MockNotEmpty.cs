using System.Collections.Generic;
using TinyValidator.Interfaces;

namespace TinyValidator.XUnitTests.Mocks
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