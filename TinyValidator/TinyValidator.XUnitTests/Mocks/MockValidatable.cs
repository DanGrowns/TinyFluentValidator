using System.Collections.Generic;
using TinyValidator.Interfaces;

namespace TinyValidator.XUnitTests.Mocks
{
    public class MockValidatable : IValidationEntity
    {
        public string Line1 { get; init; }
        public string Line2 { get; init; }
        
        public IReadOnlyList<string> StateIsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}