using System;
using TinyValidator.Interfaces;

namespace TinyValidator.Classes
{
    public class PropertyValidator<T, TProperty> : Validator<T>, IPropertyValidator<T, TProperty>
    {
        public PropertyValidator(Validator<T> previous)
        {
            Errors.AddRange(previous.Errors);
            ValidationObject = previous.ValidationObject;
            MemberName = previous.MemberName;
            MemberValueType = previous.MemberValueType;
            MemberValue = previous.MemberValue;
        }

        private bool ValueIsDefault()
        {
            if (MemberValueType.IsValueType == false) 
                return MemberValue == null;
            
            var defaultValue = Activator.CreateInstance(MemberValueType);
            return MemberValue.Equals(defaultValue);
        }
        
        public TProperty GetPropertyValue() => (TProperty) MemberValue;
        
        public void AddError(string errorMessage)
        {
            if (errorMessage.Contains("[PropertyName]"))
                errorMessage = errorMessage.Replace($"[PropertyName]", $"'{MemberName}'");
            
            Errors.Add(errorMessage);
        }

        public IPropertyValidator<T, TProperty> NotEmpty(string errorMessage = null)
        {
            var hasError = false;
            
            if (MemberValue is string stringValue)
            {
                stringValue = stringValue.Trim();
                if (string.IsNullOrEmpty(stringValue))
                    hasError = true;
            }
            else
            {
                hasError = ValueIsDefault();
            }

            if (hasError)
                AddError(errorMessage ?? "[PropertyName] cannot be empty.");
            
            return this;
        }

        public IPropertyValidator<T, TProperty> NotNull(string errorMessage = null)
        {
            if (MemberValueType.IsValueType)
                return this;

            if (MemberValue == null)
                AddError(errorMessage ?? "[PropertyName] cannot be null.");
            
            return this;
        }
    }
}