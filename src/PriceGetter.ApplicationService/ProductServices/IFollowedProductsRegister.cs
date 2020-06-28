using PriceGetter.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.ProductServices
{
    public interface IFollowedProductsRegister
    {
        Task RegisterPrices(); 
    }
}
