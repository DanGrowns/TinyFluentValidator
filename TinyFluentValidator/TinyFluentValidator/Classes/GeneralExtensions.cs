using System;
using System.Text.RegularExpressions;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.Classes
{
    public static class GeneralExtensions
    {
        internal static string SplitPascalCaseToString(this string pascalCaseStr)
        {
            var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            var modelWithSpaces = r.Replace(pascalCaseStr, " ");
            return modelWithSpaces;
        }
        
        public static IPropertyValidator<T, TProperty> If<T, TProperty>(
            this IPropertyValidator<T, TProperty> validator,
            bool condition,
            Func<TProperty, bool> predicate,
            string errorMessage)
        {
            var propertyValidator = (PropertyValidator<T, TProperty>)validator;

            if (condition == false)
                return propertyValidator;
                
            validator.Must(predicate, errorMessage);
            
            return propertyValidator;
        }
    }
}