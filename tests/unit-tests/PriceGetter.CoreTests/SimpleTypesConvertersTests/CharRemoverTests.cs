using FluentAssertions;
using PriceGetter.Core.SimpleTypesConverters.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.CoreTests.SimpleTypesConvertersTests
{
    public class CharRemoverTests
    {
        private readonly CharRemover remover;

        public CharRemoverTests()
        {
            this.remover = new CharRemover();
        }

        [Fact]
        public void Remove_WhenNoCharInString_ThenReturnOriginalString()
        {
            string originalText = "Dupa";
            string expectedText = "Dupa";
            char characterToRemove = 'k';

            string obtainedText = this.remover.Remove(originalText, characterToRemove);

            obtainedText.Should().Be(expectedText);
        }

        [Fact]
        public void Remove_WhenEmptyString_ThenReturnEmptyString()
        {
            string originalText = "";
            string expectedText = "";
            char characterToRemove = 'k';

            string obtainedText = this.remover.Remove(originalText, characterToRemove);

            obtainedText.Should().Be(expectedText);
        }

        [Fact]
        public void Remove_WhenOneCharInString_ThenRemoveThisChar()
        {
            string originalText = "Dupa";
            string expectedText = "Dpa";
            char characterToRemove = 'u';

            string obtainedText = this.remover.Remove(originalText, characterToRemove);

            obtainedText.Should().Be(expectedText);
        }

        [Fact]
        public void Remove_WhenTwoCharsInString_ThenRemoveTheChars()
        {
            string originalText = "Dupa1 dupa2";
            string expectedText = "Dup1 dup2";
            char characterToRemove = 'a';

            string obtainedText = this.remover.Remove(originalText, characterToRemove);

            obtainedText.Should().Be(expectedText);
        }

        [Fact]
        public void Remove_WhenThreeCharsNextToEachotherInString_ThenRemoveTheChars()
        {
            string originalText = "Duuupa";
            string expectedText = "Dpa";
            char characterToRemove = 'u';

            string obtainedText = this.remover.Remove(originalText, characterToRemove);

            obtainedText.Should().Be(expectedText);
        }

        [Fact]
        public void Remove_WhenSpaceToRemove_ThenRemoveSpace()
        {
            string originalText = "Dupa dupa";
            string expectedText = "Dupadupa";
            char characterToRemove = ' ';

            string obtainedText = this.remover.Remove(originalText, characterToRemove);

            obtainedText.Should().Be(expectedText);
        }
    }
}
