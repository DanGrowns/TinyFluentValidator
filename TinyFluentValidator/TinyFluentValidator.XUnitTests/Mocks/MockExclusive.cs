﻿using System.Collections.Generic;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;

namespace TinyFluentValidator.XUnitTests.Mocks
{
    public class MockExclusive : IValidationTarget<MockExclusive>
    {
        public int Value { get; init; }
        public double DoubleVal { get; set; }

        public ValidationResult IsValid(IValidator<MockExclusive> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Value).ExclusiveBetween(1, 3)
                .RuleFor(x => x.DoubleVal).ExclusiveBetween(1.0, 3.0)
                .GetResult();
        }
    }
}