using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TinyValidator.Interfaces
{
    public interface IValidator<T>
    {
        IValidator<T> Start(T item);
        IValidator<T> RuleFor<TValue>(Expression<Func<T, TValue>> expression);
        IValidator<T> NotEmpty(string errorMessage = "[PropertyName] cannot be empty.");
        IReadOnlyList<string> ToList();
    }
}