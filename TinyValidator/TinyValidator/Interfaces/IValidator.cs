using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TinyValidator.Interfaces
{
    public interface IPropertyValidator<T, out TProperty> : IValidator<T>
    {
        IPropertyValidator<T, TProperty> NotEmpty(string errorMessage = "[PropertyName] cannot be empty.");
        IPropertyValidator<T, TProperty> NotNull(string errorMessage = "[PropertyName] cannot be null.");
        TProperty GetPropertyValue();
        void AddError(string errorMessage);
    }
    
    public interface IValidator<T>
    {
        IValidator<T> Start(T item);
        IPropertyValidator<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression);
        IReadOnlyList<string> ToList();
    }
}