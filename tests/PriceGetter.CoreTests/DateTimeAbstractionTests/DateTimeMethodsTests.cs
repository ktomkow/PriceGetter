using FluentAssertions;
using NSubstitute;
using PriceGetter.Core.DateTimeAbstraction;
using PriceGetter.TestHelpers;
using System;
using Xunit;

namespace PriceGetter.CoreTests.DateTimeAbstractionTests
{
    public class DateTimeMethodsTests
    {
        [Fact]
        [ResetDateTimeAbstractions]
        public void UtcNow_OverrideProviderShouldBePossible()
        {
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            dateTimeProvider.UtcNow().Returns(new DateTime(2019, 1, 1, 10, 34, 20));
            DateTimeMethods.OverrideDateTimeProvider(dateTimeProvider);

            var now = DateTime.UtcNow.Date;

            DateTimeMethods.UtcNow().Date.Should().NotBe(now);
        }

        [Fact]
        [ResetDateTimeAbstractions]
        public void UtcNow_IfNothingChanged_ShouldActAsCommmonDateTimeUtcNow()
        {
            var now = DateTime.UtcNow.Date;

            DateTimeMethods.UtcNow().Date.Should().Be(now);
        }

        [Fact]
        [ResetDateTimeAbstractions]
        public void TommorowAt_WhenCurrentHourIsAfterDesiredHour()
        {
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            dateTimeProvider.UtcNow().Returns(new DateTime(2020, 12, 19, 10, 34, 20));
            DateTimeMethods.OverrideDateTimeProvider(dateTimeProvider);

            DateTime expectedResult = new DateTime(2020, 12, 20, 8, 0, 0);

            DateTime result = DateTimeMethods.TommorowAt(8);

            result.Should().Be(expectedResult);
        }

        [Fact]
        [ResetDateTimeAbstractions]
        public void TommorowAt_WhenCurrentHourIsBeforeDesiredHour()
        {
            IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();
            dateTimeProvider.UtcNow().Returns(new DateTime(2020, 12, 19, 5, 34, 20));
            DateTimeMethods.OverrideDateTimeProvider(dateTimeProvider);

            DateTime expectedResult = new DateTime(2020, 12, 20, 8, 0, 0);

            DateTime result = DateTimeMethods.TommorowAt(8);

            result.Should().Be(expectedResult);
        }
    }
}
