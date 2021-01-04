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
    }
}
