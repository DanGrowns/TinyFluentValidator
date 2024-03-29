﻿using System.Collections.Generic;
using AutoFixture.Xunit2;
using FluentAssertions;
using TinyFluentValidator.Classes;
using TinyFluentValidator.Interfaces;
using TinyFluentValidator.XUnitTests.Mocks;
using Xunit;

namespace TinyFluentValidator.XUnitTests.Tests
{
    public class General
    {
        [Theory]
        [InlineData("", 0, false, 0.0, 0.0, 5)]
        [InlineData(null, 1, true, 1.2, 3.14, 1)]
        [InlineData(" ", 1, true, 1.2, 3.14, 1)]
        [InlineData("Value", 1, true, 1.2, 3.14, 0)]
        public void NotEmpty_Primitives_Ok(string line1, int id, bool flag, double money, float pi, int expectedErrors)
        {
            var mock = new MockPrimitives
            {
                Line1 = line1,
                Id = id,
                Flag = flag,
                Money = money,
                Pi = pi
            };
            
            var result = mock.IsValid(new Validator<MockPrimitives>());
            result.Errors.Count.Should().Be(expectedErrors);
        }

        [Theory]
        [InlineData("", true, 0)]
        [InlineData(" ", true, 0)]
        [InlineData(null, true, 1)]
        [InlineData(null, false, 2)]
        public void NotNull_Ok(string line1, bool createSubClass, int expectedErrors)
        {
            var mock = new MockNotNull
            {
                Line1 = line1,
                SubClass = createSubClass ? new MockSubClass() : null
            };
            
            var result = mock.IsValid(new Validator<MockNotNull>());
            result.Errors.Count.Should().Be(expectedErrors);
        }
        
        [Theory]
        [InlineData(null, false, 0)]
        [InlineData("", false, 1)]
        [InlineData(" ", false, 1)]
        [InlineData("t", false,  1)]
        [InlineData(null, true, 1)]
        [InlineData("", true, 2)]
        public void IsNull_Ok(string line1, bool createSubClass, int expectedErrors)
        {
            var mock = new MockNull
            {
                Line1 = line1,
                SubClass = createSubClass ? new MockSubClass() : null
            };
            
            var result = mock.IsValid(new Validator<MockNull>());
            result.Errors.Count.Should().Be(expectedErrors);
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData(" ", 0)]
        [InlineData("abcd", 0)]
        [InlineData("Max length exceeded", 1)]
        public void MaxLength_Ok(string line1, int expectedErrors)
        {
            var mock = new MockMaxLength { Line1 = line1 };
            
            var result = mock.IsValid(new Validator<MockMaxLength>());
            result.Errors.Count.Should().Be(expectedErrors);
        }

        [Theory]
        [InlineData("", false, 0)]
        [InlineData(" ", false, 0)]
        [InlineData(null, false, 0)]
        [InlineData(null, true, 1)]
        [InlineData("text", true, 2)]
        public void Empty_Ok(string line1, bool createSubClass, int expectedErrors)
        {
            var mock = new MockEmpty
            {
                Line1 = line1,
                SubClass = createSubClass ? new MockSubClass() : null
            };

            var result = mock.IsValid(new Validator<MockEmpty>());
            result.Errors.Count.Should().Be(expectedErrors);
        }
        
        [Theory]
        [InlineData(true, 0)]
        [InlineData(false, 1)]
        public void NotEmpty_Ref_Ok(bool createSubClass, int expectedErrors)
        {
            var mock = new MockNotEmpty
            {
                SubClass = createSubClass ? new MockSubClass() : null
            };

            var result = mock.IsValid(new Validator<MockNotEmpty>());
            result.Errors.Count.Should().Be(expectedErrors);
        }
        
        [Theory]
        [InlineData(null, 1)]
        [InlineData("", 1)]
        [InlineData("t", 1)]
        [InlineData("te", 1)]
        [InlineData("tes", 0)]
        public void Must_Ok(string value, int expectedErrors)
        {
            var mock = new MockMust {Line1 = value};
            
            var result = mock.IsValid(new Validator<MockMust>());
            result.Errors.Count.Should().Be(expectedErrors);
        }
    }
}