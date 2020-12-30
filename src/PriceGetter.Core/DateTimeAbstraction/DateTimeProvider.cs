using System;

namespace PriceGetter.Core.DateTimeAbstraction
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}