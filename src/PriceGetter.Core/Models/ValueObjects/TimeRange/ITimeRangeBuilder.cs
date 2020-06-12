using PriceGetter.Core.Interfaces;
using System;

namespace PriceGetter.Core.Models.ValueObjects.TimeRange
{
    public interface ITimeRangeBuilder : IValueObjectBuilder<TimeRange>
    {
        TimeRangeBuilder From(DateTime dateTime);
        TimeRangeBuilder FromNow();
        TimeRangeBuilder To(DateTime datetime);
        TimeRangeBuilder ToNow();
    }
}