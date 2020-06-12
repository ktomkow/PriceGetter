using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects.TimeRange
{
    internal class LeftSideLimitedTimeRange : TimeRange
    {
        private readonly DateTime minDateTime;

        internal LeftSideLimitedTimeRange(DateTime dateTime)
        {
            this.minDateTime = dateTime;
        }

        public override bool IsInRange(DateTime dateTime)
        {
            return dateTime > this.minDateTime;
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
