using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Exceptions
{
    public class EntityNotFoundException : ArgumentException
    {
        public EntityNotFoundException(string message, string paramName) : base(message, paramName) { }
    }
}
