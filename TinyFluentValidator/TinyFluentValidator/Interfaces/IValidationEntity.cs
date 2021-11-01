using System.Collections.Generic;

namespace TinyFluentValidator.Interfaces
{
    public interface IValidationEntity<T>
    {
        IReadOnlyList<string> StateIsValid(IValidator<T> validator);
    }
}