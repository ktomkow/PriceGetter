using FluentAssertions;
using PriceGetter.Core.Models.ValueObjects.TimeRange;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.CoreTests.ValueObjectsTests.TimeRangesTests
{
    public class TwoSidesLimitedTimeRangeTests
    {
        [Fact]
        public void WhenDateIsInRange_Then_ReturnTrue()
        {
            DateTime dateTimeFrom = new DateTime(1970, 1, 1);
            DateTime dateTimeTo = new DateTime(1970, 10, 30);
            DateTime checkedDatetime = new DateTime(1970, 5, 10);
            TimeRange range = TimeRange
                .GetBuilder()
                .From(dateTimeFrom)
                .To(dateTimeTo)
                .Build();

            bool result = range.IsInRange(checkedDatetime);

            result.Should().BeTrue();
        }
    }
}
