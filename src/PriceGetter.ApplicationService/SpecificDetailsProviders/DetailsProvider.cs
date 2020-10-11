using PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces;
using PriceGetter.Contracts.Products;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ApplicationServices.SpecificDetailsProviders
{
    public class DetailsProvider : IDetailsProvider
    {
        private readonly ISpecificDetailsProviderFactory factory;
        private readonly ICacheFacade cacheFacade;

        public DetailsProvider(
            ISpecificDetailsProviderFactory specificDetailsProviderFactory
            ,ICacheFacade cacheFacade)
        {
            this.factory = specificDetailsProviderFactory;
            this.cacheFacade = cacheFacade;
        }

        public async Task<PreProductDto> GetAsync(string url)
        {
            ISpecificDetailsProvider provider = this.factory.Get(url);

            Url productUrl = new Url(url);

            PreProductDto specificDetailsDto = this.cacheFacade.Get<PreProductDto>(url);
            if(specificDetailsDto == null)
            {
                specificDetailsDto = await provider.GetAsync(productUrl);
                this.cacheFacade.Save(specificDetailsDto, url);
            }

            return specificDetailsDto;
        }
    }
}
