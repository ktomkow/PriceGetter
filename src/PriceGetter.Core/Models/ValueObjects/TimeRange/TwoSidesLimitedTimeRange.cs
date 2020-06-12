using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects.TimeRange
{
    internal class TwoSidesLimitedTimeRange : TimeRange
    {
        private readonly DateTime minDatetime;
        private readonly DateTime maxDatetime;

        internal TwoSidesLimitedTimeRange(DateTime minDatetime, DateTime maxDatetime)
        {
            this.minDatetime = minDatetime;
            this.maxDatetime = maxDatetime;
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
