using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Web.Tools.Unbaser;
using Xunit;

namespace PriceGetter.WebTests.Tools 
{ 
    public class UnbaserTests
    {
        private IUrlUnbaser urlUnbaser;

        public UnbaserTests()
        {
            IUnbaser unbaser = new Unbaser();
            this.urlUnbaser = new UrlUnbaser(unbaser);
        }

        [Theory]
        [MemberData(nameof(Data_OnlyStrings))]
        public void ToBase64_ThenBack_ShouldBeSameAsOriginal(string original)
        {
            Url expectedUrl = new Url(original);
            string encodedOriginal = this.Encode(original);

            Url result = this.urlUnbaser.Unbase(encodedOriginal);

            result.Should().Be(expectedUrl);
        }

        [Theory]
        [MemberData(nameof(Data_EncodedAndExpected))]
        public void Decoded_Should_BeEqualToExpected(string encoded, string expected)
        {
            Url expectedUrl = new Url(expected);

            Url result = this.urlUnbaser.Unbase(encoded);

            result.Should().Be(expectedUrl);
        }

        private string Encode(string text)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(text);
            string encodedText = Convert.ToBase64String(plainTextBytes);
            return encodedText;
        }

        public static IEnumerable<object[]> Data_OnlyStrings =>
            new List<object[]>
            {
                new object[] { "http://www.dupa.pl" },
                new object[] { "https://www.dupa.pl" },
                new object[] { "http://el-poco.com" }
            };

        public static IEnumerable<object[]> Data_EncodedAndExpected =>
            new List<object[]>
            {
                new object[] { "aHR0cDovL3d3dy5kdXBhLnBs", "http://www.dupa.pl" },
                new object[] { "aHR0cHM6Ly93d3cuZHVwYS5wbA==", "https://www.dupa.pl" },
                new object[] { "aHR0cDovL2VsLXBvY28uY29t", "http://el-poco.com" }
            };
    }
}
