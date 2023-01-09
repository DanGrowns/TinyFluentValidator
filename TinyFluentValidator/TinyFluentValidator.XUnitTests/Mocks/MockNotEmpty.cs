using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockNotEmpty : IValidationTarget<MockNotEmpty>
    {
        public MockSubClass SubClass { get; init; }

        public ValidationResult IsValid(IValidator<MockNotEmpty> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.SubClass).NotEmpty()
                .GetResult();
        }
    }
}