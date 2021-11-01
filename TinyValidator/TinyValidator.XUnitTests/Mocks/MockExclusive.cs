﻿using System.Collections.Generic;
using TinyValidator.Classes;
using TinyValidator.Interfaces;

namespace TinyValidator.XUnitTests.Mocks
{
    public class MockExclusive : IValidationEntity<MockExclusive>
    {
        public int Value { get; init; }
        public double DoubleVal { get; set; }

        public IReadOnlyList<string> StateIsValid(IValidator<MockExclusive> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Value).ExclusiveBetween(1, 3)
                .RuleFor(x => x.DoubleVal).ExclusiveBetween(1.0, 3.0)
                .ToList();
        }
    }
}