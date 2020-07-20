using PriceGetter.Core.Entities;
using PriceGetter.Core.Enums;
using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.SellerServices
{
    public class SellerService : ISellerService
    {
        private readonly ISellersRepository sellersRepository;

        public SellerService(ISellersRepository sellersRepository)
        {
            this.sellersRepository = sellersRepository;
        }

        public async Task AddSeller(string sellerName, string sellerPage)
        {
            Url url = new Url(sellerPage);
            Name name = new Name(sellerName);

            if (await this.DoesExists(name))
            {
                throw new ArgumentException($"Seller {name} already exists");
            }

            SellerSystem sellerSystem = SellerSystem.xkom;

            Seller seller = new Seller(name, sellerSystem);
            seller.UpdateHomePage(url);

            await this.sellersRepository.Save(seller);
        }

        private async Task<bool> DoesExists(Name name)
        {
            var existingSellers = await this.sellersRepository.Get();
            bool isAlreadyCreated = existingSellers.Any(x => x.Name == name);

            return isAlreadyCreated;
        }
    }
}
