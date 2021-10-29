using System.Collections.Generic;
using TinyValidator.Interfaces;

namespace TinyValidator.XUnitTests.Mocks
{
    public class MockValidatable : IValidationEntity<MockValidatable>
    {
        public string Line1 { get; init; }
        public string Line2 { get; init; }
        public int Id { get; init; }
        
        public IReadOnlyList<string> StateIsValid(IValidator<MockValidatable> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).NotEmpty()
                .RuleFor(x => x.Line2).NotEmpty()
                .RuleFor(x => x.Id).NotEmpty()
                .ToList();
        }
    }
}