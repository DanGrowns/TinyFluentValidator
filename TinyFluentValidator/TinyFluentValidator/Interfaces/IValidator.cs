using System;
using System.Linq.Expressions;
using TinyFluentValidator.Classes;

namespace TinyFluentValidator.Interfaces
{
    public interface IValidator<T>
    {
        IValidator<T> Start(T item);
        IPropertyValidator<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression);
        ValidationResult GetResult();
    }
}