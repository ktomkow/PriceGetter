using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.Infrastructure.Cache
{
    public interface ICacheFacade
    {
        TItem Get<TItem>(object key);
        void Save<TItem>(TItem obj, object key);
    }
}
