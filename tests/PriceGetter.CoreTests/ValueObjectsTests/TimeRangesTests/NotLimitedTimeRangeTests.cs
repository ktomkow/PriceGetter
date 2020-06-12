using FluentAssertions;
using PriceGetter.Core.Models.ValueObjects.TimeRange;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceGetter.CoreTests.ValueObjectsTests.TimeRangesTests
{
    public class NotLimitedTimeRangeTests
    {
        [Fact]
        public void WhenDefaultDatetime_Then_IsInRange()
        {
            TimeRange range = TimeRange.GetBuilder().Build();

            DateTime dateTime = new DateTime();

            bool result = range.IsInRange(dateTime);

            result.Should().BeTrue();
        }

        [Fact]
        public void WhenNow_Then_IsInRange()
        {
            TimeRange range = TimeRange.GetBuilder().Build();

            DateTime dateTime = DateTime.Now;

            bool result = range.IsInRange(dateTime);

            result.Should().BeTrue();
        }

        [Fact]
        public void WhenUtcNow_Then_IsInRange()
        {
            TimeRange range = TimeRange.GetBuilder().Build();

            DateTime dateTime = DateTime.UtcNow;

            bool result = range.IsInRange(dateTime);

            result.Should().BeTrue();
        }

        [Fact]
        public void WhenMaxDatetime_Then_IsInRange()
        {
            TimeRange range = TimeRange.GetBuilder().Build();

            DateTime dateTime = DateTime.MaxValue;

            bool result = range.IsInRange(dateTime);

            result.Should().BeTrue();
        }

        [Fact]
        public void WhenMinDatetime_Then_IsInRange()
        {
            TimeRange range = TimeRange.GetBuilder().Build();

            DateTime dateTime = DateTime.MinValue;

            bool result = range.IsInRange(dateTime);

            result.Should().BeTrue();
        }

        [Fact]
        public void When1st1st1970Datetime_Then_IsInRange()
        {
            TimeRange range = TimeRange.GetBuilder().Build();

            DateTime dateTime = new DateTime(1970, 1, 1);

            bool result = range.IsInRange(dateTime);

            result.Should().BeTrue();
        }
    }
}
