using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockEmpty : IValidationTarget<MockEmpty>
    {
        public string Line1 { get; init; }
        public MockSubClass SubClass { get; init; }

        public ValidationResult IsValid(IValidator<MockEmpty> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).Empty()
                .RuleFor(x => x.SubClass).Empty()
                .GetResult();
        }
    }
}