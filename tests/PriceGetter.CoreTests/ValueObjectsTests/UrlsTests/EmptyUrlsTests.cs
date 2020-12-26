using FluentAssertions;
using PriceGetter.Core.Models.ValueObjects;
using Xunit;

namespace PriceGetter.CoreTests.ValueObjectsTests.UrlsTests
{
#pragma warning disable 1718
    public class EmptyUrlsTests
    {
        #region Equals
        [Fact]
        public void Equals_SameInstance_ShouldBeTrue()
        {
            EmptyUrl url = new EmptyUrl();

            bool result = url.Equals(url);

            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_TwoInstances_ShouldBeTrue()
        {
            EmptyUrl url1 = new EmptyUrl();
            EmptyUrl url2 = new EmptyUrl();

            bool result = url1.Equals(url2);

            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_CompareToNull_ShouldBeFalse()
        {
            EmptyUrl url1 = new EmptyUrl();
            EmptyUrl url2 = null;

            bool result = url1.Equals(url2);

            result.Should().BeFalse();
        }
        #endregion

        #region ==

        [Fact]
        public void EqualsOperator_SameInstance_ShouldBeTrue()
        {
            EmptyUrl url = new EmptyUrl();

            bool result = url == url;

            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsOperator_TwoInstances_ShouldBeTrue()
        {
            EmptyUrl url1 = new EmptyUrl();
            EmptyUrl url2 = new EmptyUrl();

            bool result = url1 == url2;

            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsOperator_CompareToNull_ShouldBeFalse()
        {
            EmptyUrl url1 = new EmptyUrl();
            EmptyUrl url2 = null;

            bool result = url1 == url2;

            result.Should().BeFalse();
        }

        #endregion
    }

    #pragma warning restore 1718
}
