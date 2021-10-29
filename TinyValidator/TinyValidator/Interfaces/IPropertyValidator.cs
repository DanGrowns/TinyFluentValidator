﻿namespace TinyValidator.Interfaces
{
    public interface IPropertyValidator<T, out TProperty> : IValidator<T>
    {
        IPropertyValidator<T, TProperty> NotEmpty(string errorMessage = null);
        IPropertyValidator<T, TProperty> NotNull(string errorMessage = null);
        IPropertyValidator<T, TProperty> Empty(string errorMessage = null);
        IPropertyValidator<T, TProperty> Null(string errorMessage = null);
        TProperty GetPropertyValue();
        void AddError(string errorMessage);
    }
}