using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.SellerServices
{
    public interface ISellerService
    {
        Task AddSeller(string sellerName, string sellerPage);
    }
}
