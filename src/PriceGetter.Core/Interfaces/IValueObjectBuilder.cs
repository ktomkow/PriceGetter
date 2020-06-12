using PriceGetter.Core.BaseClasses.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Core.Interfaces
{
    public interface IValueObjectBuilder<T> where T : ValueObjectBase
    {
        T Build();
    }
}
