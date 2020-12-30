using System;
using PriceGetter.Core.DateTimeAbstraction;

namespace PriceGetter.Core.Models.ValueObjects.TimeRange
{
    public class TimeRangeBuilder : ITimeRangeBuilder
    {
        private DateTime? from;
        private DateTime? to;

        internal TimeRangeBuilder()
        {
            this.from = null;
            this.to = null;
        }

        public TimeRange Build()
        {
            bool isFromEmpty = (this.from == null || this.from.Value == DateTime.MinValue);
            bool isToEmpty = (this.to == null || this.to.Value == DateTime.MaxValue);

            if(isFromEmpty && isToEmpty)
            {
                return new NotLimitedTimeRange();
            }

            if(isFromEmpty && !isToEmpty)
            {
                return new RightSideLimitedTimeRange(to.Value);
            }

            if (!isFromEmpty && isToEmpty)
            {
                return new LeftSideLimitedTimeRange(from.Value);
            }

            return new TwoSidesLimitedTimeRange(from.Value, to.Value);
        }

        public TimeRangeBuilder From(DateTime? dateTime)
        {
            this.from = dateTime;
            return this;
        }

        public TimeRangeBuilder FromNow()
        {
            this.from = DateTimeMethods.UtcNow();
            return this;
        }

        public TimeRangeBuilder To(DateTime? datetime)
        {
            this.to = datetime;
            return this;
        }

        public TimeRangeBuilder ToNow()
        {
            this.to = DateTimeMethods.UtcNow();
            return this;
        }
    }
}
