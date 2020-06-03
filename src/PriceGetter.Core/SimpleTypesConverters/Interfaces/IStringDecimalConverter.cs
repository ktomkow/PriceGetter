using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.SimpleTypesConverters.Interfaces
{
    public interface IStringDecimalConverter
    {
        decimal ToDecimal(string value);
    }
}
