﻿using System.Collections.Generic;
using TinyValidator.Interfaces;

namespace TinyValidator.XUnitTests.Mocks
{
    public class MockValidatable : IValidationEntity<MockValidatable>
    {
        public string Line1 { get; init; }
        public int Id { get; init; }
        public bool Flag { get; set; }
        public double Money { get; set; }
        public float Pi { get; set; }
        
        
        public IReadOnlyList<string> StateIsValid(IValidator<MockValidatable> validator)
        {
            return validator.Start(this)
                .RuleFor(x => x.Line1).NotEmpty()
                .RuleFor(x => x.Id).NotEmpty()
                .RuleFor(x => x.Flag).NotEmpty()
                .RuleFor(x => x.Money).NotEmpty()
                .RuleFor(x => x.Pi).NotEmpty()
                .ToList();
        }
    }
}