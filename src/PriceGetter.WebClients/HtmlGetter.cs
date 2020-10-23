using PriceGetter.Core.Interfaces;
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
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("sec-fetch-dest", "empty");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "same-origin");
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.111 Safari/537.36 Edg/86.0.622.51");

            HttpResponseMessage response = await client.GetAsync(url.ToString());

            string responseContent = await response.Content.ReadAsStringAsync();

            Html html = new Html(responseContent);

            return html;
        }
    }
}
