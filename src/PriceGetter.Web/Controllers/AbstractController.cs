using Microsoft.AspNetCore.Mvc;
using PriceGetter.Web.Filters;

namespace PriceGetter.Web.Controllers
{
    /// <summary>
    /// Base controller of API. Other controllers should inherit from this one.
    /// </summary>
    [ApiController]
    [ServiceFilter(typeof(IpBlackListFilter))]
    [ServiceFilter(typeof(ExecutionTimeFilter))]
    [Route("api/[controller]")]
    public abstract class AbstractController : ControllerBase
    {
    }
}
