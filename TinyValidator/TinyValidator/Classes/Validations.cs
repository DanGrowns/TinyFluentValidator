using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TinyValidator.Interfaces;

namespace TinyValidator.Classes
{
    // TODO: Preventing things like RuleFor being called twice in a row.
    // Make sure all state is cleared if it is called incorrectly in a chain
    public class Validations<T> : IValidator<T>
    {
        private List<string> Errors { get; }
        private T ValidationObject { get; set; }
        private string MemberName { get; set; }
        private Type MemberValueType { get; set; }
        private object MemberValue { get; set; }

        public Validations() => Errors = new List<string>();
        
        private bool ValueIsDefault()
        {
            if (MemberValueType.IsValueType == false) 
                return MemberValue == null;
            
            var defaultValue = Activator.CreateInstance(MemberValueType);
            return MemberValue.Equals(defaultValue);
        }

        private void AddError(string errorMessage)
        {
            if (errorMessage.Contains("[PropertyName]"))
                errorMessage = errorMessage.Replace($"[PropertyName]", $"'{MemberName}'");
            
            Errors.Add(errorMessage);
        }
        
        public IValidator<T> RuleFor<TValue>(Expression<Func<T, TValue>> expression)
        {
            var body = (MemberExpression) expression.Body;
            var compiled = expression.Compile();

            MemberName = body.Member.Name.SplitPascalCaseToString();
            MemberValueType = compiled.Method.ReturnType;
            MemberValue = compiled.Invoke(ValidationObject);
            
            return this;
        }
        
        public IValidator<T> NotEmpty(string errorMessage = "[PropertyName] cannot be empty.")
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
                AddError(errorMessage);
            
            return this;
        }

        public IValidator<T> NotNull(string errorMessage = "[PropertyName] cannot be null.")
        {
            if (MemberValueType.IsValueType)
                return this;

            if (MemberValue == null)
                AddError(errorMessage);
            
            return this;
        }

        public IValidator<T> Start(T item)
        {
            ValidationObject = item;
            return this;
        }
        
        public IReadOnlyList<string> ToList() => Errors;
    }
}