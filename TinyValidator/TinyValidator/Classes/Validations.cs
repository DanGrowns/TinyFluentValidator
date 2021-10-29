﻿using System;
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
        public string MemberName { get; set; }
        public Type MemberValueType { get; set; }
        public object MemberValue { get; set; }

        public Validations()
        {
            Errors = new List<string>();
        }

        private bool ValueIsDefault()
        {
            if (MemberValueType.IsValueType == false) 
                return MemberValue == null;
            
            var defaultValue = Activator.CreateInstance(MemberValueType);
            return MemberValue.Equals(defaultValue);
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
                if (string.IsNullOrEmpty(stringValue))
                    hasError = true;
            }
            else
            {
                hasError = ValueIsDefault();
            }

            if (hasError)
            {
                errorMessage = errorMessage.Replace($"[PropertyName]", $"'{MemberName}'");
                Errors.Add(errorMessage);
            }

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