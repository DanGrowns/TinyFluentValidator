﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TinyValidator.Interfaces
{
    public interface IValidator<T>
    {
        IValidator<T> Start(T item);
        IValidator<T> RuleFor(Expression<Func<T, string>> expression);
        IValidator<T> NotEmpty(string errorMessage = "[PropertyName] cannot be empty.");
        IReadOnlyList<string> ToList();
    }
}