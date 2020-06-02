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
    public class PriceTests
    {
        [Fact]
        public void WhenPrice9p99_Then_Value9p99()
        {
            decimal originalPrice = 9.99m;
            decimal expectedPrice = 9.99m;

            Price price = new Price(originalPrice);
            decimal obtainedPrice = price.Value;

            obtainedPrice.Should().Be(expectedPrice);
        }

        [Fact]
        public void WhenPrice9p9900_Then_Value9p99()
        {
            decimal originalPrice = 9.9900m;
            decimal expectedPrice = 9.99m;

            Price price = new Price(originalPrice);
            decimal obtainedPrice = price.Value;

            obtainedPrice.Should().Be(expectedPrice);
        }

        //[Fact]
        //public void WhenPrice9p991_Then_Value9p99() // TODO: TESTY ZAOKR¥GLANIA
        //{
        //    decimal originalPrice = 9.991m;
        //    decimal expectedPrice = 9.99m;

        //    Price price = new Price(originalPrice);
        //    decimal obtainedPrice = price.Value;

        //    obtainedPrice.Should().Be(expectedPrice);
        //}

        [Fact]
        public void WhenPrice0_Then_Value0p00()
        {
            decimal originalPrice = 0m;
            decimal expectedPrice = 0.00m;

            Price price = new Price(originalPrice);
            decimal obtainedPrice = price.Value;

            obtainedPrice.Should().Be(expectedPrice);
        }

        [Fact]
        public void WhenPriceFewerThan0_Then_ArgumentException()
        {
            decimal originalPrice = -0.12m;

            Action act = () =>
            {
                Price price = new Price(originalPrice);
            };

            act.Should().Throw<ArgumentException>();
        }

        # region Rounding

        [Theory]
        [MemberData(nameof(Data))]
        public void Construct_WhenMoreThan4Digits_ThenRound_CompareValues(decimal original, decimal expected)
        {
            Price price = new Price(original);
            Price expectedPrice = new Price(expected);

            bool result = price.Value == expectedPrice.Value;

            result.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Construct_WhenMoreThan4Digits_ThenRound_ComparePrices(decimal original, decimal expected)
        {
            Price price = new Price(original);
            Price expectedPrice = new Price(expected);

            bool result = price == expectedPrice;

            result.Should().BeTrue();
        }

        # endregion

        #region Equals

        [Fact]
        public void Equals_WhenTwoPrices9p99_Then_True()
        {
            Price onePrice = new Price(9.99m);
            Price twoPrice = new Price(9.99m);

            bool result = onePrice.Equals(twoPrice);

            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsOperator_WhenTwoPrices9p99_Then_True()
        {
            Price onePrice = new Price(9.99m);
            Price twoPrice = new Price(9.99m);

            bool result = onePrice == twoPrice;

            result.Should().BeTrue();
        }

        [Fact]
        public void EqualsOperatorNegation_WhenTwoPrices9p99_Then_False()
        {
            Price onePrice = new Price(9.99m);
            Price twoPrice = new Price(9.99m);

            bool result = onePrice != twoPrice;

            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_When9p99_And_9p98_Then_False()
        {
            Price onePrice = new Price(9.99m);
            Price twoPrice = new Price(9.98m);

            bool result = onePrice.Equals(twoPrice);

            result.Should().BeFalse();
        }

        [Fact]
        public void EqualsOperator_When9p99_And_9p98_Then_False()
        {
            Price onePrice = new Price(9.99m);
            Price twoPrice = new Price(9.98m);

            bool result = onePrice == twoPrice;

            result.Should().BeFalse();
        }

        #endregion

        #region Operators other than equal

        #region >

        [Fact]
        public void GreaterOperator_When_10_5_Then_True()
        {
            Price leftPrice = new Price(10.0m);
            Price rightPrice = new Price(5.0m);

            bool result = leftPrice > rightPrice;

            result.Should().BeTrue();
        }

        [Fact]
        public void GreaterOperator_When_5_10_Then_False()
        {
            Price leftPrice = new Price(5.0m);
            Price rightPrice = new Price(10.0m);

            bool result = leftPrice > rightPrice;

            result.Should().BeFalse();
        }

        [Fact]
        public void GreaterOperator_When_10_10_Then_False()
        {
            Price leftPrice = new Price(10.0m);
            Price rightPrice = new Price(10.0m);

            bool result = leftPrice > rightPrice;

            result.Should().BeFalse();
        }

        #endregion

        #region <

        [Fact]
        public void LowerOperator_When_10_5_Then_False()
        {
            Price leftPrice = new Price(10.0m);
            Price rightPrice = new Price(5.0m);

            bool result = leftPrice < rightPrice;

            result.Should().BeFalse();
        }

        [Fact]
        public void LowerOperator_When_5_10_Then_True()
        {
            Price leftPrice = new Price(5.0m);
            Price rightPrice = new Price(10.0m);

            bool result = leftPrice < rightPrice;

            result.Should().BeTrue();
        }

        [Fact]
        public void LowerOperator_When_10_10_Then_False()
        {
            Price leftPrice = new Price(10.0m);
            Price rightPrice = new Price(10.0m);

            bool result = leftPrice < rightPrice;

            result.Should().BeFalse();
        }

        #endregion

        #region >=

        [Fact]
        public void GreaterEqualOperator_When_10_5_Then_True()
        {
            Price leftPrice = new Price(10.0m);
            Price rightPrice = new Price(5.0m);

            bool result = leftPrice >= rightPrice;

            result.Should().BeTrue();
        }

        [Fact]
        public void GreaterEqualOperator_When_5_10_Then_False()
        {
            Price leftPrice = new Price(5.0m);
            Price rightPrice = new Price(10.0m);

            bool result = leftPrice >= rightPrice;

            result.Should().BeFalse();
        }

        [Fact]
        public void GreaterEqualOperator_When_10_10_Then_True()
        {
            Price leftPrice = new Price(10.0m);
            Price rightPrice = new Price(10.0m);

            bool result = leftPrice >= rightPrice;

            result.Should().BeTrue();
        }

        #endregion

        #region <=

        [Fact]
        public void LowerEqualOperator_When_10_5_Then_False()
        {
            Price leftPrice = new Price(10.0m);
            Price rightPrice = new Price(5.0m);

            bool result = leftPrice <= rightPrice;

            result.Should().BeFalse();
        }

        [Fact]
        public void LowerEqualOperator_When_5_10_Then_True()
        {
            Price leftPrice = new Price(5.0m);
            Price rightPrice = new Price(10.0m);

            bool result = leftPrice <= rightPrice;

            result.Should().BeTrue();
        }

        [Fact]
        public void LowerEqualOperator_When_10_10_Then_True()
        {
            Price leftPrice = new Price(10.0m);
            Price rightPrice = new Price(10.0m);

            bool result = leftPrice <= rightPrice;

            result.Should().BeTrue();
        }

        #endregion

        #region +

        [Fact]
        public void AddOperator_When_9p90_And_10p9_Then_20p8()
        {
            Price leftPrice = new Price(9.90m);
            Price rightPrice = new Price(10.9m);
            Price sum = new Price(20.8m);

            Price result = leftPrice + rightPrice;

            result.Should().Be(sum);
        }

        #endregion

        #region -

        [Fact]
        public void SubtractOperator_When_19p90_And_10p9_Then_9()
        {
            Price leftPrice = new Price(19.90m);
            Price rightPrice = new Price(10.9m);
            Price sum = new Price(9m);

            Price result = leftPrice - rightPrice;

            result.Should().Be(sum);
        }

        [Fact]
        public void SubtractOperator_When_19p90_And_20p9_Then_0()
        {
            Price leftPrice = new Price(19.90m);
            Price rightPrice = new Price(20.9m);
            Price sum = new Price(0m);

            Price result = leftPrice - rightPrice;

            result.Should().Be(sum);
        }

        #endregion

        #region /

        [Fact]
        public void DivideOperator_When_9p90_And_Divider_2_Then_4p95()
        {
            Price price = new Price(9.90m);
            Price expectedPrice = new Price(4.95m);
            int divider = 2;

            Price result = price / divider;

            result.Should().Be(expectedPrice);
        }

        [Fact]
        public void DivideOperator_When_9p90_And_Divider_Negative2_Then_4p95()
        {
            Price price = new Price(9.90m);
            Price expectedPrice = new Price(4.95m);
            int divider = -2;

            Price result = price / divider;

            result.Should().Be(expectedPrice);
        }

        [Fact]
        public void DivideOperator_When_9p90_And_Divider_0_Then_InvalidOperationException()
        {
            Price price = new Price(9.90m);
            int divider = 0;

            Action act = () =>
            {
                Price result = price / divider;
            };

            act.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact]
        public void DivideOperator_When_10_And_Divider_3_Then_3p3333()
        {
            Price price = new Price(10m);
            Price expectedPrice = new Price(3.3333m);
            int divider = 3;

            Price result = price / divider;

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
