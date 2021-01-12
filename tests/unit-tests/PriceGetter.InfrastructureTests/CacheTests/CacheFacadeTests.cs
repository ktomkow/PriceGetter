using FluentAssertions;
using NSubstitute;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Cache;
using PriceGetter.Infrastructure.Logging;
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
            var logger = Substitute.For<IPriceGetterLogger>();
            this.cache = new CacheFacade(logger);
        }

        [Fact]
        public void Get_OtherTypeWantedThanStored_ShouldReturnDefaultValue_int()
        {
            int key = 102;
            int storedInt = 33;

            this.cache.Save(storedInt, key);
            decimal result = this.cache.Get<decimal>(key);

            result.Should().Be(0);
        }

        [Fact]
        public void Get_OtherTypeWantedThanStored_ShouldReturnDefaultValue_string()
        {
            int key = 102;
            int storedInt = 33;

            this.cache.Save(storedInt, key);
            string result = this.cache.Get<string>(key);

            result.Should().BeNull();
        }


        [Fact]
        public void Get_OtherTypeWantedThanStored_ShouldReturnDefaultValue_referenceType()
        {
            int key = 102;
            int storedInt = 33;

            this.cache.Save(storedInt, key);
            ClassWithoutHashCodeImplemented result = this.cache.Get<ClassWithoutHashCodeImplemented>(key);

            result.Should().BeNull();
        }

        [Fact]
        public void Get_OtherTypeWantedThanStored_ShouldReturnDefaultValue_Money()
        {
            int key = 102;
            int storedInt = 33;

            this.cache.Save(storedInt, key);
            Money result = this.cache.Get<Money>(key);

            result.Should().BeNull();
        }

        [Fact]
        public void Get_WhenNoObjectWithGivenKey_ShouldReturnDefaultValue_int()
        {
            int key = 102;

            int result = this.cache.Get<int>(key);

            result.Should().Be(0);
        }

        [Fact]
        public void Get_WhenNoObjectWithGivenKey_ShouldReturnDefaultValue_string()
        {
            int key = 102;

            string result = this.cache.Get<string>(key);

            result.Should().BeNull();
        }

        [Fact]
        public void Get_WhenNoObjectWithGivenKey_ShouldReturnDefaultValue_decimal()
        {
            int key = 102;

            decimal result = this.cache.Get<decimal>(key);

            result.Should().Be(0.0m);
        }

        [Fact]
        public void Get_WhenNoObjectWithGivenKey_ShouldReturnDefaultValue_referenceType()
        {
            int key = 102;

            ClassWithoutHashCodeImplemented result = this.cache.Get<ClassWithoutHashCodeImplemented>(key);

            result.Should().BeNull();
        }

        [Fact]
        public void Save_And_Get_ShouldBeTheSame_Money()
        {
            string key = "someStringKey";
            Money moneyToSave = new Money(10.0m);
            Money moneyFromCache;

            this.cache.Save(moneyToSave, key);
            moneyFromCache = this.cache.Get<Money>(key);

            moneyFromCache.Should().Be(moneyToSave);
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
            
        [Fact]
        public void Reset_WhenObjectSavedAndCacheReset_ThenReturnDefault()
        {
            string key = "key";
            int storedInt = 123;

            this.cache.Save(storedInt, key);

            int intFromCache = this.cache.Get<int>(key);
            intFromCache.Should().Be(123);

            this.cache.Reset<int>(key);

            int secondIntFromCache = this.cache.Get<int>(key);
            secondIntFromCache.Should().Be(default(int));
        }

        [Fact]
        public void Reset_WhenObjectNotSetButReset_ThenNothingHappens()
        {
            string key = "key";

            this.cache.Reset<int>(key);
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
