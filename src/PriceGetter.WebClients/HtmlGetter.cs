using PriceGetter.ContentProvider.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PriceGetter.WebClients
{
    public class HtmlGetter : IHtmlContentGetter
    {
        public async Task<Html> GetAsync(Url url)
        {
            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(url.Value);

            string responseContent = await response.Content.ReadAsStringAsync();

            Html html = new Html(responseContent);

            return html;
        }
    }
}
