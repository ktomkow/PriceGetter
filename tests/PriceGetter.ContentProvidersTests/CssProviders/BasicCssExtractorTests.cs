using FluentAssertions;
using PriceGetter.ContentProvider.CssExtractors;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.ContentProvidersTests.CssProviders
{
    public class BasicCssExtractorTests
    {
        private readonly BasicCssExtractor extractor;

        public BasicCssExtractorTests()
        {
            this.extractor = new BasicCssExtractor();
        }

        [Fact]
        public void WhenHtmlNull_Then_ReturnEmptyString()
        {
            Html html = null;
            CssClass css = new CssClass("anything");

            string result = this.extractor.Extract(html, css);

            result.Should().BeEmpty();
        }

        [Fact]
        public void WhenCssNull_Then_ReturnEmptyString()
        {
            Html html = new Html(string.Empty);
            CssClass css = null;

            string result = this.extractor.Extract(html, css);

            result.Should().BeEmpty();
        }

        [Fact]
        public void WhenHtmlEmpty_Then_ReturnEmptyString()
        {
            Html html = new Html(string.Empty);
            CssClass css = new CssClass("anything");

            string result = this.extractor.Extract(html, css);

            result.Should().BeEmpty();
        }

        [Fact]
        public void WhenNoElementFound_Then_ReturnEmptyString()
        {
            Html html = new Html("<div class=\"some-class\"></div>");
            CssClass css = new CssClass("anything");

            string result = this.extractor.Extract(html, css);

            result.Should().BeEmpty();
        }

        [Fact]
        public void WhenFoundElementEmpty_Then_ReturnEmptyString()
        {
            string wantedCssClass = "wanted-class";
            string content = string.Empty;
            Html html = new Html($"<div class=\"{wantedCssClass}\">{content}</div>");
            CssClass css = new CssClass(wantedCssClass);

            string result = this.extractor.Extract(html, css);

            result.Should().Be(content);
            result.Should().BeEmpty();
        }

        [Fact]
        public void WhenFoundElement_Then_ReturnContent()
        {
            string wantedCssClass = "wanted-class";
            string content = "Some text";
            Html html = new Html($"<div class=\"{wantedCssClass}\">{content}</div>");
            CssClass css = new CssClass(wantedCssClass);

            string result = this.extractor.Extract(html, css);

            result.Should().Be(content);
        }

        [Theory]
        [InlineData("<div class=\"wanted-class\">Text</div>")]
        public void WhenFoundElement_Then_ReturnContent_Theory(string rawHtml)
        {
            string wantedCssClass = "wanted-class";
            string expectedContext = "Text";
            Html html = new Html(rawHtml);
            CssClass css = new CssClass(wantedCssClass);

            string result = this.extractor.Extract(html, css);

            result.Should().Be(expectedContext);
        }

        [Fact]
        public void WhenFoundTwoElements_Then_ReturnFirstContent()
        {
            string wantedCssClass = "wanted-class";
            string content1 = "Some text";
            string content2 = "Some other text";
            Html html = new Html($"<html><div class=\"{wantedCssClass}\">{content1}</div><div class=\"{wantedCssClass}\">{content2}</div>");
            CssClass css = new CssClass(wantedCssClass);

            string result = this.extractor.Extract(html, css);

            result.Should().Be(content1);
        }
    }
}
