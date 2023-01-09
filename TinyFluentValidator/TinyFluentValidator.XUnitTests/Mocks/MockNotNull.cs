using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockNotNull : IValidationTarget<MockNotNull>
    {
        public string Line1 { get; init; }
        public MockSubClass SubClass { get; init; }
        
        public ValidationResult IsValid(IValidator<MockNotNull> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).NotNull()
                .RuleFor(x => x.SubClass).NotNull()
                .GetResult();
        }
    }
}