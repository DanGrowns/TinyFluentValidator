using System.Collections.Generic;

namespace TinyValidator.Interfaces
{
    public interface IValidationEntity<T>
    {
        IReadOnlyList<string> StateIsValid(IValidator<T> validator);
    }
}