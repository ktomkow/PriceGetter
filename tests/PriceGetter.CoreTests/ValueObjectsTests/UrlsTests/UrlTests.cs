using FluentAssertions;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.CoreTests.ValueObjectsTests.UrlsTests
{
    public class UrlTests
    {
        [Fact]
        public void FromString_WhenEmptyString_ThenCreateEmptyUrl()
        {
            string text = string.Empty;

            Url url = Url.FromString(text);

            url.Should().BeOfType(typeof(EmptyUrl));
        }

        [Fact]
        public void FromString_WhenWhitespace_ThenCreateEmptyUrl()
        {
            string text = " ";

            Url url = Url.FromString(text);

            url.Should().BeOfType(typeof(EmptyUrl));
        }

        [Fact]
        public void FromString_WhenNull_ThenCreateEmptyUrl()
        {
            Url url = Url.FromString(null);

            url.Should().BeOfType(typeof(EmptyUrl));
        }

        [Theory]
        [InlineData("abcdefghijk")]
        [InlineData("124124")]
        [InlineData("aaa_http://someCoolAddress")]
        public void FromString_WhenNonEmptyStringNotStartFromHttpOrHttps_ThenException(string text)
        {
            Action act = () =>
            {
                Url url = Url.FromString(text);
            };

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("http://dupadupa.pl")]
        [InlineData("https://dupadupa.pl")]
        [InlineData("http://jksigwnjgnslkdg")]
        [InlineData("https://jksigwnjgnslkdg")]
        public void FromString_WhenNonEmptyStringStartFromHttpOrHttps_ThenCreateUrl(string text)
        {
            Url url = Url.FromString(text);

            url.Should().BeOfType(typeof(Url));
        }
    }
}
