using System;
using System.Net;
using UnityEngine;

namespace Mirror.Discovery
{
    public class CustomDiscovery : NetworkDiscoveryBase<DiscoveryRequest, DiscoveryResponse>
    {
        #region Server

        [SerializeField]
        private Transport _transport;

        private Action<DiscoveryResponse> _onServerFound;

        public void SubscribeOnDiscovery(Action<DiscoveryResponse> callback)
        {
            _onServerFound += callback;
        }

        protected override DiscoveryResponse ProcessRequest(DiscoveryRequest request, IPEndPoint endpoint)
        {
            return new DiscoveryResponse()
            {
                ServerUri = _transport.ServerUri()
            };
        }

        #endregion

        #region Client

        protected override DiscoveryRequest GetRequest()
        {
            return new DiscoveryRequest();
        }

        protected override void ProcessResponse(DiscoveryResponse response, IPEndPoint endpoint)
        {
            response.EndPoint = endpoint;

            UriBuilder realUri = new UriBuilder(response.ServerUri)
            {
                Host = response.EndPoint.Address.ToString()
            };
            response.ServerUri = realUri.Uri;

            _onServerFound?.Invoke(response);
        }

        #endregion
    }
}