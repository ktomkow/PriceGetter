using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.ContentProvider.Interfaces
{
    public interface IHtmlContentGetter
    {
        Task<Html> GetAsync(Url url);
    }
}
