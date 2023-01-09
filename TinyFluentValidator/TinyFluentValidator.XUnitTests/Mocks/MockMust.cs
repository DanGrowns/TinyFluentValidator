using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockMust : IValidationTarget<MockMust>
    {
        public string Line1 { get; init; }

        public ValidationResult IsValid(IValidator<MockMust> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).Must(x => x?.Length > 2)
                .GetResult();
        }
    }
}