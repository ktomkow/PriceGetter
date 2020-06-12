using PriceGetter.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces
{
    public interface IDetailsProvider
    {
        Task<SellerSpecificDetailsDto> GetAsync(string url);
    }
}
