using PriceGetter.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces
{
    [Obsolete]
    public interface IDetailsProvider
    {
        Task<PreProductDto> GetAsync(string url);
    }
}
