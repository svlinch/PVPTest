using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Discovery
{
    public class ServersListUI : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _transform;
        [SerializeField]
        private GameObject _infoPrefab;

        private List<ServerInfoUI> _servers = new List<ServerInfoUI>();

        private CustomDiscovery _networkDiscovery;
        private int _currentServersCount;

        public void Initialize(CustomDiscovery discovery)
        {
            _networkDiscovery = discovery;
        }

        public void Clear()
        {
            foreach(var server in _servers)
            {
                server.Reset();
            }
            _currentServersCount = 0;
        }

        public void AddServer(DiscoveryResponse info)
        {
            _currentServersCount++;
            CheckoutServersCount();

            _servers[_currentServersCount - 1].CheckoutInfo(info);
        }

        private void CheckoutServersCount()
        {
            if (_currentServersCount > _servers.Count)
            {
                var newServer = Instantiate(_infoPrefab, _transform).GetComponent<ServerInfoUI>();
                newServer.Initialize(Connect);
                _servers.Add(newServer);
            }
        }

        private void Connect(DiscoveryResponse info)
        {
            _networkDiscovery.StopDiscovery();
            NetworkManager.singleton.StartClient(info.ServerUri);
        }
    }
}