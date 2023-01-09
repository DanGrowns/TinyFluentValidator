using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockNull : IValidationTarget<MockNull>
    {
        public string Line1 { get; init; }
        public MockSubClass SubClass { get; init; }

        public ValidationResult IsValid(IValidator<MockNull> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).Null()
                .RuleFor(x => x.SubClass).Null()
                .GetResult();
        }
    }
}