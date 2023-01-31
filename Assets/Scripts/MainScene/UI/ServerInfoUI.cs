using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mirror.Discovery
{
    public class ServerInfoUI : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TextMeshProUGUI _text;

        private DiscoveryResponse _response;
        private Action<DiscoveryResponse> _clickCallback;

        private void Start()
        {
            _button.onClick.AddListener(ClickHandle);
        }

        public void Initialize(Action<DiscoveryResponse> clickCallback)
        {
            _clickCallback = clickCallback;
        }   
        
        public void CheckoutInfo(DiscoveryResponse info)
        {
            _response = info;
            _text.text = info.ServerUri.Host;
            gameObject.SetActive(true);
        }

        public void Reset()
        {
            gameObject.SetActive(false);
        }

        private void ClickHandle()
        {
            _clickCallback?.Invoke(_response);
        }
    }
}