using FluentAssertions;
using PriceGetter.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace PriceGetter.InfrastructureTests.CacheTests
{
    public class CacheFacadeTests
    {
        private readonly CacheFacade cache;

        public CacheFacadeTests()
        {
            this.cache = new CacheFacade();
        }

        [Fact]
        public void Save_WhenKeyNotImplementsHashCode_ThenThrowArgumentException()
        {
            ClassWithoutHashCodeImplemented obj = new ClassWithoutHashCodeImplemented();

            Action act = () =>
            {
                string someString = "";
                this.cache.Save(someString, obj);
            };

            act.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void Get_WhenKeyNotImplementsHashCode_ThenThrowArgumentException()
        {
            ClassWithoutHashCodeImplemented key = new ClassWithoutHashCodeImplemented();

            Action act = () =>
            {
                this.cache.Get<string>(key);
            };

            act.Should().ThrowExactly<ArgumentException>();
        }

        private class ClassWithoutHashCodeImplemented
        {
            public override int GetHashCode()
            {
                throw new NotImplementedException(); 
            }
        }
    }
}
