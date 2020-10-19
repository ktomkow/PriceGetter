using PriceGetter.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.Interfaces
{
    public interface IPreProductService : IApplicationService
    {
        Task<PreProductDto> Get(string productPage);
    }
}
