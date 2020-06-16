using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class AbstractController : ControllerBase
    {
    }
}
