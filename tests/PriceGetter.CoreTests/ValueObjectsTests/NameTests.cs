using FluentAssertions;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PriceGetter.CoreTests.ValueObjectsTests
{
    public class NameTests
    {
        [Theory]
        [InlineData("a")]
        [InlineData("ne")]
        [InlineData("Du")]
        [InlineData("001")]
        public void Ctor_WhenNameShorterThan4_ShouldThrowException(string originalName)
        {
            Action act = () =>
            {
                Name name = new Name(originalName);
            };

            act.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void Ctor_WhenNameLongerThan100_ShouldThrowException()
        {
            string originalName = "";

            for(int i = 0; i < 102; i++)
            {
                originalName = originalName + 'i';
            }

            Action act = () =>
            {
                Name name = new Name(originalName);
            };

            act.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void Ctor_WhenNameNull_ShouldThrowException()
        {
            string originalName = null;

            Action act = () =>
            {
                Name name = new Name(originalName);
            };

            act.Should().ThrowExactly<ArgumentException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("  ")]
        [InlineData("\n")]
        [InlineData("\t")]
        [InlineData("\t          \n")]
        public void Ctor_WhenNameIsWhitespaceOrEmpty_ShouldThrowException(string originalName)
        {
            Action act = () =>
            {
                Name name = new Name(originalName);
            };

            act.Should().ThrowExactly<ArgumentException>();
        }

        [Theory]
        [InlineData("    a")]
        [InlineData("a    ")]
        [InlineData("    a          ")]
        [InlineData("    a a        ")]
        public void Ctor_WhenNameAfterTrimShorterThan4_ShouldThrowException(string originalName)
        {
            Action act = () =>
            {
                Name name = new Name(originalName);
            };

            act.Should().ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void Ctor_WhenNameValid_ShouldNotTurnFirstLetterUppercase()
        {
            string originalName = "my valid name";

            Name name = new Name(originalName);

            name.Value.First().Should().Be('m');
        }

        [Fact]
        public void Ctor_WhenNameValid_ShouldNotTurnFirstLetterLowercase()
        {
            string originalName = "My valid name";

            Name name = new Name(originalName);

            name.Value.First().Should().Be('M');
        }

        [Theory]
        [InlineData("My valid name ", "My valid name")]
        [InlineData(" My valid name", "My valid name")]
        [InlineData(" My valid name ", "My valid name")]
        [InlineData("\tMy valid name ", "My valid name")]
        [InlineData("\nMy valid name ", "My valid name")]
        [InlineData("My valid name \n\n", "My valid name")]
        [InlineData("      My valid name ", "My valid name")]
        public void Ctor_WhenNameValid_ShouldTrim(string originalName, string expectedName)
        {
            Name name = new Name(originalName);

            name.Value.Should().Be(expectedName);
        }
    }
}
