using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PriceGetter.Infrastructure.IpBlackList
{
    public class IpBlackListService : IIpBlackListService
    {
        public bool IsAllowed(IPAddress ip)
        {
            return true;
        }
    }
}
