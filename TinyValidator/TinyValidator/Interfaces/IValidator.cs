using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TinyValidator.Interfaces
{
    public interface IValidator<T>
    {
        IValidator<T> Start(T item);
        IPropertyValidator<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression);
        IReadOnlyList<string> ToList();
    }
}