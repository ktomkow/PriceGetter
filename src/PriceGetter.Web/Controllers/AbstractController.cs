using Microsoft.AspNetCore.Mvc;
using PriceGetter.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(IpBlackListFilter))]
    [ServiceFilter(typeof(ExecutionTimeFilter))]
    [Route("api/[controller]")]
    public abstract class AbstractController : ControllerBase
    {
    }
}
