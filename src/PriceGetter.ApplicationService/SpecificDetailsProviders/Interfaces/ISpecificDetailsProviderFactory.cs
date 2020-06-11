using System;
using System.Collections.Generic;
using System.Text;

namespace PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces
{
    public interface ISpecificDetailsProviderFactory
    {
        ISpecificDetailsProvider Get(string url);
    }
}
