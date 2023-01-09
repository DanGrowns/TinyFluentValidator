using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockMaxLength : IValidationTarget<MockMaxLength>
    {
        public string Line1 { get; init; }
        public int Id { get; set; }

        public ValidationResult IsValid(IValidator<MockMaxLength> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).MaximumLength(4)
                // Confirmed that below throws design time error as expected
                //.RuleFor(x => x.Id).MaximumLength(4)
                .GetResult();
        }
    }
}