using System.Collections.Generic;

namespace TinyValidator.Interfaces
{
    public interface IValidationEntity
    {
        IReadOnlyList<string> StateIsValid();
    }
}