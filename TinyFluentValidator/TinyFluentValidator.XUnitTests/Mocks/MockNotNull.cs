using System.Collections.Generic;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockNotNull : IValidationEntity<MockNotNull>
    {
        public string Line1 { get; init; }
        public MockSubClass SubClass { get; init; }
        
        public IReadOnlyList<string> StateIsValid(IValidator<MockNotNull> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).NotNull()
                .RuleFor(x => x.SubClass).NotNull()
                .ToList();
        }
    }
}