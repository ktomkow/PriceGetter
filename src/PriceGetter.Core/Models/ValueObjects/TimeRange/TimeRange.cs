using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects.TimeRange
{
    public abstract partial class TimeRange : ValueObjectBase
    {
        public abstract bool IsInRange(DateTime dateTime);

        public static TimeRangeBuilder GetBuilder()
        {
            return new TimeRangeBuilder();
        }
    }
}
