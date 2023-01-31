using UnityEngine;

namespace Mirror.Discovery
{
    public class NetworkUI : MonoBehaviour
    {
        [SerializeField]
        private CustomDiscovery _networkDiscovery;
        [SerializeField]
        private ButtonsUI _buttonsUI;
        [SerializeField]
        private ServersListUI _serversUI;

        private void Start()
        {
            _networkDiscovery.SubscribeOnDiscovery(OnDiscoveredServer);
            _buttonsUI.Initialize(_networkDiscovery, ClearServers);
            _serversUI.Initialize(_networkDiscovery);
        }

        public void OnDiscoveredServer(DiscoveryResponse info)
        {
            _serversUI.AddServer(info);
        }

        private void ClearServers()
        {
            _serversUI.Clear();
        }
    }
}
