using TinyValidator.Interfaces;

namespace TinyValidator.Classes
{
    public static class StringExtensions
    {
        public static IPropertyValidator<T, string> MaximumLength<T>(this IPropertyValidator<T, string> validator, 
            int length, string errorMessage = null)
        {
            var value = validator.GetPropertyValue() ?? "";
            
            if (value.Length > length)
                validator.AddError(errorMessage ?? $"[PropertyName] cannot exceed {value} characters.");

            return validator;
        }
    }
}