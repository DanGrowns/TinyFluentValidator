using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.Classes
{
    public class Validator<T> : IValidator<T>
    {
        protected internal List<string> Errors { get; }
        protected internal T ValidationObject { get; set; }
        protected internal string MemberName { get; set; }
        protected internal Type MemberValueType { get; set; }
        protected internal object MemberValue { get; set; }
        
        public Validator() => Errors = new List<string>();

        public IValidator<T> Start(T item)
        {
            ValidationObject = item;
            Errors.Clear();
            
            return this;
        }

        public IPropertyValidator<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var body = (MemberExpression) expression.Body;
            var compiled = expression.Compile();

            MemberName = body.Member.Name.SplitPascalCaseToString();
            MemberValueType = compiled.Method.ReturnType;
            MemberValue = compiled.Invoke(ValidationObject);
            
            return new PropertyValidator<T, TProperty>(this);
        }

        public ValidationResult GetResult()
        {
            ValidationObject = default;
            MemberName = null;
            MemberValueType = null;
            MemberValue = null;
            
            return new ValidationResult(Errors);
        }
    }
}