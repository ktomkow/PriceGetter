using System;

namespace PriceGetter.Core.DateTimeAbstraction
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow();
    }
}