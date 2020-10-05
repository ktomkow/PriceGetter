using FluentAssertions;
using PriceGetter.PersistenceMongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PriceGetter.PersistenceMongoTests.Tools
{
    public class CollectionsTests
    {
        [Fact]
        public void All_ShouldNotBeEmpty()
        {
            Collections.All().Should().NotBeEmpty();
        }

        [Theory]
        [InlineData("Products")]
        public void Should_Contain_CriticalCollections(string collectionName)
        {
            IEnumerable<string> collections = Collections.All();

            collections
                .SingleOrDefault(x => x == collectionName)
                .Should().NotBeNullOrEmpty();
        }
    }
}
