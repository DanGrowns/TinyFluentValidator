using System.Collections.Generic;
using TinyValidator.Classes;
using TinyValidator.Interfaces;

namespace TinyValidator.XUnitTests.Mocks
{
    public class MockMaxLength : IValidationEntity<MockMaxLength>
    {
        public string Line1 { get; init; }
        public int Id { get; set; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockMaxLength> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).MaximumLength(4)
                // Confirmed that below throws design time error as expected
                //.RuleFor(x => x.Id).MaximumLength(4)
                .ToList();
        }
    }
}