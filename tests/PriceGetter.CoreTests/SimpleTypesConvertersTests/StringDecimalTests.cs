using FluentAssertions;
using PriceGetter.Core.SimpleTypesConverters.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.CoreTests.SimpleTypesConvertersTests
{
    public class StringDecimalTests
    {
        private readonly StringDecimalConverter converter;

        public StringDecimalTests()
        {
            this.converter = new StringDecimalConverter();
        }

        [Theory]
        [MemberData(nameof(Data_DotDecimalDigitsSeparation))]
        public void ToDecimal_WhenUsedDot_ThenConvert(string value, decimal expectedResult)
        {
            decimal result = this.converter.ToDecimal(value);
            result.Should().Be(expectedResult);
        }

        public static IEnumerable<object[]> Data_DotDecimalDigitsSeparation =>
            new List<object[]>
            {
                new object[] { "0.0", 0.0m },
                new object[] { "1.0", 1.0m },
                new object[] { "1.99", 1.99m },
                new object[] { "10.0", 10.0m },
                new object[] { "10.00", 10.0m },
                new object[] { "10.000", 10.0m },
                new object[] { "10.0000", 10.0m },
                new object[] { "29.99", 29.99m },
                new object[] { "15990.00", 15990.0m },
                new object[] { "650000.00", 650000.00 },
                new object[] { "1000000.0000", 1000000.00 }
            };

        [Theory]
        [MemberData(nameof(Data_CommaDecimalDigitsSeparation))]
        public void ToDecimal_WhenUsedComma_ThenConvert(string value, decimal expectedResult)
        {
            decimal result = this.converter.ToDecimal(value);
            result.Should().Be(expectedResult);
        }

        public static IEnumerable<object[]> Data_CommaDecimalDigitsSeparation =>
            new List<object[]>
            {
                new object[] { "0,0", 0.0m },
                new object[] { "1,0", 1.0m },
                new object[] { "1,99", 1.99m },
                new object[] { "10,0", 10.0m },
                new object[] { "10,00", 10.0m },
                new object[] { "10,000", 10.0m },
                new object[] { "10,0000", 10.0m },
                new object[] { "29,99", 29.99m },
                new object[] { "15990,00", 15990.0m },
                new object[] { "650000,00", 650000.00 },
                new object[] { "1000000,0000", 1000000.00 }
            };

        [Theory]
        [MemberData(nameof(Data_ThousandSpaceSeparation_DecimalDigitsCommaAndDots))]
        public void ToDecimal_WhenSpaceThousandSeparationUsed_ThenConvert(string value, decimal expectedResult)
        {
            decimal result = this.converter.ToDecimal(value);
            result.Should().Be(expectedResult);
        }

        public static IEnumerable<object[]> Data_ThousandSpaceSeparation_DecimalDigitsCommaAndDots =>
            new List<object[]>
            {
                new object[] { "0 000,0", 0.0m },
                new object[] { "0 000.0", 0.0m },
                new object[] { "2 199,99", 2199.99m },
                new object[] { "2 199.99", 2199.99m },
                new object[] { "3 499,50", 3499.5m },
                new object[] { "3 499.50", 3499.5m },
                new object[] { "49 749,99", 49749.99m },
                new object[] { "49 749.99", 49749.99m },
                new object[] { "1 999 999,99", 1999999.99m },
                new object[] { "1 999 999.99", 1999999.99m },
            };

        [Theory]
        [MemberData(nameof(Data_ThousandDotSeparation_DecimalDigitsCommaSeparation))]
        public void ToDecimal_WhenDotThousandSeparationUsedDecimalDigitsCommaSeparation_ThenConvert(string value, decimal expectedResult)
        {
            decimal result = this.converter.ToDecimal(value);
            result.Should().Be(expectedResult);
        }

        public static IEnumerable<object[]> Data_ThousandDotSeparation_DecimalDigitsCommaSeparation =>
            new List<object[]>
            {
                new object[] { "0.000,0", 0.0m },
                new object[] { "2.199,99", 2199.99m },
                new object[] { "3.499,50", 3499.5m },
                new object[] { "49.749,99", 49749.99m },
                new object[] { "1.999.999,99", 1999999.99m },
            };

        [Theory]
        [MemberData(nameof(Data_ThousandCommaSeparation_DecimalDigitsDotSeparation))]
        public void ToDecimal_WhenCommaThousandSeparationUsedDecimalDigitsDotsSeparation_ThenConvert(string value, decimal expectedResult)
        {
            decimal result = this.converter.ToDecimal(value);
            result.Should().Be(expectedResult);
        }

        public static IEnumerable<object[]> Data_ThousandCommaSeparation_DecimalDigitsDotSeparation =>
            new List<object[]>
            {
                new object[] { "0,000.0", 0.0m },
                new object[] { "2,199.99", 2199.99m },
                new object[] { "3,499.50", 3499.5m },
                new object[] { "49,749.99", 49749.99m },
                new object[] { "1,999,999.99", 1999999.99m },
            };
    }
}
