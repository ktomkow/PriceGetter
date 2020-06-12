using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects.TimeRange
{
    internal class RightSideLimitedTimeRange : TimeRange
    {
        private readonly DateTime maxDatetime;

        internal RightSideLimitedTimeRange(DateTime dateTime)
        {
            this.maxDatetime = dateTime;
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override bool IsInRange(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
