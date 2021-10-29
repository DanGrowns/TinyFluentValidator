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
        public string MemberName { get; set; }
        public object MemberValue { get; set; }

        public Validations()
        {
            Errors = new List<string>();
        }
        
        public IValidator<T> RuleFor(Expression<Func<T, string>> expression)
        {
            var body = (MemberExpression) expression.Body;

            MemberName = body.Member.Name.SplitPascalCaseToString();
            MemberValue = expression.Compile().Invoke(ValidationObject);

            return this;
        }
        
        public IValidator<T> NotEmpty(string errorMessage = "[PropertyName] cannot be empty.")
        {
            if (string.IsNullOrEmpty(MemberValue.ToString()))
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