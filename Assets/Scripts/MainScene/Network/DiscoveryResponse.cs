using System;
using System.Net;

namespace Mirror.Discovery
{
    public class DiscoveryResponse : NetworkMessage
    {
        public Uri ServerUri;
        public IPEndPoint EndPoint { get; set; }
    }
}