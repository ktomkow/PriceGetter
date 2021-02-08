using System;

namespace PriceGetter.Infrastructure.Logging
{
    public interface IPriceGetterLogger
    {
        void Information(string text);
        void Debug(string text);
        void Debug(Exception exception, string text);
        void Error(string text);
        void Error(Exception exception, string text);
        void Fatal(string text);
        void Fatal(Exception exception, string text);
    }
}
