using System;
using UnityEngine;
using UnityEngine.UI;

namespace Mirror.Discovery
{
    public class ButtonsUI : MonoBehaviour
    {
        [SerializeField]
        private Button _hostButton;
        [SerializeField]
        private Button _findButton;
        [SerializeField]
        private Button _exitButton;

        private CustomDiscovery _networkDiscovery;
        private Action _clearAction;

        public void Initialize(CustomDiscovery discovery, Action clear)
        {
            _networkDiscovery = discovery;
            _clearAction = clear;
        }

        private void Start()
        {
            _hostButton.onClick.AddListener(HostClickHandle);
            _findButton.onClick.AddListener(FindClickHandle);
            _exitButton.onClick.AddListener(ExitClickHandle);
        }

        private void FindClickHandle()
        {
            _clearAction.Invoke();
            _networkDiscovery.StartDiscovery();
        }

        private void HostClickHandle()
        {
            _clearAction.Invoke();
            NetworkManager.singleton.StartHost();
            _networkDiscovery.AdvertiseServer();
        }

        private void ExitClickHandle()
        {
            Application.Quit();
        }
    }
}