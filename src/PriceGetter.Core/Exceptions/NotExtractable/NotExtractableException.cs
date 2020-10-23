using System;

namespace PriceGetter.Core.Exceptions.NotExtractable
{
    public class NotExtractableException : Exception
    {
        public NotExtractableException(string message) : base(message)
        {
        }
    }
}
