using System.Collections.Generic;
using TinyFluentValidator.Classes;

namespace TinyFluentValidator.Interfaces
{
    public interface IValidationTarget<T>
    {
        ValidationResult IsValid(IValidator<T> validator);
    }
}