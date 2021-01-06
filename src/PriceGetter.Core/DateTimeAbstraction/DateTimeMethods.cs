using System;

namespace PriceGetter.Core.DateTimeAbstraction
{
    public static class DateTimeMethods
    {
        private static IDateTimeProvider DateTimeProvider = new DateTimeProvider();

        public static DateTime UtcNow()
        {
            return DateTimeProvider.UtcNow();
        }

        public static DateTime TommorowAt(int hour)
        {
            if(hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hour));
            }

            return UtcNow().AddDays(1).Date.AddHours(hour);
        }

        public static void OverrideDateTimeProvider(IDateTimeProvider newProvider)
        {
            DateTimeProvider = newProvider;
        }

        public static void Reset()
        {
            DateTimeProvider = new DateTimeProvider();
        }
    }
}