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
        private static HttpClient client = new HttpClient();

        public async Task<Html> GetAsync(Url url)
        {
            HttpResponseMessage response = await client.GetAsync(url.Value);

            string responseContent = await response.Content.ReadAsStringAsync();

            Html html = new Html(responseContent);

            return html;
        }
    }
}
