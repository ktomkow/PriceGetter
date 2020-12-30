using System;

using Xunit;
using FluentAssertions;

using PriceGetter.WebClients;
using PriceGetter.Core.Models.ValueObjects;

namespace PriceGetter.WebClientsTests
{
    /// <summary>
    /// Tests fake web client - web client should be used only during development, so these tests will fail on production.
    /// </summary>
    public class FakeWebClientTests
    {
        private readonly FakeGetterUseFile webClient;

        private readonly Url emptyUrl;

        public FakeWebClientTests()
        {
            this.webClient = new FakeGetterUseFile();
            this.emptyUrl = Url.FromString(string.Empty);
        }

        private Html Execute()
        {
            return this.webClient.GetAsync(this.emptyUrl).Result;
        }

        [Fact]
        public void GetAsync_ShouldNotThrow()
        {
            Action act = () => 
            {
                this.Execute();
            };

            act.Should().NotThrow();
        }

        [Fact]
        public void GetAsync_ShouldNotReturnNull()
        {
            Html result;

            result = this.Execute();

            result.Should().NotBeNull();
        }

        [Fact]
        public void GetAsync_ShouldNotReturnNullContent()
        {
            Html result;

            result = this.Execute();

            result.RawContent.Should().NotBeNull();
        }

        [Fact]
        public void GetAsync_ShouldNotReturnEmptyObject()
        {
            Html result;

            result = this.Execute();

            result.RawContent.Should().NotBeEmpty();
        }

        [Fact]
        public void GetAsync_ResultRawContent_ShouldNotBeNullOrWhitespace()
        {
            string rawContent = this.Execute().RawContent;

            bool result = string.IsNullOrWhiteSpace(rawContent);

            result.Should().BeFalse();
        }
    }
}