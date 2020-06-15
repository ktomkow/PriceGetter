﻿using Microsoft.AspNetCore.Mvc;
using PriceGetter.ApplicationServices.SpecificDetailsProviders.Interfaces;
using PriceGetter.ApplicationServices.SpecificDetailsProviders.Sellers;
using PriceGetter.Contracts.Products;
using PriceGetter.Core.Models.ValueObjects;
using PriceGetter.Infrastructure.Cache;
using PriceGetter.Web.Tools.Unbaser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    public class PreProductDetailsController : AbstractController
    {
        private readonly IDetailsProvider detailsProvider;
        private readonly IUrlUnbaser urlUnbaser;
        private readonly ICacheFacade cacheFacade;

        public PreProductDetailsController(IDetailsProvider detailsProvider, IUrlUnbaser urlUnbaser, ICacheFacade cacheFacade)
        {
            this.detailsProvider = detailsProvider;
            this.urlUnbaser = urlUnbaser;
            this.cacheFacade = cacheFacade;
        }

        /// <summary>
        /// This method gets product details from the seller page.
        /// </summary>
        ///  <remarks>
        /// Sample url:
        /// 
        ///     aHR0cHM6Ly93d3cueC1rb20ucGwvcC81NjQ0NDctcHJvY2Vzb3J5LWludGVsLWNvcmUtaTUtaW50ZWwtY29yZS1pNS0xMDYwMGtmLmh0bWw=
        ///     
        /// </remarks>
        /// <param name="productUrlBase64">Product page encoded with base64</param>
        /// <returns>SellerSpecificDetailsDto</returns>
        [HttpGet]
        [Route("{productUrlBase64}")]
        public async Task<SellerSpecificDetailsDto> GetDetails([FromRoute]string productUrlBase64)
        {
            Url url = this.urlUnbaser.Unbase(productUrlBase64);

            SellerSpecificDetailsDto details = this.cacheFacade.Get<SellerSpecificDetailsDto>(url);
            if (details == null)
            {
                details = await this.detailsProvider.GetAsync(url.Value);
                this.cacheFacade.Save(details, url);
            }
                
            return details;
        }
    }
}