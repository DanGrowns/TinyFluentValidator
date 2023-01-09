using System.Collections.Generic;
using System.Linq;

namespace TinyFluentValidator.Classes
{
    public class ValidationResult
    {
        private List<string> ValidationErrors { get; }
        
        public ValidationResult(IEnumerable<string> errors)
            => ValidationErrors = errors.ToList();

        public IReadOnlyList<string> Errors => ValidationErrors;
        public bool IsValid => ValidationErrors?.Count == 0;
    }
}