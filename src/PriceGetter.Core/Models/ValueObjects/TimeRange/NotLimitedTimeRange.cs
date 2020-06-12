using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Models.ValueObjects.TimeRange
{
    public class NotLimitedTimeRange : TimeRange
    {
        internal NotLimitedTimeRange() { }

        public override bool IsInRange(DateTime dateTime)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            bool typeMatch = base.EqualsType<NotLimitedTimeRange>(obj);

            if (typeMatch == false)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return 6397;
        }
    }
}
