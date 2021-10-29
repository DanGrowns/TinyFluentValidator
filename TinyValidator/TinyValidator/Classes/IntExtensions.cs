using System;
using TinyValidator.Interfaces;

namespace TinyValidator.Classes
{
    public static class IntExtensions
    {
        public static IPropertyValidator<T, int> GreaterThan<T>(this IPropertyValidator<T, int> validator, 
            int value, string errorMessage = null)
        {
            if (validator.GetPropertyValue() > value)
                validator.AddError(errorMessage ?? $"[PropertyName] must be greater than {value}.");

            return validator;
        }
        
        public static IPropertyValidator<T, int> GreaterThanOrEqualTo<T>(this IPropertyValidator<T, int> validator, 
            int value, string errorMessage = null)
        {
            if (validator.GetPropertyValue() >= value)
                validator.AddError(errorMessage ?? $"[PropertyName] must be greater than or equal to {value}.");

            return validator;
        }
        
        public static IPropertyValidator<T, int> LessThan<T>(this IPropertyValidator<T, int> validator, 
            int value, string errorMessage = null)
        {
            if (validator.GetPropertyValue() < value)
                validator.AddError(errorMessage ?? $"[PropertyName] must be less than {value}.");

            return validator;
        }
        
        public static IPropertyValidator<T, int> LessThanOrEqualTo<T>(this IPropertyValidator<T, int> validator, 
            int value, string errorMessage = null)
        {
            if (validator.GetPropertyValue() <= value)
                validator.AddError(errorMessage ?? $"[PropertyName] must be less than or equal to {value}.");

            return validator;
        }
        
        public static IPropertyValidator<T, int> InclusiveBetween<T>(this IPropertyValidator<T, int> validator, 
            int from, int to, string errorMessage = null)
        {
            if (to < from)
                throw new ArgumentException(
                    "Validating with InclusiveBetween cannot have the from value as less than the to value");
            
            var value = validator.GetPropertyValue();
            if (value >= from && value <= to)
                validator.AddError(errorMessage ?? $"[PropertyName] must be greater than or equal to {from} and less than or equal to {to}.");

            return validator;
        }
        
        public static IPropertyValidator<T, int> ExclusiveBetween<T>(this IPropertyValidator<T, int> validator, 
            int from, int to, string errorMessage = null)
        {
            if (to < from)
                throw new ArgumentException(
                    "Validating with InclusiveBetween cannot have the from value as less than the to value");
            
            var value = validator.GetPropertyValue();
            if (value > from && value < to)
                validator.AddError(errorMessage ?? $"[PropertyName] must be greater than {from} and less than {to}.");

            return validator;
        }
    }
}