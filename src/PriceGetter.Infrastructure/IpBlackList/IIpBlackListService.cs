using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PriceGetter.Infrastructure.IpBlackList
{
    public interface IIpBlackListService
    {
        bool IsAllowed(IPAddress ip);
    }
}
