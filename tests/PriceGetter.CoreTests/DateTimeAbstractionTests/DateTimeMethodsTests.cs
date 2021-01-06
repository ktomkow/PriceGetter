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

        [Theory]
        [InlineData(-1)]
        [InlineData(24)]
        [InlineData(25)]
        [InlineData(-100)]
        [InlineData(1248)]
        [InlineData(-125619)]
        public void TommorowAt_IfArgumentOutOfRange_ShouldThrowArgumentException(int hour)
        {
            Action act = () =>
            {
                DateTime result = DateTimeMethods.TommorowAt(hour);
            };

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(23)]
        [InlineData(15)]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(5)]
        public void TommorowAt_IfArgumentInRange_ShouldNotThrow(int hour)
        {
            Action act = () =>
            {
                DateTime result = DateTimeMethods.TommorowAt(hour);
            };

            act.Should().NotThrow<ArgumentException>();
        }
    }
}
