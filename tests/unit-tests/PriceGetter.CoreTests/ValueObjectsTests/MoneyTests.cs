using FluentAssertions;
using PriceGetter.Core.Models;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace PriceGetter.CoreTests.ValueObjectsTests
{
    public class MoneyTests
    {
        [Fact]
        public void WhenPrice9p99_Then_Value9p99()
        {
            decimal originalPrice = 9.99m;
            decimal expectedPrice = 9.99m;

            Money price = new Money(originalPrice);
            decimal obtainedPrice = price.ValueAsDecimal;

            obtainedPrice.Should().Be(expectedPrice);
        }

        [Fact]
        public void WhenPrice9p9900_Then_Value9p99()
        {
            decimal originalPrice = 9.9900m;
            decimal expectedPrice = 9.99m;

            Money price = new Money(originalPrice);
            decimal obtainedPrice = price.ValueAsDecimal;

            obtainedPrice.Should().Be(expectedPrice);
        }

        [Fact]
        public void WhenPrice9_Then_ValueAsString_9p00()
        {
            decimal originalPrice = 9m;
            string expectedPriceAsString = "9.00";

            Money price = new Money(originalPrice);
            string priceAsString = price.ValueAsString;

            priceAsString.Should().Be(expectedPriceAsString);
        }

        [Fact]
        public void WhenPrice9p9_Then_ValueAsString_9p90()
        {
            decimal originalPrice = 9.9m;
            string expectedPriceAsString = "9.90";

            Money price = new Money(originalPrice);
            string priceAsString = price.ValueAsString;

            priceAsString.Should().Be(expectedPriceAsString);
        }

        [Fact]
        public void WhenPrice9p999_Then_ValueAsString_10p00()
        {
            decimal originalPrice = 9.999m;
            string expectedPriceAsString = "10.00";

            Money price = new Money(originalPrice);
            string priceAsString = price.ValueAsString;

            priceAsString.Should().Be(expectedPriceAsString);
        }

        [Fact]
        public void WhenPrice9p995_Then_ValueAsString_10p00()
        {
            decimal originalPrice = 9.995m;
            string expectedPriceAsString = "10.00";

            Money price = new Money(originalPrice);
            string priceAsString = price.ValueAsString;

            priceAsString.Should().Be(expectedPriceAsString);
        }

        [Fact]
        public void WhenPrice9p994_Then_ValueAsString_9p99()
        {
            decimal originalPrice = 9.994m;
            string expectedPriceAsString = "9.99";

            Money price = new Money(originalPrice);
            string priceAsString = price.ValueAsString;

            priceAsString.Should().Be(expectedPriceAsString);
        }

        [Fact]
        public void WhenPrice0_Then_Value0p00()
        {
            decimal originalPrice = 0m;
            decimal expectedPrice = 0.00m;

            Money price = new Money(originalPrice);
            decimal obtainedPrice = price.ValueAsDecimal;

            obtainedPrice.Should().Be(expectedPrice);
        }

        [Fact]
        public void WhenPriceFewerThan0_Then_ArgumentException()
        {
            decimal originalPrice = -0.12m;

            Action act = () =>
            {
                Money price = new Money(originalPrice);
            };

            act.Should().Throw<ArgumentException>();
        }

        # region Rounding

        [Theory]
        [MemberData(nameof(Data))]
        public void Construct_WhenMoreThan4Digits_ThenRound_CompareValues(decimal original, decimal expected)
        {
            Money price = new Money(original);
            Money expectedPrice = new Money(expected);

            bool result = price.ValueAsDecimal == expectedPrice.ValueAsDecimal;

            result.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Construct_WhenMoreThan4Digits_ThenRound_ComparePrices(decimal original, decimal expected)
        {
            Money price = new Money(original);
            Money expectedPrice = new Money(expected);

            bool result = price == expectedPrice;

            result.Should().BeTrue();
        }

        # endregion

        #region Equals

        [Fact]
        public void Equals_WhenTwoPrices9p99_Then_True()
        {
            Money onePrice = new Money(9.99m);
            Money twoPrice = new Money(9.99m);

            bool result = onePrice.Equals(twoPrice);

            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsOperator_WhenTwoPrices9p99_Then_True()
        {
            Money onePrice = new Money(9.99m);
            Money twoPrice = new Money(9.99m);

            bool result = onePrice == twoPrice;

            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsOperatorNegation_WhenTwoPrices9p99_Then_False()
        {
            Money onePrice = new Money(9.99m);
            Money twoPrice = new Money(9.99m);

            bool result = onePrice != twoPrice;

            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_When9p99_And_9p98_Then_False()
        {
            Money onePrice = new Money(9.99m);
            Money twoPrice = new Money(9.98m);

            bool result = onePrice.Equals(twoPrice);

            result.Should().BeFalse();
        }

        [Fact]
        public void EqualsOperator_When9p99_And_9p98_Then_False()
        {
            Money onePrice = new Money(9.99m);
            Money twoPrice = new Money(9.98m);

            bool result = onePrice == twoPrice;

            result.Should().BeFalse();
        }

        #endregion

        #region Operators other than equal

        #region >

        [Fact]
        public void GreaterOperator_When_10_5_Then_True()
        {
            Money leftPrice = new Money(10.0m);
            Money rightPrice = new Money(5.0m);

            bool result = leftPrice > rightPrice;

            result.Should().BeTrue();
        }

        [Fact]
        public void GreaterOperator_When_5_10_Then_False()
        {
            Money leftPrice = new Money(5.0m);
            Money rightPrice = new Money(10.0m);

            bool result = leftPrice > rightPrice;

            result.Should().BeFalse();
        }

        [Fact]
        public void GreaterOperator_When_10_10_Then_False()
        {
            Money leftPrice = new Money(10.0m);
            Money rightPrice = new Money(10.0m);

            bool result = leftPrice > rightPrice;

            result.Should().BeFalse();
        }

        #endregion

        #region <

        [Fact]
        public void LowerOperator_When_10_5_Then_False()
        {
            Money leftPrice = new Money(10.0m);
            Money rightPrice = new Money(5.0m);

            bool result = leftPrice < rightPrice;

            result.Should().BeFalse();
        }

        [Fact]
        public void LowerOperator_When_5_10_Then_True()
        {
            Money leftPrice = new Money(5.0m);
            Money rightPrice = new Money(10.0m);

            bool result = leftPrice < rightPrice;

            result.Should().BeTrue();
        }

        [Fact]
        public void LowerOperator_When_10_10_Then_False()
        {
            Money leftPrice = new Money(10.0m);
            Money rightPrice = new Money(10.0m);

            bool result = leftPrice < rightPrice;

            result.Should().BeFalse();
        }

        #endregion

        #region >=

        [Fact]
        public void GreaterEqualOperator_When_10_5_Then_True()
        {
            Money leftPrice = new Money(10.0m);
            Money rightPrice = new Money(5.0m);

            bool result = leftPrice >= rightPrice;

            result.Should().BeTrue();
        }

        [Fact]
        public void GreaterEqualOperator_When_5_10_Then_False()
        {
            Money leftPrice = new Money(5.0m);
            Money rightPrice = new Money(10.0m);

            bool result = leftPrice >= rightPrice;

            result.Should().BeFalse();
        }

        [Fact]
        public void GreaterEqualOperator_When_10_10_Then_True()
        {
            Money leftPrice = new Money(10.0m);
            Money rightPrice = new Money(10.0m);

            bool result = leftPrice >= rightPrice;

            result.Should().BeTrue();
        }

        #endregion

        #region <=

        [Fact]
        public void LowerEqualOperator_When_10_5_Then_False()
        {
            Money leftPrice = new Money(10.0m);
            Money rightPrice = new Money(5.0m);

            bool result = leftPrice <= rightPrice;

            result.Should().BeFalse();
        }

        [Fact]
        public void LowerEqualOperator_When_5_10_Then_True()
        {
            Money leftPrice = new Money(5.0m);
            Money rightPrice = new Money(10.0m);

            bool result = leftPrice <= rightPrice;

            result.Should().BeTrue();
        }

        [Fact]
        public void LowerEqualOperator_When_10_10_Then_True()
        {
            Money leftPrice = new Money(10.0m);
            Money rightPrice = new Money(10.0m);

            bool result = leftPrice <= rightPrice;

            result.Should().BeTrue();
        }

        #endregion

        #region +

        [Fact]
        public void AddOperator_When_9p90_And_10p9_Then_20p8()
        {
            Money leftPrice = new Money(9.90m);
            Money rightPrice = new Money(10.9m);
            Money sum = new Money(20.8m);

            Money result = leftPrice + rightPrice;

            result.Should().Be(sum);
        }

        #endregion

        #region -

        [Fact]
        public void SubtractOperator_When_19p90_And_10p9_Then_9()
        {
            Money leftPrice = new Money(19.90m);
            Money rightPrice = new Money(10.9m);
            Money sum = new Money(9m);

            Money result = leftPrice - rightPrice;

            result.Should().Be(sum);
        }

        [Fact]
        public void SubtractOperator_When_19p90_And_20p9_Then_0()
        {
            Money leftPrice = new Money(19.90m);
            Money rightPrice = new Money(20.9m);
            Money sum = new Money(0m);

            Money result = leftPrice - rightPrice;

            result.Should().Be(sum);
        }

        #endregion

        #region /

        [Fact]
        public void DivideOperator_When_9p90_And_Divider_2_Then_4p95()
        {
            Money price = new Money(9.90m);
            Money expectedPrice = new Money(4.95m);
            int divider = 2;

            Money result = price / divider;

            result.Should().Be(expectedPrice);
        }

        [Fact]
        public void DivideOperator_When_9p90_And_Divider_Negative2_Then_4p95()
        {
            Money price = new Money(9.90m);
            Money expectedPrice = new Money(4.95m);
            int divider = -2;

            Money result = price / divider;

            result.Should().Be(expectedPrice);
        }

        [Fact]
        public void DivideOperator_When_9p90_And_Divider_0_Then_InvalidOperationException()
        {
            Money price = new Money(9.90m);
            int divider = 0;

            Action act = () =>
            {
                Money result = price / divider;
            };

            act.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact]
        public void DivideOperator_When_10_And_Divider_3_Then_3p3333()
        {
            Money price = new Money(10m);
            Money expectedPrice = new Money(3.3333m);
            int divider = 3;

            Money result = price / divider;

            result.Should().Be(expectedPrice);
        }

        #endregion

        #endregion

        #region TestData

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1m, 1.0000m },
                new object[] { 1.0m, 1.0000m },
                new object[] { 1.00m, 1.0000m },
                new object[] { 1.000m, 1.0000m },
                new object[] { 1.0000m, 1.0000m },
                new object[] { 1.9472m, 1.9472m },
                new object[] { 1.0060m, 1.0060m },
                new object[] { 1.0090m, 1.0090m },
                new object[] { 1.0001m, 1.0001m },
                new object[] { 1.0005m, 1.0005m },
                new object[] { 1.0009m, 1.0009m },
                new object[] { 1.00001m, 1.0000m },
                new object[] { 1.00005m, 1.0000m },
                new object[] { 1.000051m, 1.0001m },
                new object[] { 1.00009m, 1.0001m },
                new object[] { 1.000001m, 1.0000m },
                new object[] { 1.000005m, 1.0000m },
                new object[] { 1.000009m, 1.0000m },
                new object[] { 1.000099m, 1.0001m },
                new object[] { 1.000049m, 1.0000m },
                new object[] { 1.000059m, 1.0001m },
                new object[] { 1.94721m, 1.9472m },
                new object[] { 1.94724m, 1.9472m },
                new object[] { 1.94725m, 1.9472m },
                new object[] { 1.947251m, 1.9473m },
                new object[] { 1.94729m, 1.9473m },
                new object[] { 1.9999m, 1.9999m },
                new object[] { 1.89999m, 1.9000m },
                new object[] { 1.98999m, 1.9900m },
                new object[] { 1.99899m, 1.9990m },
                new object[] { 1.99989m, 1.9999m },
                new object[] { 1.99994m, 1.9999m },
                new object[] { 1.99995m, 2.0000m },
                new object[] { 1.99999m, 2.0000m },
            };

        #endregion
    }
}
