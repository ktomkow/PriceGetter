using PriceGetter.Contracts.Products;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces
{
    public interface ISpecificDetailsProvider
    {
        Task<SellerSpecificDetails> GetAsync(Url url);
    }
}
