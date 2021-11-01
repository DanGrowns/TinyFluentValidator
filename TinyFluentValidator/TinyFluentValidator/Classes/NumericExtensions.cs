using System;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.Classes
{
    public static class NumericExtensions
    {
        public static IPropertyValidator<T, TProperty> GreaterThan<T, TProperty>(this IPropertyValidator<T, TProperty> validator, 
            TProperty value, string errorMessage = null) 
            where TProperty : IComparable<TProperty>
        {
            var result = validator.GetPropertyValue().CompareTo(value);
            if (result < 1)
                validator.AddError(errorMessage ?? $"[PropertyName] must be greater than {value}.");

            return validator;
        } 
        
        public static IPropertyValidator<T, TProperty> GreaterThanOrEqualTo<T, TProperty>(this IPropertyValidator<T, TProperty> validator, 
            TProperty value, string errorMessage = null)
            where TProperty : IComparable<TProperty>
        {
            var result = validator.GetPropertyValue().CompareTo(value);
            if (result < 0)
                validator.AddError(errorMessage ?? $"[PropertyName] must be greater than or equal to {value}.");

            return validator;
        }
        
        public static IPropertyValidator<T, TProperty> LessThan<T, TProperty>(this IPropertyValidator<T, TProperty> validator, 
            TProperty value, string errorMessage = null)
            where TProperty : IComparable<TProperty>
        {
            var result = validator.GetPropertyValue().CompareTo(value);
            if (result >= 0)
                validator.AddError(errorMessage ?? $"[PropertyName] must be less than {value}.");

            return validator;
        }
        
        public static IPropertyValidator<T, TProperty> LessThanOrEqualTo<T, TProperty>(this IPropertyValidator<T, TProperty> validator, 
            TProperty value, string errorMessage = null)
            where TProperty : IComparable<TProperty>
        {
            var result = validator.GetPropertyValue().CompareTo(value);
            if (result > 0)
                validator.AddError(errorMessage ?? $"[PropertyName] must be less than or equal to {value}.");

            return validator;
        }
        
        public static IPropertyValidator<T, TProperty> InclusiveBetween<T, TProperty>(this IPropertyValidator<T, TProperty> validator, 
            TProperty from, TProperty to, string errorMessage = null)
            where TProperty : IComparable<TProperty>
        {
            if (to.CompareTo(from) < 0)
                throw new ArgumentException(
                    "Validating with InclusiveBetween cannot have the from value as less than the to value");
            
            var value = validator.GetPropertyValue();
            var fromCompare = value.CompareTo(from);
            var toCompare = value.CompareTo(to);

            if (fromCompare is 0 or 1 && toCompare is 0 or -1)
                return validator;
            
            validator.AddError(errorMessage ?? $"[PropertyName] must be greater than or equal to {from} and less than or equal to {to}.");
            return validator;
        }
        
        public static IPropertyValidator<T, TProperty> ExclusiveBetween<T, TProperty>(this IPropertyValidator<T, TProperty> validator, 
            TProperty from, TProperty to, string errorMessage = null)
            where TProperty : IComparable<TProperty>
        {
            if (to.CompareTo(from) < 0)
                throw new ArgumentException(
                    "Validating with InclusiveBetween cannot have the from value as less than the to value");
            
            var value = validator.GetPropertyValue();
            var fromCompare = value.CompareTo(from);
            var toCompare = value.CompareTo(to);

            if (fromCompare is 1 && toCompare is -1)
                return validator;
            
            validator.AddError(errorMessage ?? $"[PropertyName] must be greater than {from} and less than {to}.");
            return validator;
        }
    }
}