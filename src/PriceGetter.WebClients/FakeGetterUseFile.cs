using PriceGetter.Core.Interfaces;
using PriceGetter.Core.Models.ValueObjects;
using System.IO;
using System.Threading.Tasks;

namespace PriceGetter.WebClients
{
    public class FakeGetterUseFile : IHtmlContentGetter
    {
        public async Task<Html> GetAsync(Url url)
        {
            string htmlAsString = File.ReadAllText("/home/krzysztof/data/PriceGetter/content.html");

            Html html = new Html(htmlAsString);

            return await Task.FromResult(html);
        }
    }
}
