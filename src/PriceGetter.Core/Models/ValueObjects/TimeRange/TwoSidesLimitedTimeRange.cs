using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects.TimeRange
{
    internal class TwoSidesLimitedTimeRange : TimeRange
    {
        private readonly LeftSideLimitedTimeRange leftSideLimitedRange;
        private readonly RightSideLimitedTimeRange rightSideLimitedTime;

        internal TwoSidesLimitedTimeRange(DateTime minDatetime, DateTime maxDatetime)
        {
            this.leftSideLimitedRange = new LeftSideLimitedTimeRange(minDatetime);
            this.rightSideLimitedTime = new RightSideLimitedTimeRange(maxDatetime);
        }

        public override bool IsInRange(DateTime dateTime)
        {
            return this.leftSideLimitedRange.IsInRange(dateTime) && this.rightSideLimitedTime.IsInRange(dateTime);
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
